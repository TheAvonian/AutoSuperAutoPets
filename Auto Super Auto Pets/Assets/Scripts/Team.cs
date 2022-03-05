using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team
{
    public int Health;
    public int Coins;
    public int Turn;
    public LinkedList<PetData> Pets { get; } = new LinkedList<PetData>(new PetData[5]);
    public ShopData Shop { get; set; }

    //Attempts to add a friend to the team at given index
    //Returns true if successful false if unsuccessful
    public bool TryAddFriend(PetData pet, int index) {
        if(Pets.Count >= 5) {
            return false;
        }
        
        List<PetData> friends = new List<PetData>(Pets);
        Pets.AddBefore(Pets.Find(friends[index]), pet);
        return true;
    }
}
