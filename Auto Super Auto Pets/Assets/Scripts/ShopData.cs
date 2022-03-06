using System.Collections.Generic;

public class ShopData
{
    public List< ShopItem > Items = new();
    public void RerollShop(int turn)
    {
        
    }

    public ShopItem TryGetItem(int index)
    {
        return Items[ index ];
    }
}

public class ShopItem
{
    public bool Frozen;
    public PetData Pet;
    public FoodData Food;
}