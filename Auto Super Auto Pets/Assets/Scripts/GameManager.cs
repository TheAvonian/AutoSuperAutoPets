using System;
using System.Collections.Generic;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Team TeamOne;
    public Team TeamTwo;

    public Team BattleTeamOne;
    public Team BattleTeamTwo;

    public GameState State;

    public WinState GameUpdate()
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
                    if ( BattleTeamOne.Pets.Count > 0 )
                    {
                        TeamOne.Wins++;
                        Debug.Log( $"Win: {TeamOne.Wins}" );
                        return WinState.Win;
                    }

                    if ( BattleTeamTwo.Pets.Count > 0 )
                    {
                        TeamOne.Health--;
                        Debug.Log( $"Loss, Health: {TeamOne.Health}" );
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
        if ( BattleTeamOne.Pets.Count <= 0 || BattleTeamTwo.Pets.Count <= 0 )
        {
            return true;
        }

        PetData frontPetOne = BattleTeamOne.Pets.First.Value;
        PetData frontPetTwo = BattleTeamTwo.Pets.First.Value;
        frontPetOne.OnAttack( BattleTeamOne, BattleTeamTwo );
        frontPetTwo.OnAttack( BattleTeamTwo, BattleTeamOne );
        return false;
    }

    bool StartBattle()
    {

        for ( LinkedListNode< PetData > node = BattleTeamOne.Pets.First; node != null; node = node.Next )
        {
            node.Value.OnBattleStart( BattleTeamOne, BattleTeamTwo );
        }

        for ( LinkedListNode< PetData > node = BattleTeamTwo.Pets.First; node != null; node = node.Next )
        {
            node.Value.OnBattleStart( BattleTeamTwo, BattleTeamOne );
        }

        return true;
    }

    bool EndTurn()
    {
        foreach ( PetData pet in TeamOne.Pets )
        {
            pet?.OnTurnEnd( TeamOne );
        }

        BattleTeamOne = TeamOne.CloneTeam();
        // CHANGE RANDOM ENEMIES

        LinkedList< PetData > tmp = new();
        for ( int i = 0; i < Math.Clamp( TeamOne.Shop.Turn, 0, 5 ); i++ )
        {
            tmp.AddLast( PetData.RandomPet( Math.Clamp( TeamOne.Shop.Turn, 0, 6 ), true ) );
        }

        BattleTeamTwo = new Team
        {
            TeamName = "Random Team",
            Pets = tmp,
        };
        
        Debug.Log( $"Enemy Team: {BattleTeamTwo}" );
        return true;
    }


    bool TurnStart()
    {
        Debug.Log( "start turn" );
        TeamOne.TeamName = "AI";
        TeamOne.Coins = 10;
        TeamOne.Shop.IncrementTurn();
        TeamOne.Shop.RerollShop();
        for(LinkedListNode<PetData> petNode = TeamOne.Pets.Last; petNode != null; petNode = petNode.Previous)
        {
            petNode.Value?.OnTurnStart( TeamOne );
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


    public void ResetGame()
    {
        TeamOne = new Team();
        TeamTwo = new Team();
        State = GameState.TurnStart;
    }
}
