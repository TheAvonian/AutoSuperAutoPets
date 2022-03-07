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
        Sprites = Resources.LoadAll( "Pets", typeof( Sprite ) ).Cast<Sprite>().ToArray();
    }

    void Update()
    {
        if ( _myTeam != null )
        {
            LinkedListNode< PetData > node = _myTeam.Pets.Last;
            int index = 0;

            while ( node != null )
            {
                TeamTiles[ index ].GetComponent< Image >().sprite = Sprites.First( x => x.name.Equals( ( (PetData.AllPets) node.Value.PetID ).ToString() ) );
                node = node.Previous;
                index++;
            }

            index = 0;
            foreach(ShopItem item in _myTeam.Shop.Items) {
                ShopTiles[ index ].GetComponent< Image >().sprite = Sprites.First( x => x.name.Equals( item.Pet != null ? ((PetData.AllPets) item.Pet.PetID ).ToString() : item.Food?.Type.ToString()));
                index++;
            }

            for ( int i = index; i < ShopTiles.Length; i++ )
            {
                ShopTiles[ index ].GetComponent< Image >().sprite = null;
            }
        } else
        {
            _myTeam = GameManager.Instance?.GetTeam( 0 );
        }
    }
}
