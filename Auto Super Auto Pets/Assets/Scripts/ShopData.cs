using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShopData
{
    public List< ShopItem > Items = new();
    public int HealthModifier = 0;
    public int DamageModifier = 0;

    public List<PetData> PetsList = new List<PetData>(PetData.TierOnePets);
    public List<FoodData.Food> FoodList = new List<FoodData.Food>(FoodData.TierOneFood);
    public void RerollShop( int turn )
    {
        // turn 1, 1 food 3 animal
        // turn 3, tier 2, 2 food
        // turn 5, tier 3, 4 animal
        // turn 7, tier 4
        // turn 9, tier 5, 5 animal
        // turn 11, tier 6

        Items.RemoveAll( x => x is {Frozen: false} );
        
        for ( int i = 0; i < 5; i++ )
        {
            if ( SpotFree( i ) )
            {
                Items.Add( new ShopItem
                {
                    Pet = RandomPet(),
                } );
            }
        }

        for ( int i = 5; i < 7; i++ )
        {
            if ( SpotFree( i ) )
            {
                Items.Add( new ShopItem
                {
                    Food = RandomFood(),
                } );
            }
        }
    }

    bool SpotFree( int index )
    {
        return ( index < Items.Count && Items[ index ] == null ) || index >= Items.Count;
    }

    public void UpdateAvailableTiers(int turn) {
        if ( turn > 1 )
        {
            PetsList.AddRange( PetData.TierTwoPets );
            FoodList.AddRange( FoodData.TierTwoFood );
        }

        if ( turn > 2 )
        {
            PetsList.AddRange( PetData.TierThreePets );
            FoodList.AddRange( FoodData.TierThreeFood );
        }

        if ( turn > 3 )
        {
            PetsList.AddRange( PetData.TierFourPets );
            FoodList.AddRange( FoodData.TierFourFood );
        }

        if ( turn > 4 )
        {
            PetsList.AddRange( PetData.TierFivePets );
            FoodList.AddRange( FoodData.TierFiveFood );
        }

        if ( turn > 5 )
        {
            PetsList.AddRange( PetData.TierSixPets );
            FoodList.AddRange( FoodData.TierSixFood );
        }
    }

    public PetData RandomPet() {
        return PetData.CloneObject(PetsList[Random.Range(0, PetsList.Count)]) as PetData;
    }

    public FoodData RandomFood() {
        return new FoodData(FoodList[Random.Range(0, FoodList.Count)]);
    }

    
    public ShopItem TryGetItem( int index )
    {
        return index < Items.Count && index > 0 ? Items[ index ] ?? new ShopItem() : new ShopItem();
    }

    public override string ToString()
    {
        string endString = "Shop: ";

        foreach ( ShopItem p in Items )
        {
            endString += p?.ToString();
            endString += ", ";
        }

        return endString;
    }

    public void RemoveItem( int index )
    {
        if ( index < Items.Count )
        {
            Items.RemoveAt(index);
        }
    }
}

public class ShopItem
{
    public bool Frozen;
    public PetData Pet;
    public FoodData Food;

    public override string ToString()
    {
        return ( Pet?.ToString() ?? Food?.ToString() ?? "Nothing" ) + (Frozen ? " is Frozen" : "");
    }
}
