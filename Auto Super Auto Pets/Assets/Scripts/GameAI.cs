using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class GameAI : Agent
{

    Team _myTeam;
    GameManager _manager;

    float _timer;

    void FixedUpdate()
    {
        _timer += Time.deltaTime;
        if ( _timer > 2f )
        {
            if ( _manager.State == GameManager.GameState.Turn )
            {
                RequestDecision();
            }

            switch ( _manager.Update() )
            {
                case GameManager.WinState.Loss:
                    AddReward( -0.1f );
                    break;
                case GameManager.WinState.Tie:
                    AddReward( 0.005f );
                    break;
                case GameManager.WinState.Win:
                    AddReward( 0.1f );
                    break;
                case GameManager.WinState.Nothing:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Debug.Log( _myTeam );
            Debug.Log( _myTeam.Shop );
            _timer = 0;
        }
    }

    public override void OnEpisodeBegin()
    {
        _myTeam = new Team();
        _manager = new GameManager( _myTeam );
    }

    public override void Heuristic( in ActionBuffers actionsOut )
    {
        ActionSegment< int > dActions = actionsOut.DiscreteActions;
        if ( Input.GetKeyDown( KeyCode.Alpha1 ) )
        {
            dActions[ 0 ] = 1;
        }

    }

    public override void OnActionReceived( ActionBuffers actions )
    {
        // Handle turn here

        if ( actions.DiscreteActions[ 0 ] != 7 && _myTeam.Coins >= 3 )
        {
            ShopItem p = _myTeam.Shop.TryGetItem( actions.DiscreteActions[ 0 ] );
            if ( p != null )
            {
                if ( actions.DiscreteActions[ 1 ] == 5 )
                {
                    // Freeze it
                    // p.Freeze()
                } else if ( _myTeam.TryPlaceItem( p, actions.DiscreteActions[ 1 ] ) )
                {
                    _myTeam.Coins -= 3;
                    AddReward( 0.00025f );
                }
            }
        }

        if ( actions.DiscreteActions[ 0 ] == 7 && _myTeam.Coins >= 1 )
        {
            _myTeam.Shop.RerollShop( _myTeam.Turn );
            _myTeam.Coins--;
        }

        if ( actions.DiscreteActions[ 2 ] != 5 )
        {
            int position = actions.DiscreteActions[ 3 ];
            if ( position == actions.DiscreteActions[ 2 ] )
            {
                AddReward( -0.00025f );
            } else
            {
                _myTeam.MovePet( actions.DiscreteActions[ 2 ], actions.DiscreteActions[ 3 ] );
            }
        } else if ( actions.DiscreteActions[ 2 ] == 5 )
        {
            AddReward( 0.00025f );
            _myTeam.SellPet( actions.DiscreteActions[ 3 ] );
            _myTeam.Coins++;
        }

        if ( _myTeam.Coins <= 0 )
        {
            _manager.State = GameManager.GameState.TurnEnd;
        }

        AddReward( -0.000025f );


        if ( _myTeam.Health <= 0 )
        {
            EndEpisode();
        }
    }

    public override void CollectObservations( VectorSensor sensor )
    {
        sensor.AddObservation( _myTeam.Coins );
        sensor.AddObservation( _myTeam.Health );
        foreach ( PetData p in _myTeam.Pets )
        {
            sensor.AddObservation( p.PetID );
            sensor.AddObservation( p.Damage );
            sensor.AddObservation( p.Health );
            sensor.AddObservation( p.StackHeight );
            sensor.AddObservation( p.Level );
        }

        foreach ( ShopItem p in _myTeam.Shop.Items )
        {
            if ( p?.Pet != null )
            {
                sensor.AddObservation( p.Pet.PetID );
                sensor.AddObservation( p.Pet.Damage );
                sensor.AddObservation( p.Pet.Health );
            } else if ( p?.Food != null )
            {
                //sensor.AddObservation( p.Food );
            }
        }

        sensor.AddObservation( _myTeam.Shop.Items.Count );
        sensor.AddObservation( _myTeam.Pets.Count );
    }
}
