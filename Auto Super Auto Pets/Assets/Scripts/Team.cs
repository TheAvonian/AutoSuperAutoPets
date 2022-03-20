using System;
using UnityEngine;

[Serializable]
public class Team
{
    public string TeamName;
    public int Health = 10;
    public int Coins = 10;
    public int Wins;
    public PetArray Pets = new(5);
    public ShopData Shop = new();

    public Team CloneTeam()
    {
        Team tempNew = new();
        for(int i = 0; i < Pets.Size; i++)
        {
            PetData p = Pets.GetPet(i);
            if(p == null)
            {
                continue;
            }

            tempNew.Pets.TryAddFriend( PetData.PetConstructor((PetData.AllPets)p.PetID), i );
            PetData newP = tempNew.Pets.GetPet(i);
            if ( p.Food != FoodData.Food.None )
            {
                newP.Food = p.Food;
            }

            newP.Damage = p.Damage;
            newP.Health = p.Health;
            newP.BaseDamage = p.BaseDamage;
            newP.BaseHealth = p.BaseHealth;
            newP.Level = p.Level;
            newP.StackHeight = p.StackHeight;
            newP.Position = p.Position;
        }

        tempNew.TeamName = TeamName;
        return tempNew;
    }

    public bool TryPlaceItem( ShopItem shopItem, int targetIndex )
    {
        if ( shopItem == null || shopItem.Food == null && shopItem.Pet == null )
        {
            return false;
        }

        PetData target = Pets.GetPet(targetIndex);

        if ( target != null )
        {
            if ( target.PetID == shopItem.Pet?.PetID )
            {
                if ( target.OnStack( this, shopItem.Pet ) )
                {
                    target.OnBuy(this);
                    Debug.Log( $"Stacked {shopItem.Pet}" );
                }
            } else if(shopItem.Food != null)
            {
                target.OnEatShopFood(this, shopItem.Food);
            } else
            {
                return false;
            }
        } else
        {
            if ( !Pets.IsFull() && shopItem.Food == null )
            {
                Pets.TryAddFriend(shopItem.Pet, targetIndex);
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
        PetData petOne = Pets.GetPet(indexOne);
        PetData petTwo = Pets.GetPet(indexTwo);
        
        if ( ReferenceEquals( petOne, petTwo ))
        {
            return;
        }
        
        if(petOne != null) {
            Pets.RemovePet(petOne);
        }
        if(petTwo != null) {
            Pets.RemovePet(petTwo);
        }

        if(petOne != null) {
            Pets.TryAddFriend(petOne, indexTwo);
        }
        if(petTwo != null) {
            Pets.TryAddFriend(petTwo, indexOne);
        }
    }

    public bool SellPet( int targetIndex )
    {
        PetData pet = Pets.GetPet(targetIndex);

        if ( pet == null )
        {
            return false;
        }

        Pets.RemovePet(pet);
        return true;
    }

    public override string ToString()
    {
        string endString = $"Team C:{Coins} H:{Health} : ";
        
        for(int i = 0; i < Pets.Size; i++) {
            endString += $"Pet {i}: {Pets.GetPet(i)}, ";
        }

        return endString;
    }
}
