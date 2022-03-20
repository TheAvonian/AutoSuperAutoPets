using System;
using Random = UnityEngine.Random;

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
        Poison,
    }

    public int Health;
    public int Damage;
    public readonly Food Type;

    public FoodData( Food food )
    {
        Type = food;

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

    public static FoodData RandomFood(int maxTier) {
        Array list = maxTier switch
        {
            1 => Enum.GetValues( typeof( FoodLists.TierOneFood ) ),
            2 => Enum.GetValues( typeof( FoodLists.TierTwoFood ) ),
            3 => Enum.GetValues( typeof( FoodLists.TierThreeFood ) ),
            4 => Enum.GetValues( typeof( FoodLists.TierFourFood ) ),
            5 => Enum.GetValues( typeof( FoodLists.TierFiveFood ) ),
            6 => Enum.GetValues( typeof( FoodLists.TierSixFood ) ),
            _ => throw new ArgumentOutOfRangeException(),
        };
        
        Food randomFood = (Food) list.GetValue( Random.Range( 0, list.Length ) );
        return new FoodData(randomFood);
    }

    public override string ToString()
    {
        return Type.ToString();
    }
}

public class FoodLists {
    public enum TierOneFood {
        Apple = FoodData.Food.Apple,
        Honey = FoodData.Food.Honey,
    }

    public enum TierTwoFood {
        Cupcake = FoodData.Food.Cupcake,
        Meatbone = FoodData.Food.Meatbone,
        Pill = FoodData.Food.Pill,
    }

    public enum TierThreeFood {
        Garlic = FoodData.Food.Garlic,
        Salad = FoodData.Food.Salad,
    }

    public enum TierFourFood {
        CannedFood = FoodData.Food.CannedFood,
        Pear = FoodData.Food.Pear,
    }

    public enum TierFiveFood {
        Chili = FoodData.Food.Chili,
        Chocolate = FoodData.Food.Chocolate,
        Sushi = FoodData.Food.Sushi,
    }

    public enum TierSixFood {
        Melon = FoodData.Food.Melon,
        Mushroom = FoodData.Food.Mushroom,
        Pizza = FoodData.Food.Pizza,
        Steak = FoodData.Food.Steak,
    }
}
