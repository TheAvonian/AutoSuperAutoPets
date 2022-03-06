using System;
using System.Collections.Generic;

public class ShopData
{
    
    public List< ShopItem > Items = new(7) { null, null, null, null, null, null, null };
    public void RerollShop(int turn)
    {
        // turn 1, 1 food 3 animal
        // turn 3, tier 2, 2 food
        // turn 5, tier 3, 4 animal
        // turn 7, tier 4
        // turn 9, tier 5, 5 animal
        // turn 11, tier 6

        switch ( turn )
        {
            case >= 11:
            {
                for ( int i = 0; i < 5; i++ )
                {
                    if ( SpotFree(i) )
                    {
                        Items.Insert(i, new ShopItem
                        {
                            Pet = PetData.RandomPet( 6 ),
                        });
                    }
                }

                for ( int i = 5; i < 7; i++ )
                {
                    if ( SpotFree(i) )
                    {
                        Items.Insert(i, new ShopItem
                        {
                            //Food = FoodData.RandomFood(6),
                        });
                    }
                }

                break;
            }
            case >= 9:
            {
                for ( int i = 0; i < 5; i++ )
                {
                    if ( SpotFree(i) )
                    {
                        Items.Insert(i, new ShopItem
                        {
                            Pet = PetData.RandomPet( 5 ),
                        });
                    }
                }

                for ( int i = 5; i < 7; i++ )
                {
                    if ( SpotFree(i) )
                    {
                        Items.Insert(i, new ShopItem
                        {
                            //Food = FoodData.RandomFood(5),
                        });
                    }
                }

                break;
            }
            case >= 7:
            {
                for ( int i = 0; i < 4; i++ )
                {
                    if ( SpotFree(i) )
                    {
                        Items.Insert(i, new ShopItem
                        {
                            Pet = PetData.RandomPet( 4 ),
                        });
                    }
                }

                for ( int i = 4; i < 6; i++ )
                {
                    if ( SpotFree(i) )
                    {
                        Items.Insert(i, new ShopItem
                        {
                            //Food = FoodData.RandomFood(4),
                        });
                    }
                }

                break;
            }
            case >= 5:
            {
                for ( int i = 0; i < 4; i++ )
                {
                    if ( SpotFree(i) )
                    {
                        Items.Insert(i, new ShopItem
                        {
                            Pet = PetData.RandomPet( 3 ),
                        });
                    }
                }

                for ( int i = 4; i < 6; i++ )
                {
                    if ( SpotFree(i) )
                    {
                        Items.Insert(i, new ShopItem
                        {
                            //Food = FoodData.RandomFood(3),
                        });
                    }
                }

                break;
            }
            case >= 3:
            {
                for ( int i = 0; i < 3; i++ )
                {
                    if ( SpotFree(i) )
                    {
                        Items.Insert(i, new ShopItem
                        {
                            Pet = PetData.RandomPet( 2 ),
                        });
                    }
                }

                for ( int i = 3; i < 5; i++ )
                {
                    if ( SpotFree(i) )
                    {
                        Items.Insert(i, new ShopItem
                        {
                            //Food = FoodData.RandomFood(2),
                        });
                    }
                }

                break;
            }
            case >= 1:
            {
                for ( int i = 0; i < 3; i++ )
                {
                    if ( SpotFree(i) )
                    {
                        Items.Insert(i, new ShopItem
                        {
                            Pet = PetData.RandomPet( 1 ),
                        });
                    }
                }

                for ( int i = 3; i < 5; i++ )
                {
                    if ( SpotFree(i) )
                    {
                        Items.Insert(i, new ShopItem
                        {
                            //Food = FoodData.RandomFood(1),
                        });
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
        return Items[index] == null || (index < Items.Count && Items[ index ] != null || index < Items.Count && !Items[ index ].Frozen);
    }
    public ShopItem TryGetItem(int index)
    {
        return Items[ index ];
    }

    public override string ToString()
    {
        string endString = "Shop: ";
        
        foreach ( ShopItem p in Items )
        {
            endString += p?.ToString() ?? "Nothing";
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
}