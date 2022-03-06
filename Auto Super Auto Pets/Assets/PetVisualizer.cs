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
        _myTeam = GameManager.Instance.GetTeam(0);
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
                node = node.Next;
            }

            foreach(ShopItem item in _myTeam.Shop.Items) {
                ShopTiles[ index ].GetComponent< Image >().sprite = Sprites.First( x => x.name.Equals( ( (PetData.AllPets) item.Pet.PetID ).ToString() ) );
            }
        }
    }

    public void SetTeam(Team myteam) {
        _myTeam = myteam;
    }
}
