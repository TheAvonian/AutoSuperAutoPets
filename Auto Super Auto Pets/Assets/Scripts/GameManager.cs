using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        Application.runInBackground = true;
    }

    public Team TeamOne;
    [HideInInspector]
    public Team TeamTwo;

    [HideInInspector]
    public Team BattleTeamOne;
    [HideInInspector]
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
                    if ( BattleTeamOne.Pets.PetCount > 0 )
                    {
                        TeamOne.Wins++;
                        //Debug.Log( $"Win: {TeamOne.Wins}" );
                        return WinState.Win;
                    }

                    if ( BattleTeamTwo.Pets.PetCount > 0 )
                    {
                        TeamOne.Health-= Mathf.Clamp(TeamOne.Shop.Turn / 2 + 1, 1,3);
                        //Debug.Log( $"Loss, Health: {TeamOne.Health}" );
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
        if ( BattleTeamOne.Pets.PetCount <= 0 || BattleTeamTwo.Pets.PetCount <= 0 )
        {
            return true;
        }

        PetData frontPetOne = BattleTeamOne.Pets.GetFirstPet();
        PetData frontPetTwo = BattleTeamTwo.Pets.GetFirstPet();
        frontPetOne.OnAttack( BattleTeamOne, BattleTeamTwo );
        frontPetTwo.OnAttack( BattleTeamTwo, BattleTeamOne );
        return false;
    }

    bool StartBattle()
    {

        for(int i = 0; i < BattleTeamOne.Pets.Size; i++) {
            PetData pet = BattleTeamOne.Pets.GetPet(i);
            if(pet == null) continue;
            pet.OnBattleStart(BattleTeamOne, BattleTeamTwo);
        }

        for(int i = 0; i < BattleTeamTwo.Pets.Size; i++) {
            PetData pet = BattleTeamTwo.Pets.GetPet(i);
            if(pet == null) continue;
            pet.OnBattleStart(BattleTeamTwo, BattleTeamOne);
        }

        return true;
    }
    public bool Readied;
    bool EndTurn()
    {
        for(int i = TeamOne.Pets.Size - 1; i >= 0; i--) {
            PetData pet = TeamOne.Pets.GetPet(i);
            if(pet == null) continue;
            pet.OnTurnEnd(TeamOne);
        }

        //Readied = true;

        //if ( !OtherPlayer.Readied )
        {
          //  return false;
        }

        BattleTeamOne = TeamOne.CloneTeam();
        //TeamTwo = OtherPlayer.TeamOne;
        //BattleTeamTwo = TeamTwo.CloneTeam();

        // CHANGE RANDOM ENEMIES

        PetArray tmp = new PetArray(TeamOne.Pets.Size);
        for ( int i = 0; i < Mathf.RoundToInt(Random.value * 6f); i++ )
        {
            tmp.TryAddFriend( PetData.RandomPet( Math.Clamp( TeamOne.Shop.Turn / 2 + 1, 0, 6 ), true ), i );
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
        Readied = false;
        //Debug.Log( "start turn" );
        TeamOne.TeamName = "AI";
        TeamOne.Coins = 10;
        TeamOne.Shop.IncrementTurn();
        TeamOne.Shop.RerollShop();
        for(int i = 0; i < TeamOne.Pets.Size; i++) {
            PetData pet = TeamOne.Pets.GetPet(i);
            if(pet == null) continue;
            pet.OnTurnStart(TeamOne);
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
