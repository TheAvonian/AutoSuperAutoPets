using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Team
{
    public string TeamName;
    public int Health = 10;
    public int Coins = 10;
    public int Wins;
    public LinkedList< PetData > Pets { get; set; } = new();
    public ShopData Shop { get; } = new();

    //Attempts to add a friend to the team at given index
    //Returns true if successful false if unsuccessful
    public bool TryAddFriend( PetData pet, int index )
    {
        if ( Pets.Count >= 5 )
        {
            return false;
        }

        LinkedListNode< PetData > node = Pets.First;
        for ( int i = 0; i <= index && node?.Next != null; i++)
        {
            node = node?.Next;
        }
        
        if ( node != null )
        {
            Pets.AddBefore( node, pet );
        } else
        {
            Pets.AddFirst( pet );
        }

        return true;
    }

    public Team CloneTeam()
    {
        Team tempNew = new();
        foreach ( PetData p in Pets )
        {
            tempNew.Pets.AddLast( new LinkedListNode< PetData >( PetData.PetConstructor((PetData.AllPets)p.PetID) ) );
        }

        tempNew.TeamName = TeamName;
        return tempNew;
    }

    public bool TryPlaceItem( ShopItem shopItem, int targetIndex )
    {
        if ( shopItem == null || ( shopItem.Food == null && shopItem.Pet == null ) ) return false;
        LinkedListNode< PetData > petNode = Pets.First;
        int i;
        for ( i = 0; i <= targetIndex && petNode?.Next != null; i++ )
        {
            petNode = petNode.Next;
        }

        if ( i == targetIndex )
        {
            if ( petNode?.Value.PetID == shopItem.Pet?.PetID )
            {
                petNode?.Value.OnStack(this, shopItem.Pet);
            } else if(shopItem.Food != null)
            {
                petNode?.Value.OnEatShopFood(this, shopItem.Food);
            }
        } else
        {
            if ( Pets.Count < 5 && shopItem.Food == null )
            {
                if ( petNode != null )
                {
                    Pets.AddBefore( petNode, shopItem.Pet );
                } else
                {
                    Pets.AddFirst( shopItem.Pet );
                }
                shopItem.Pet.OnSummon(this);
                shopItem.Pet.OnBuy(this);
            } else
            {
                return false;
            }
        }
        return true;
    }

    public void MovePet( int indexOne, int indexTwo )
    {
        LinkedListNode< PetData > nodeOne = Pets.First;
        LinkedListNode< PetData > nodeTwo = Pets.First;
        if ( nodeOne is null || nodeTwo is null )
        {
            return;
        }
        
        for ( int i = 0; i <= indexOne || i <= indexTwo; i++ )
        {

            if ( i <= indexOne && nodeOne.Next != null )
            {
                nodeOne = nodeOne?.Next;
            }

            if ( i <= indexTwo && nodeTwo.Next != null )
            {
                nodeTwo = nodeTwo?.Next;
            } 
        }
        
        //if one
        if ( ReferenceEquals( nodeOne.Value, nodeTwo.Value ) )
        {
            return;
        }

        PetData tmp = nodeOne.Value;
        if ( indexOne < indexTwo )
        {
            Pets.AddAfter( nodeTwo, tmp );
            Pets.Remove( nodeOne );
        } else
        {
            Pets.AddBefore( nodeTwo, tmp );
            Pets.Remove( nodeOne );
        }
        
        Debug.Log( $"Moved {tmp}" );

        // finish this
    }

    public bool SellPet( int targetIndex )
    {
        LinkedListNode< PetData > node = Pets.First;
        for ( int i = 0; i <= targetIndex; i++ )
        {
            if ( i == targetIndex )
            {
                break;
            }

            node = node?.Next;
        }

        if ( node == null ) return false;
        Pets.Remove( node! );
        return true;
    }

    public override string ToString()
    {
        string endString = $"Team C:{Coins} H:{Health} : ";
        int i = 0;
        foreach ( PetData p in Pets )
        {
            endString += $"Pet {++i}: {p}, ";
        }

        return endString;
    }

    public void UpdatePetPositions() {
        LinkedListNode<PetData> node = Pets.First;
        int position = 1;
        while(node != null) {
            node.Value.Position = position;
            node = node.Next;
        }
    }
}
