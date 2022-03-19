using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

[RequireComponent(typeof(GameManager))]
public class PetVisualizer : MonoBehaviour
{
    public GameObject TeamOneParent;
    public GameObject TeamTwoParent;
    public GameObject ShopParent;
    GameManager _gameManager;

    readonly List<Transform> _teamOneTiles = new();
    readonly List<Transform> _teamTwoTiles = new();
    readonly List<Transform> _shopTiles = new();
    Sprite[] _sprites;

    Team _myTeam;
    Team _enemyTeam;
    
    
    void Start()
    {
        _gameManager = GetComponent< GameManager >();
        for ( int i = 0; i < TeamOneParent.transform.childCount; i++ )
        {
            _teamOneTiles.Add( TeamOneParent.transform.GetChild(i) );
        }
        for ( int i = 0; i < TeamTwoParent.transform.childCount; i++ )
        {
            _teamTwoTiles.Add( TeamTwoParent.transform.GetChild(i) );
        }
        for ( int i = 0; i < ShopParent.transform.childCount; i++ )
        {
            _shopTiles.Add( ShopParent.transform.GetChild(i) );
        }
        _sprites = Resources.LoadAll( "Pets", typeof( Sprite ) ).Cast< Sprite >().ToArray();
        foreach ( Transform go in _teamOneTiles )
        {
            go.GetComponent< Image >().color = new Color( 1, 1, 1, 0 );
            go.GetComponentInChildren< Image >().color = new Color( 1, 1, 1, 0 );
        }

        foreach ( Transform go in _teamTwoTiles )
        {
            go.GetComponent< Image >().color = new Color( 1, 1, 1, 0 );
            go.GetComponentInChildren< Image >().color = new Color( 1, 1, 1, 0 );
        }

        foreach ( Transform go in _shopTiles )
        {
            go.GetComponent< Image >().color = new Color( 1, 1, 1, 0 );
        }
    }

    void Update()
    {
        switch ( _gameManager.State )
        {
            case GameManager.GameState.TurnEnd:
            case GameManager.GameState.Battle:
            case GameManager.GameState.BattleStart:
                _myTeam = _gameManager.BattleTeamOne;
                _enemyTeam = _gameManager.BattleTeamTwo;
                //TeamOneParent.transform.localScale = new Vector3( -0.75f, 0.75f, 1 );
                foreach ( Transform go in _shopTiles )
                {
                    go.GetComponent< Image >().color = new Color( 1, 1, 1, 0 );
                }
                break;
            case GameManager.GameState.Turn:
            case GameManager.GameState.TurnStart:
            case GameManager.GameState.BattleEnd:
                _myTeam = _gameManager.TeamOne;
                _enemyTeam = null;
                //TeamOneParent.transform.localScale = new Vector3( -1, 1, 1 );
                foreach ( Transform go in _teamTwoTiles )
                {
                    go.GetComponent< Image >().color = new Color( 1, 1, 1, 0 );
                    go.GetComponentInChildren< Image >().color = new Color( 1, 1, 1, 0 );
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        if ( _myTeam is {Health: > 0} && _enemyTeam == null )
        {
            for(int i = 0; i < _myTeam.Pets.Size; i++)
            {
                PetData currPet = _myTeam.Pets.GetPet(i);
                if(currPet == null) {
                    _teamOneTiles[ i ].GetComponent< Image >().sprite = null;
                    _teamOneTiles[ i ].GetComponent< Image >().color = new Color( 1, 1, 1, 0 );
                } else if ( _sprites.Any( x => x.name.Equals( ( (PetData.AllPets) currPet.PetID ).ToString() ) ) )
                {
                    _teamOneTiles[ i ].GetComponent< Image >().sprite = _sprites.First( x => x.name.Equals( ( (PetData.AllPets) currPet.PetID ).ToString() ) );
                    if ( currPet.Food != FoodData.Food.None )
                    {
                        _teamOneTiles[ i ].transform.GetChild( 0 ).GetComponent< Image >().color = Color.white;
                        _teamOneTiles[ i ].transform.GetChild( 0 ).GetComponent< Image >().sprite = _sprites.First( x => x.name.Equals( currPet.Food.ToString() ) );
                    } else
                    {
                        _teamOneTiles[ i ].transform.GetChild( 0 ).GetComponent< Image >().color = new Color( 1, 1, 1, 0 );
                    }

                    _teamOneTiles[ i ].GetComponent< Image >().color = new Color( 1, 1, 1, 1 );
                }
            }

            int index = 0;
            for ( int i = 0; i < _myTeam.Shop.Items.Length; i++ )
            {
                ShopItem item = _myTeam.Shop.Items[ i ];

                if(item == null) {
                    _shopTiles[ index ].GetComponent< Image >().color = new Color( 1, 1, 1, 0 );
                } else if ( item.Pet != null || item.Food != null ) {
                    _shopTiles[ index ].GetComponent< Image >().sprite = _sprites.First( x => x.name.Equals( item.Pet != null ? ( (PetData.AllPets) item.Pet.PetID ).ToString() : item.Food?.Type.ToString() ) );
                    _shopTiles[ index ].GetComponent< Image >().color = item.Frozen ? new Color( 0, 255, 235 ) : new Color( 255, 255, 255 );
                }

                index++;
            }

            for ( int i = index; i < _shopTiles.Count; i++ )
            {
                _shopTiles[ index ].GetComponent< Image >().sprite = null;
                _shopTiles[ index ].GetComponent< Image >().color = new Color( 1, 1, 1, 0 );
            }
        } else if ( _enemyTeam != null )
        {
            for(int i = 0; i < _myTeam.Pets.Size; i++)
            {
                PetData currPet = _myTeam.Pets.GetPet(i);
                if(currPet == null) 
                {
                    _teamOneTiles[ i ].GetComponent< Image >().sprite = null;
                    _teamOneTiles[ i ].GetComponent< Image >().color = new Color( 1, 1, 1, 0 );
                    _teamOneTiles[ i ].GetChild(0).GetComponent< Image>().color = new Color( 1, 1, 1, 0 );
                } else if ( _sprites.Any( x => x.name.Equals( ( (PetData.AllPets) currPet.PetID ).ToString() ) ) )
                {
                    _teamOneTiles[ i ].GetComponent< Image >().sprite = _sprites.First( x => x.name.Equals( ( (PetData.AllPets) currPet.PetID ).ToString() ) );
                    if ( currPet.Food != FoodData.Food.None )
                    {
                        _teamOneTiles[ i ].GetChild( 0 ).GetComponent< Image >().color = Color.white;
                        _teamOneTiles[ i ].GetChild( 0 ).GetComponent< Image >().sprite = _sprites.First( x => x.name.Equals( currPet.Food.ToString() ) );
                    } else
                    {
                        _teamOneTiles[ i ].GetChild( 0 ).GetComponent< Image >().color = new Color( 1, 1, 1, 0 );
                    }

                    _teamOneTiles[ i ].GetComponent< Image >().color = new Color( 1, 1, 1, 1 );
                }
            }

            for(int i = 0; i < _enemyTeam.Pets.Size; i++)
            {
                PetData currPet = _enemyTeam.Pets.GetPet(i);
                if(currPet == null) 
                {
                    _teamOneTiles[ i ].GetComponent< Image >().sprite = null;
                    _teamOneTiles[ i ].GetComponent< Image >().color = new Color( 1, 1, 1, 0 );
                    _teamOneTiles[ i ].GetChild(0).GetComponent< Image>().color = new Color( 1, 1, 1, 0 );
                } else if ( _sprites.Any( x => x.name.Equals( ( (PetData.AllPets) currPet.PetID ).ToString() ) ) )
                {
                    _teamOneTiles[ i ].GetComponent< Image >().sprite = _sprites.First( x => x.name.Equals( ( (PetData.AllPets) currPet.PetID ).ToString() ) );
                    if ( currPet.Food != FoodData.Food.None )
                    {
                        _teamOneTiles[ i ].GetChild( 0 ).GetComponent< Image >().color = Color.white;
                        _teamOneTiles[ i ].GetChild( 0 ).GetComponent< Image >().sprite = _sprites.First( x => x.name.Equals( currPet.Food.ToString() ) );
                    } else
                    {
                        _teamOneTiles[ i ].GetChild( 0 ).GetComponent< Image >().color = new Color( 1, 1, 1, 0 );
                    }

                    _teamOneTiles[ i ].GetComponent< Image >().color = new Color( 1, 1, 1, 1 );
                }
            }
        }
    }
}
