using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public abstract class PetData
{
    public Image Image;
    public int Health;
    public int Damage;
    public int Level;
    public int StackHeight;
    public int Position;
    public FoodData.Food Food;

    public static object CloneObject(object objSource)
    {
        //step : 1 Get the type of source object and create a new instance of that type
        Type typeSource = objSource.GetType();
        object objTarget = Activator.CreateInstance(typeSource);
        //Step2 : Get all the properties of source object type
        PropertyInfo[] propertyInfo = typeSource.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        //Step : 3 Assign all source property to taget object 's properties
        foreach (PropertyInfo property in propertyInfo)
        {
            //Check whether property can be written to
            if (property.CanWrite)
            {
                //Step : 4 check whether property type is value type, enum or string type
                if (property.PropertyType.IsValueType || property.PropertyType.IsEnum || property.PropertyType == typeof(string))
                {
                    property.SetValue(objTarget, property.GetValue(objSource, null), null);
                }
                //else property type is object/complex types, so need to recursively call this method until the end of the tree is reached
                else
                {
                    object objPropertyValue = property.GetValue(objSource, null);
                    property.SetValue( objTarget, objPropertyValue == null ? null : CloneObject( objPropertyValue ), null );
                }
            }
        }
        return objTarget;
    }

    public void AddHealth(int amountGiven) {
        this.Health += amountGiven;
        if(this.Health > 50) {
            this.Health = 50;
        }
    }

    public void AddDamage(int amountGiven) {
        this.Damage += amountGiven;
        if(this.Health > 50) {
            this.Damage = 50;
        }
    }
    
    public virtual void OnBuy( Team myTeam )
    {
        foreach(PetData friend in myTeam.Pets) {
            if(friend == this) continue;
            friend.OnFriendSummoned(myTeam, null);
        }
    }

    public virtual void OnSell( Team myTeam )
    {
        myTeam.Pets.Remove(this);
        myTeam.Coins += Level;
    }

    public virtual void OnFaint( Team myTeam, Team otherTeam )
    {
        myTeam.Pets.Remove(this);
        foreach(PetData friend in myTeam.Pets) {
            friend.OnFriendFaints(myTeam, otherTeam);
        }
    }

    //Subtracts health the applicable amount and returns the final amount of damage taken
    public virtual int OnHurt( Team myTeam, int damageTaken)
    {
        if(this.Food == FoodData.Food.Garlic) {
            damageTaken -= 2;
            if(damageTaken <= 0) damageTaken = 1;
        } else if(this.Food == FoodData.Food.Melon) {
            damageTaken -= 20;
            if(damageTaken < 0) damageTaken = 0;
        }

        if(damageTaken > 0) {
            Health -= damageTaken;
        }

        return damageTaken;
    }

    public virtual void OnBeforeAttack( Team myTeam, Team otherTeam )
    {

    }

    public virtual void OnPetAheadAttack( Team myTeam, Team otherTeam )
    {

    }

    public virtual void OnPetAheadFaint( Team myTeam, Team otherTeam )
    {

    }

    public virtual void OnBattleStart( Team myTeam, Team otherTeam )
    {

    }

    public virtual void OnFriendSummoned( Team myTeam, PetData summonedFriend )
    {

    }

    public virtual void OnFaintEnemy( Team myTeam, Team otherTeam )
    {

    }

    public virtual void OnFriendFaints( Team myTeam, Team otherTeam )
    {

    }

    public virtual void OnEatShopFood(Team myTeam, FoodData food)
    {

    }

    public virtual void OnTurnStart( Team myTeam )
    {
        
    }

    public virtual void OnTurnEnd( Team myTeam )
    {
        
    }

    //Returns true if legal stack, false if not
    public virtual bool OnStack(Team myTeam, PetData pet)
    {
        if(StackHeight >= 6 || pet.StackHeight == 0) return false;

        //Stacks all copies of pets stacked on it.
        pet.StackHeight -= 1;
        this.OnStack(myTeam, pet);

        StackHeight += 1;

        this.Health = Math.Max(pet.Health, this.Health) + 1;
        this.Damage = Math.Max(pet.Damage, this.Damage) + 1;

        if(StackHeight == 3 || StackHeight == 6) {
            Level += 1;
        }

        return true;
    }
}

public class AntPet : PetData 
{
    public override void OnFaint(Team myTeam, Team otherTeam)
    {
        base.OnFaint(myTeam, otherTeam);

        PetData randomFriend = myTeam.Pets.ElementAt( Random.Range( 0, myTeam.Pets.Count ) );
        randomFriend.Damage += 2 * Level;
        randomFriend.Health += 1 * Level;
    }
}

public class BeaverPet : PetData {
    public override void OnSell(Team myTeam)
    {
        base.OnSell(myTeam);

        List<PetData> friends = new List<PetData>(myTeam.Pets);

        if(friends.Count >= 2) {
            PetData friend1 = friends[Random.Range(0, friends.Count)];
            friends.Remove(friend1);
            PetData friend2 = friends[Random.Range(0, friends.Count)];

            friend1.Health += 1 * Level;
            friend2.Health += 1 * Level;
        } else if (friends.Count == 1) {
            friends[0].Health += 1 * Level;
        }
    }
}

public class CricketPet : PetData {
    public override void OnFaint(Team myTeam, Team otherTeam)
    {
        base.OnFaint(myTeam, otherTeam);

        //Create zombie cricket and add it to the team

        //myTeam.TryAddFriend();
    }
}

public class DuckPet : PetData {
    public override void OnSell(Team myTeam)
    {
        base.OnSell(myTeam);

        //Give current shop pets +1*level health
        //myTeam.Shop(); 
    }
}

public class FishPet : PetData {
    public override bool OnStack(Team myTeam, PetData pet)
    {
        if(base.OnStack(myTeam, pet)) {
            if(this.StackHeight == 3 || this.StackHeight == 6) {
                List<PetData> friends = new List<PetData>(myTeam.Pets);
                friends.Remove(this);

                foreach(PetData friend in friends)
                {
                    friend.Health += 1 * Level;
                    friend.Damage += 1 * Level;
                }
            }

            return true;
        }
        
        return false;
    }
}

public class HorsePet : PetData {
    public override void OnFriendSummoned(Team myTeam, PetData summonedFriend)
    {
        base.OnFriendSummoned(myTeam, summonedFriend);

        summonedFriend.Damage += 1 * Level;
    }
}

public class MosquitoPet : PetData {
    public override void OnBattleStart(Team myTeam, Team otherTeam)
    {
        base.OnBattleStart(myTeam, otherTeam);

        if(otherTeam.Pets.Count >= 1) {
            for(int i = 0; i < Level; i++) {
                PetData enemy = otherTeam.Pets.ElementAt(Random.Range( 0, myTeam.Pets.Count ) );
                enemy.OnHurt(otherTeam, 1);
            }
        }
    }
}

public class OtterPet : PetData {
    public override void OnBuy(Team myTeam)
    {
        base.OnBuy(myTeam);

        List<PetData> friends = new List<PetData>(myTeam.Pets);
        friends.Remove(this);

        PetData friend = friends.ElementAt(Random.Range(0, friends.Count));
        friend.AddDamage(1 * Level);
        friend.AddHealth(1 * Level);
    }
}

public class PigPet : PetData {
    public override void OnSell(Team myTeam)
    {
        base.OnSell(myTeam);

        myTeam.Coins += Level;
    }
}

public class CrabPet : PetData {
    
}

public class DodoPet : PetData {
    
}

public class ElephantPet : PetData {
    
}

public class FlamingoPet : PetData {
    
}

public class HedgehogPet : PetData {
    
}

public class PeacockPet : PetData {
    
}

public class RatPet : PetData {
    
}

public class ShrimpPet : PetData {
    
}

public class SpiderPet : PetData {
    
}

public class SwanPet : PetData {
    
}

public class DogPet : PetData {
    
}

public class BadgerPet : PetData {
    
}

public class BlowfishPet : PetData {
    
}

public class CamelPet : PetData {
    
}

public class GiraffePet : PetData {
    
}

public class KangarooPet : PetData {
    
}

public class OxPet : PetData {
    
}

public class RabbitPet : PetData {
    
}

public class SheepPet : PetData {
    
}

public class SnailPet : PetData {
    
}

public class TurtlePet : PetData {
    
}

public class WhalePet : PetData {
    
}

public class BisonPet : PetData {
    
}

public class DeerPet : PetData {
    
}

public class DolphinPet : PetData {
    
}

public class HippoPet : PetData {
    
}

public class PenguinPet : PetData {
    
}

public class RoosterPet : PetData {
    
}

public class SkunkPet : PetData {
    
}

public class SquirrelPet : PetData {
    
}

public class WormPet : PetData {
    
}

public class ParrotPet : PetData {
    
}

public class MonkeyPet : PetData {
    
}

public class CowPet : PetData {
    
}

public class CrocodilePet : PetData {
    
}

public class RhinoPet : PetData {
    
}

public class ScorpionPet : PetData {
    
}

public class SealPet : PetData {
    
}

public class SharkPet : PetData {
    
}

public class TurkeyPet : PetData {
    
}

public class CatPet : PetData {
    
}

public class BoarPet : PetData {
    
}

public class DragonPet : PetData {
    
}

public class FlyPet : PetData {
    
}

public class GorillaPet : PetData {
    
}

public class LeopardPet : PetData {
    
}

public class MammothPet : PetData {
    
}

public class SnakePet : PetData {
    
}

public class TigerPet : PetData {
    
}