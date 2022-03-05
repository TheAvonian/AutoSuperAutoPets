using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Team _teamOne;
    Team _teamTwo;

    public GameState State = GameState.TurnStart;

    void Update()
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
                if ( Turn() )
                {
                    State = GameState.TurnEnd;
                }
                
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
                    State = GameState.TurnStart;
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    bool BattlePhase()
    {
        return true;
    }

    bool StartBattle()
    {
        return true;
    }

    bool EndTurn()
    {
        return true;
    }

    bool Turn()
    {
        return true;
    }

    bool TurnStart()
    {
        return true;
    }

    public enum GameState
    {
        TurnStart,
        Turn,
        TurnEnd,
        BattleStart,
        Battle,
    }
}
