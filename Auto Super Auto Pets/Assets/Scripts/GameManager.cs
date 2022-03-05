using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ShopData _shop;
    
    Team _teamOne;
    Team _teamTwo;

    Team _tempOne;
    Team _tempTwo;

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
                    State = GameState.BattleEnd;
                }

                break;
            case GameState.BattleEnd:
                if ( EndBattle() )
                {
                    State = GameState.TurnStart;
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    bool EndBattle()
    {
        return true;
    }

    bool BattlePhase()
    {
        return true;
    }

    bool StartBattle()
    {
        foreach ( PetData pet in _teamOne.Pets )
        {
            pet?.OnBattleStart(_teamOne, _teamTwo);
        }
        return true;
    }

    bool EndTurn()
    {
        foreach ( PetData pet in _teamOne.Pets )
        {
            pet?.OnTurnEnd(_teamOne);
        }

        _tempOne = CloneTeam( _teamOne );
        return true;
    }

    Team CloneTeam( Team team )
    {
        Team tempNew = new();
        foreach ( PetData p in team.Pets )
        {
            tempNew.Pets.AddLast( new LinkedListNode< PetData >( PetData.CloneObject(p) as PetData) );
        }

        return tempNew;
    }

    bool Turn()
    {
        return false;
    }

    bool TurnStart()
    {
        _teamOne = _tempOne;
        _shop.RerollShop();
        _teamOne.Coins = 10;
        _teamOne.Turn++;
        foreach ( PetData pet in _teamOne.Pets )
        {
            pet?.OnTurnStart(_teamOne);
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
