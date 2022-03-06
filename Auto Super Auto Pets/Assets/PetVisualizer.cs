using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetVisualizer : MonoBehaviour
{
    public GameObject[] TeamTiles;
    public GameObject[] ShopTiles;

    public Object[] Sprites;

    private Team myTeam;

    private void Awake() {
        Sprites = Resources.LoadAll("Assets/Sprites");
    }

    void Update() {
        if(myTeam != null) {
            LinkedListNode<PetData> node = myTeam.Pets.First;
            int index = 0;

            while(node != null) {

                TeamTiles[index].GetComponent<Image>().sprite = Sprites.Select(x=> x.name == (PetData.AllPets) node.Value.PetID);
            }
        }
    }
}
