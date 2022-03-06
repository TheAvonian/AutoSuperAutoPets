using System;
using System.Collections.Generic;
using System.Reflection;

public class FoodData
{
    public enum Food
    {
        None,
        Garlic,
        Honey,
        Apple,
        Cupcake,
        Meatbone,
        Pill,
        Salad,
        CannedFood,
        Pear,
        Chili,
        Chocolate,
        Sushi,
        Melon,
        Mushroom,
        Pizza,
        Steak,
        Milk,
        Coconut,
        Poison
    }

    public static List<Food> TierOneFood {get;} = new() {
        Food.Apple,
        Food.Honey
    };

    public static List<Food> TierTwoFood { get; } = new() {
        Food.Cupcake,
        Food.Meatbone,
        Food.Pill
    };

    public static List<Food> TierThreeFood { get; } = new() {
        Food.Garlic,
        Food.Salad
    };

    public static List<Food> TierFourFood { get; } = new() {
        Food.CannedFood,
        Food.Pear
    };

    public static List<Food> TierFiveFood { get; } = new() {
        Food.Chili,
        Food.Chocolate,
        Food.Sushi
    };

    public static List<Food> TierSixFood { get; } = new() {
        Food.Melon,
        Food.Pizza,
        Food.Steak,
        Food.Mushroom
    };

    public int Health;
    public int Damage;
    public Food Type;

    public FoodData( Food food )
    {
        this.Type = food;

        switch ( food )
        {
            case Food.Apple:
                Health = 1;
                Damage = 1;
                break;
            case Food.Cupcake:
                Health = 3;
                Damage = 3;
                break;
            case Food.Pear:
                Health = 2;
                Damage = 2;
                break;
            case Food.Milk:
                Health = 2;
                Damage = 1;
                break;
            default:
                Health = 0;
                Damage = 0;
                break;
        }
    }

    public override string ToString()
    {
        return Type.ToString();
    }
}
