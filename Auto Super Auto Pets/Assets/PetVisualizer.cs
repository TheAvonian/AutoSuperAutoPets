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

    void Awake()
    {
        Sprites = (Sprite[]) Resources.LoadAll( "Assets/Sprites", typeof( Sprite ) );
    }

    void Update()
    {
        if ( _myTeam != null )
        {
            LinkedListNode< PetData > node = _myTeam.Pets.First;
            int index = 0;

            while ( node != null )
            {

                TeamTiles[ index ].GetComponent< Image >().sprite = Sprites.First( x => x.name.Equals( ( (PetData.AllPets) node.Value.PetID ).ToString() ) );
            }
        }
    }
}
