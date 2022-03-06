using System;
using System.Collections.Generic;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class GameManager
{
    Team _teamOne;
    Team _teamTwo;

    Team _tempOne;
    Team _tempTwo;

    public GameManager( Team team )
    {
        _teamOne = team;
        State = GameState.TurnStart;
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
                    if ( _tempTwo.Pets.Count > 0 )
                    {
                        _teamOne.Wins++;
                        Debug.Log( "Win" );
                        return WinState.Win;
                    }

                    if ( _tempTwo.Pets.Count > 0 )
                    {
                        _teamOne.Health--;
                        Debug.Log( "Loss" );
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

        _tempOne.Pets.First.Value.OnAttack( _tempOne, _tempTwo );
        _tempTwo.Pets.First.Value.OnAttack( _tempTwo, _tempOne );
        return false;
    }

    bool StartBattle()
    {
        foreach ( PetData pet in _tempOne.Pets )
        {
            pet?.OnBattleStart( _tempOne, _tempTwo );
        }

        foreach ( PetData pet in _tempTwo.Pets )
        {
            pet?.OnBattleStart( _tempTwo, _tempOne );
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
        _tempTwo = _teamTwo.CloneTeam();
        return true;
    }


    bool TurnStart()
    {
        _teamOne.Coins = 10;
        _teamOne.Shop.IncrementTurn();
        _teamOne.Shop.RerollShop();
        foreach ( PetData pet in _teamOne.Pets )
        {
            pet?.OnTurnStart( _teamOne );
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
