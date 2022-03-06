public class FoodData
{
    public enum Food {None, Garlic, Honey, Apple, Cupcake, Meatbone, Pill, Salad, CannedFood, Pear, Chili, Chocolate, Sushi, Melon, Mushroom, Pizza, Steak, Milk, Coconut, Poison}

    public int Health;
    public int Damage;
    public Food Type;

    public FoodData(Food food) {
        this.Type = food;

        switch(food) {
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
}