using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Team
{
    public int Health;
    public int Coins;
    public int Turn;
    public int Wins;
    public LinkedList< PetData > Pets { get; } = new();
    public ShopData Shop { get; set; }

    //Attempts to add a friend to the team at given index
    //Returns true if successful false if unsuccessful
    public bool TryAddFriend( PetData pet, int index )
    {
        if ( Pets.Count >= 5 )
        {
            return false;
        }

        Pets.AddBefore( Pets.Find( Pets.ElementAt( index ) )!, pet );
        return true;
    }

    public Team CloneTeam()
    {
        Team tempNew = new();
        foreach ( PetData p in Pets )
        {
            tempNew.Pets.AddLast( new LinkedListNode< PetData >( PetData.CloneObject( p ) as PetData ) );
        }

        return tempNew;
    }

    public bool TryPlaceItem( ShopItem shopItem, int actionsDiscreteAction )
    {
        return true;
    }

    public void MovePet( int actionsDiscreteAction, int discreteAction )
    {
        
    }
}
