using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopData
{
    public List< ShopItem > Items = new();
    public int HealthModifier = 0;
    public int DamageModifier = 0;
    public void RerollShop( int turn )
    {
        // turn 1, 1 food 3 animal
        // turn 3, tier 2, 2 food
        // turn 5, tier 3, 4 animal
        // turn 7, tier 4
        // turn 9, tier 5, 5 animal
        // turn 11, tier 6

        Items.RemoveAll( x => x is {Frozen: false} );
        switch ( turn )
        {
            case >= 11:
            {
                for ( int i = 0; i < 5; i++ )
                {
                    if ( SpotFree( i ) )
                    {
                        Items.Add( new ShopItem
                        {
                            Pet = PetData.RandomPet( 6 ),
                        } );
                    }
                }

                for ( int i = 5; i < 7; i++ )
                {
                    if ( SpotFree( i ) )
                    {
                        Items.Add( new ShopItem
                        {
                            //Food = FoodData.RandomFood(6),
                        } );
                    }
                }

                break;
            }
            case >= 9:
            {
                for ( int i = 0; i < 5; i++ )
                {
                    if ( SpotFree( i ) )
                    {
                        Items.Add( new ShopItem
                        {
                            Pet = PetData.RandomPet( 5 ),
                        } );
                    }
                }

                for ( int i = 5; i < 7; i++ )
                {
                    if ( SpotFree( i ) )
                    {
                        Items.Add( new ShopItem
                        {
                            //Food = FoodData.RandomFood(5),
                        } );
                    }
                }

                break;
            }
            case >= 7:
            {
                for ( int i = 0; i < 4; i++ )
                {
                    if ( SpotFree( i ) )
                    {
                        Items.Add( new ShopItem
                        {
                            Pet = PetData.RandomPet( 4 ),
                        } );
                    }
                }

                for ( int i = 4; i < 6; i++ )
                {
                    if ( SpotFree( i ) )
                    {
                        Items.Add( new ShopItem
                        {
                            //Food = FoodData.RandomFood(4),
                        } );
                    }
                }

                break;
            }
            case >= 5:
            {
                for ( int i = 0; i < 4; i++ )
                {
                    if ( SpotFree( i ) )
                    {
                        Items.Add( new ShopItem
                        {
                            Pet = PetData.RandomPet( 3 ),
                        } );
                    }
                }

                for ( int i = 4; i < 6; i++ )
                {
                    if ( SpotFree( i ) )
                    {
                        Items.Add( new ShopItem
                        {
                            //Food = FoodData.RandomFood(3),
                        } );
                    }
                }

                break;
            }
            case >= 3:
            {
                for ( int i = 0; i < 3; i++ )
                {
                    if ( SpotFree( i ) )
                    {
                        Items.Add( new ShopItem
                        {
                            Pet = PetData.RandomPet( 2 ),
                        } );
                    }
                }

                for ( int i = 3; i < 5; i++ )
                {
                    if ( SpotFree( i ) )
                    {
                        Items.Add( new ShopItem
                        {
                            //Food = FoodData.RandomFood(2),
                        } );
                    }
                }

                break;
            }
            case >= 1:
            {
                for ( int i = 0; i < 3; i++ )
                {
                    if ( SpotFree( i ) )
                    {
                        ShopItem p = new()
                        {
                            Pet = PetData.RandomPet( 1 ),
                        };
                        
                        Debug.Log( p );
                        Items.Add( p );
                    }
                }

                for ( int i = 3; i < 5; i++ )
                {
                    if ( SpotFree( i ) )
                    {
                        Items.Add( new ShopItem
                        {
                            //Food = FoodData.RandomFood(1),
                        } );
                    }
                }

                break;
            }
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    bool SpotFree( int index )
    {
        return ( index < Items.Count && Items[ index ] == null ) || index >= Items.Count;
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
