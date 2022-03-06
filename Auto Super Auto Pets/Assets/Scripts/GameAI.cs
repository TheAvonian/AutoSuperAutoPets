using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameAI : Agent
{

    Team _myTeam;
    GameManager _manager;

    float _timer;

    void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
        if ( _timer > 2f )
        {
            if ( _manager.State == GameManager.GameState.Turn )
            {
                Debug.Log( "getting decision" );
                Debug.Log( _myTeam );
                Debug.Log( _myTeam.Shop );
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
        dActions[ 0 ] = Mathf.RoundToInt( Random.value * 7 );
        dActions[ 1 ] = Mathf.RoundToInt( Random.value * 5 );
        dActions[ 2 ] = Mathf.RoundToInt( Random.value * 5 );
        dActions[ 3 ] = Mathf.RoundToInt( Random.value * 4 );
        /*
        if ( Input.GetKeyDown( KeyCode.Alpha1 ) )
        {
            dActions[ 0 ] = 0;
        }
        if ( Input.GetKeyDown( KeyCode.Alpha2 ) )
        {
            dActions[ 0 ] = 1;
        }
        if ( Input.GetKeyDown( KeyCode.Alpha3 ) )
        {
            dActions[ 0 ] = 2;
        }
        if ( Input.GetKeyDown( KeyCode.Alpha4 ) )
        {
            dActions[ 0 ] = 3;
        }
        if ( Input.GetKeyDown( KeyCode.Alpha5 ) )
        {
            dActions[ 0 ] = 4;
        }
        if ( Input.GetKeyDown( KeyCode.Alpha6 ) )
        {
            dActions[ 0 ] = 5;
        }
        if ( Input.GetKeyDown( KeyCode.Alpha7 ) )
        {
            dActions[ 0 ] = 6;
        }
        if ( Input.GetKeyDown( KeyCode.Alpha8 ) )
        {
            dActions[ 0 ] = 7;
        }
        
        if ( Input.GetKeyDown( KeyCode.Q ) )
        {
            dActions[ 1 ] = 0;
        }
        if ( Input.GetKeyDown( KeyCode.W ) )
        {
            dActions[ 1 ] = 1;
        }
        if ( Input.GetKeyDown( KeyCode.E ) )
        {
            dActions[ 1 ] = 2;
        }
        if ( Input.GetKeyDown( KeyCode.R ) )
        {
            dActions[ 1 ] = 3;
        }
        if ( Input.GetKeyDown( KeyCode.T ) )
        {
            dActions[ 1 ] = 4;
        }
        if ( Input.GetKeyDown( KeyCode.Y ) )
        {
            dActions[ 1 ] = 5;
        }
        
        if ( Input.GetKeyDown( KeyCode.A ) )
        {
            dActions[ 2 ] = 0;
        }
        if ( Input.GetKeyDown( KeyCode.S ) )
        {
            dActions[ 2 ] = 1;
        }
        if ( Input.GetKeyDown( KeyCode.D ) )
        {
            dActions[ 2 ] = 2;
        }
        if ( Input.GetKeyDown( KeyCode.F ) )
        {
            dActions[ 2 ] = 3;
        }
        if ( Input.GetKeyDown( KeyCode.G ) )
        {
            dActions[ 2 ] = 4;
        }
        if ( Input.GetKeyDown( KeyCode.H ) )
        {
            dActions[ 2 ] = 5;
        }
        if ( Input.GetKeyDown( KeyCode.Z ) )
        {
            dActions[ 3 ] = 0;
        }
        if ( Input.GetKeyDown( KeyCode.X ) )
        {
            dActions[ 3 ] = 1;
        }
        if ( Input.GetKeyDown( KeyCode.C ) )
        {
            dActions[ 3 ] = 2;
        }
        if ( Input.GetKeyDown( KeyCode.V ) )
        {
            dActions[ 3 ] = 3;
        }
        if ( Input.GetKeyDown( KeyCode.B ) )
        {
            dActions[ 3 ] = 4;
        }*/
    }

    public override void OnActionReceived( ActionBuffers actions )
    {
        // Handle turn here
        
        if ( actions.DiscreteActions[ 0 ] != 7 && _myTeam.Coins >= 3 )
        {
            ShopItem p = _myTeam.Shop.TryGetItem( actions.DiscreteActions[ 0 ] );
            Debug.Log( $"Shop Selection: {actions.DiscreteActions[ 0 ]}: {p}" );
            if ( p != null && ( p.Food != null || p.Pet != null ) )
            {
                if ( actions.DiscreteActions[ 1 ] == 5 )
                {
                    Debug.Log( $"Froze Selection: {actions.DiscreteActions[ 1 ]}: {p}" );
                    // Freeze it
                    // p.Freeze()
                } else if ( _myTeam.TryPlaceItem( p, actions.DiscreteActions[ 1 ] ) )
                {
                    _myTeam.Coins -= 3;
                    AddReward( 0.00025f );
                    _myTeam.Shop.RemoveItem( actions.DiscreteActions[ 0 ] );
                }
            } else
            {
                Debug.Log( "Couldn't buy" );
            }
        }

        if ( actions.DiscreteActions[ 0 ] == 7 && _myTeam.Coins >= 1 )
        {
            Debug.Log("Rerolling"  );
            _myTeam.Shop.RerollShop();
            _myTeam.Coins--;
        }

        if ( actions.DiscreteActions[ 2 ] != 5 )
        {
            Debug.Log( "Moving Pet" );
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
            Debug.Log( $"Sell Selection: {actions.DiscreteActions[ 3 ]}" );
            if ( _myTeam.SellPet( actions.DiscreteActions[ 3 ] ) )
            {
                Debug.Log( "Sold Pet" );
                _myTeam.Coins++;
                AddReward( 0.00025f );
            }
        }

        if ( _myTeam.Coins <= 0 )
        {
            Debug.Log( "Ending turn" );
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

        LinkedListNode< PetData > node = _myTeam.Pets.First;
        for ( int i = 0; i < 5; i++ )
        {
            if ( node != null )
            {
                sensor.AddObservation( node.Value.PetID );
                sensor.AddObservation( node.Value.Damage );
                sensor.AddObservation( node.Value.Health );
                sensor.AddObservation( node.Value.StackHeight );
                sensor.AddObservation( node.Value.Level );
            } else
            {
                sensor.AddObservation( -1 );
                sensor.AddObservation( -1 );
                sensor.AddObservation( -1 );
                sensor.AddObservation( -1 );
                sensor.AddObservation( -1 );
            }

            node = node?.Next;
        }

        for ( int index = 0; index < 7; index++ )
        {
            ShopItem p = index < _myTeam.Shop.Items.Count ? _myTeam.Shop.Items[ index ] : null;
            if ( p?.Pet != null )
            {
                sensor.AddObservation( p.Pet.PetID );
                sensor.AddObservation( p.Pet.Damage );
                sensor.AddObservation( p.Pet.Health );
            } else if ( p?.Food != null )
            {
                //sensor.AddObservation( p.Food );
                //sensor.AddObservation(p.SomethingElse);
                //sensor.AddObservation(p.SomethingElse);
            } else
            {
                sensor.AddObservation( -1 );
                sensor.AddObservation( -1 );
                sensor.AddObservation( -1 );
            }
        }

        sensor.AddObservation( _myTeam.Shop.Items.Count );
        sensor.AddObservation( _myTeam.Pets.Count );
    }
}
