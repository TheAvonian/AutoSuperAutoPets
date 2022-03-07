using System;
using System.Collections.Generic;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class GameManager
{
    public static GameManager Instance;
    Team _teamOne;
    Team _teamTwo;

    Team _tempOne;
    Team _tempTwo;

    public PetVisualizer PP;

    public GameManager( Team team )
    {
        Instance = this;
        _teamOne = team;
        _teamTwo = new Team();
        State = GameState.TurnStart;
    }

    public Team GetTeam( int teamNum )
    {
        return teamNum == 0 ? _teamOne : _teamTwo;
    }

    public GameState State;

    public WinState Update()
    {
        switch ( State )
        {
            case GameState.TurnStart:
                if ( TurnStart() )
                {
                    State = GameState.Turn;
                }

                break;
            case GameState.Turn:

                break;
            case GameState.TurnEnd:
                if ( EndTurn() )
                {
                    State = GameState.BattleStart;
                }

                break;
            case GameState.BattleStart:
                if ( StartBattle() )
                {
                    State = GameState.Battle;
                }

                break;
            case GameState.Battle:
                if ( BattlePhase() )
                {
                    State = GameState.BattleEnd;
                }

                break;
            case GameState.BattleEnd:
                if ( EndBattle() )
                {
                    State = GameState.TurnStart;
                    if ( _tempOne.Pets.Count > 0 )
                    {
                        _teamOne.Wins++;
                        Debug.Log( $"Win: {_teamOne.Wins}" );
                        return WinState.Win;
                    }

                    if ( _tempTwo.Pets.Count > 0 )
                    {
                        _teamOne.Health--;
                        Debug.Log( $"Loss, Health: {_teamOne.Health}" );
                        return WinState.Loss;
                    }

                    return WinState.Tie;
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return WinState.Nothing;
    }

    public enum WinState
    {
        Nothing,
        Tie,
        Loss,
        Win,
    }

    bool EndBattle()
    {
        return true;
    }

    bool BattlePhase()
    {
        if ( _tempOne.Pets.Count <= 0 || _tempTwo.Pets.Count <= 0 )
        {
            return true;
        }

        PetData frontPetOne = _tempOne.Pets.First.Value;
        PetData frontPetTwo = _tempTwo.Pets.First.Value;
        frontPetOne.OnAttack( _tempOne, _tempTwo );
        frontPetTwo.OnAttack( _tempTwo, _tempOne );
        return false;
    }

    bool StartBattle()
    {

        for ( LinkedListNode< PetData > node = _tempOne.Pets.First; node != null; node = node.Next )
        {
            node.Value.OnBattleStart( _tempOne, _tempTwo );
        }

        for ( LinkedListNode< PetData > node = _tempTwo.Pets.First; node != null; node = node.Next )
        {
            node.Value.OnBattleStart( _tempTwo, _tempOne );
        }

        return true;
    }

    bool EndTurn()
    {
        foreach ( PetData pet in _teamOne.Pets )
        {
            pet?.OnTurnEnd( _teamOne );
        }

        _tempOne = _teamOne.CloneTeam();
        // CHANGE RANDOM ENEMIES

        LinkedList< PetData > tmp = new();
        for ( int i = 0; i < Math.Clamp( _teamOne.Shop.Turn, 0, 6 ); i++ )
        {
            tmp.AddLast( PetData.RandomPet( Math.Clamp( _teamOne.Shop.Turn, 0, 6 ), true ) );
        }

        _tempTwo = new Team
        {
            TeamName = "Random Team",
            Pets = tmp,
        };
        return true;
    }


    bool TurnStart()
    {
        Debug.Log( "start turn" );
        _teamOne.TeamName = "AI";
        _teamOne.Coins = 10;
        _teamOne.Shop.IncrementTurn();
        _teamOne.Shop.RerollShop();
        for(LinkedListNode<PetData> petNode = _teamOne.Pets.Last; petNode != null; petNode = petNode.Previous)
        {
            petNode.Value?.OnTurnStart( _teamOne );
        }

        return true;
    }

    public enum GameState
    {
        TurnStart,
        Turn,
        TurnEnd,
        BattleStart,
        Battle,
        BattleEnd,
    }
}
