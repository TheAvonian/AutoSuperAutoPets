public abstract class FoodData
{
    public enum Food {None, Garlic, Honey, Apple, Cupcake, Meatbone, Pill, Salad, CannedFood, Pear, Chili, Chocolate, Sushi, Melon, Mushroom, Pizza, Steak, Milk, Coconut}

    public virtual void OnEat(Team myTeam, PetData pet) {
        
    }
    
    public override string ToString()
    {
        return "";
    }
}