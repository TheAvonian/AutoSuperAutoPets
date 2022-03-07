﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShopData
{
    public List< ShopItem > Items = new();
    public int HealthModifier = 0;
    public int DamageModifier = 0;
    public int Turn = 0;
    public int CurrentTier = 1;
    public void RerollShop()
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
                    Pet = PetData.RandomPet(CurrentTier, false),
                } );
            }
        }

        for ( int i = 5; i < 7; i++ )
        {
            if ( SpotFree( i ) )
            {
                Items.Add( new ShopItem
                {
                    Food = FoodData.RandomFood(CurrentTier),
                } );
            }
        }
    }

    public void IncrementTurn() {
        Turn += 1;

        if(Turn is 3 or 5 or 7 or 9 or 11)
        {
            CurrentTier += 1;
        }
    }

    bool SpotFree( int index )
    {
        if ( index < Items.Count && Items[ index ] != null )
        {
            if ( Items[ index ].Frozen )
            {
                return false;
            }
        }
        return index < Items.Count && Items[ index ] == null || index >= Items.Count;
    }
    
    public ShopItem TryGetItem( int index )
    {
        return index < Items.Count && index > 0 ? Items[ index ] : null;
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

    public void Freeze( int index )
    {
        if ( index < Items.Count && Items[index] != null )
        {
            Items[ index ].Frozen = !Items[ index ].Frozen;
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
