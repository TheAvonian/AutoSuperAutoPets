using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class ShopData
{
    public ShopItem[] Items = new ShopItem[7];
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

        ReorderShop();
        
        for ( int i = 0; i < Mathf.Clamp((Turn - 1) / 4 + 3, 3, 5 ); i++ )
        {
            if ( SpotFree( i ) )
            {
                Items[i] = new ShopItem
                {
                    Pet = PetData.RandomPet(CurrentTier, false),
                };
            }
        }

        for ( int i = 5; i < Mathf.Clamp((Turn - 1) / 2, 1, 2 ) + 5; i++ )
        {
            if ( SpotFree( i ) )
            {
                Items[i] = new ShopItem
                {
                    Food = FoodData.RandomFood(CurrentTier),
                };
            }
        }
    }

    public ShopItem GetFirst()
    {
        for ( int i = 0; i < 7; i++ )
        {
            if ( Items[ i ] != null )
            {
                return Items[ i ];
            }
        }

        return null;
    }

    void ReorderShop()
    {
        ShopItem[] frozenItems = new ShopItem[ 7 ];
        for ( int i = 0; i < 7; i++ )
        {
            if ( Items[ i ] is {Frozen: true} )
            {
                frozenItems[ i ] = Items[ i ];
            } 
        }

        int petIndex = 0;
        int foodIndex = 5;
        for ( int i = 0; i < 7; i++ )
        {
            Items[ i ] = null;
            switch ( frozenItems[ i ] )
            {
                case {Pet: not null}:
                    Items[ petIndex++ ] = frozenItems[ i ];
                    break;
                case {Food: not null}:
                    Items[ foodIndex++ ] = frozenItems[ i ];
                    break;
            }
        }
    }

    public bool IsEmpty()
    {
        return Items.Any(x=>x != null);
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
        if ( index < Items.Length && Items[ index ] != null )
        {
            if ( Items[ index ].Frozen )
            {
                return false;
            }
        }
        return index < Items.Length && Items[ index ] == null || index >= Items.Length;
    }
    
    public ShopItem TryGetItem( int index )
    {
        return index < Items.Length && index >= 0 ? Items[ index ] : null;
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
        if ( index < Items.Length )
        {
            Items[index] = null;
        }
    }

    public void Freeze( int index )
    {
        if ( index < Items.Length && Items[index] != null )
        {
            Items[ index ].Frozen = !Items[ index ].Frozen;
        }
    }
}

[Serializable]
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
