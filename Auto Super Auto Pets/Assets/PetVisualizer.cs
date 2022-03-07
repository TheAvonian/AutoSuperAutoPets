using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PetVisualizer : MonoBehaviour
{
    public GameObject[] TeamTiles;
    public GameObject[] ShopTiles;

    public Sprite[] Sprites;

    Team _myTeam;

    void Start()
    {
        Sprites = Resources.LoadAll( "Pets", typeof( Sprite ) ).Cast< Sprite >().ToArray();
    }

    void Update()
    {
        if ( _myTeam is {Health: > 0} )
        {
            LinkedListNode< PetData > node = _myTeam.Pets.First;
            int index = 0;

            while ( node != null )
            {
                if ( Sprites.Any( x => x.name.Equals( ( (PetData.AllPets) node.Value.PetID ).ToString() ) ) )
                {
                    TeamTiles[ index ].GetComponent< Image >().sprite = Sprites.First( x => x.name.Equals( ( (PetData.AllPets) node.Value.PetID ).ToString() ) );
                    if ( node.Value.Food != FoodData.Food.None )
                    {
                        TeamTiles[ index ].transform.GetChild( 0 ).GetComponent< Image >().color = Color.white;
                        TeamTiles[ index ].transform.GetChild( 0 ).GetComponent< Image >().sprite = Sprites.First( x => x.name.Equals( node.Value.Food.ToString() ) );
                    } else
                    {
                        TeamTiles[ index ].transform.GetChild( 0 ).GetComponent< Image >().color = new Color( 1, 1, 1, 0 );
                    }

                    TeamTiles[ index ].GetComponent< Image >().color = new Color( 1, 1, 1, 1 );
                }

                node = node.Next;
                index++;
            }

            for ( int i = index; i < TeamTiles.Length; i++ )
            {
                TeamTiles[ index ].GetComponent< Image >().sprite = null;
                TeamTiles[ index ].GetComponent< Image >().color = new Color( 1, 1, 1, 0 );
            }

            index = 0;
            for ( int i = 0; i < _myTeam.Shop.Items.Count; i++ )
            {
                ShopItem item = _myTeam.Shop.Items[ i ];
                if ( item.Pet != null || item.Food != null )
                {
                    ShopTiles[ index ].GetComponent< Image >().sprite = Sprites.First( x => x.name.Equals( item.Pet != null ? ( (PetData.AllPets) item.Pet.PetID ).ToString() : item.Food?.Type.ToString() ) );
                    ShopTiles[ index ].GetComponent< Image >().color = item.Frozen ? new Color( 0, 255, 235 ) : new Color( 255, 255, 255 );
                }

                index++;
            }

            for ( int i = index; i < ShopTiles.Length; i++ )
            {
                ShopTiles[ index ].GetComponent< Image >().sprite = null;
                ShopTiles[ index ].GetComponent< Image >().color = new Color( 1, 1, 1, 0 );
            }
        } else
        {
            _myTeam = GameManager.Instance?.GetTeam( 0 );
        }
    }
}
