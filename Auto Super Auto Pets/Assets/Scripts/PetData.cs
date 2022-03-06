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

        foreach(PetData friend in myTeam.Pets){
            friend.OnFriendSold(myTeam);
        }
    }

    public virtual void OnFaint( Team myTeam, Team otherTeam )
    {
        myTeam.Pets.Remove(this);
        foreach(PetData friend in myTeam.Pets) {
            friend.OnFriendFaints(myTeam, otherTeam);
        }
    }

    //Subtracts health the applicable amount and returns the final amount of damage taken
    public virtual int OnHurt( Team myTeam, Team otherTeam, int damageTaken)
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

        if(Health <= 0) {
            this.OnFaint(myTeam, otherTeam);
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
        foreach(PetData friend in myTeam.Pets) {
            friend.OnFriendEatsShopFood(myTeam, this);
        }
    }

    public virtual void OnFriendEatsShopFood(Team myTeam, PetData friend) 
    {

    }

    public virtual void OnTurnStart( Team myTeam )
    {
        
    }

    public virtual void OnTurnEnd( Team myTeam )
    {
        
    }

    public virtual void OnFriendSold(Team myTeam) {

    }

    //Returns true if legal stack, false if not
    //Needs to return false if not the same type of pet??
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
            if(StackHeight == 3 || StackHeight == 6) {
                List<PetData> friends = new(myTeam.Pets);
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
                enemy.OnHurt(otherTeam, myTeam, 1);
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
    public override void OnBuy(Team myTeam)
    {
        base.OnBuy(myTeam);

        int maxHealth = -1;
        foreach(PetData friend in myTeam.Pets) {
            maxHealth = Math.Max(friend.Health, maxHealth);
        }

        this.Health = maxHealth;
    }
}

public class DodoPet : PetData {
    public override void OnBattleStart(Team myTeam, Team otherTeam)
    {
        base.OnBattleStart(myTeam, otherTeam);

        LinkedListNode<PetData> node = myTeam.Pets.Find(this)!.Next;
        if(node != null) {
            PetData friendAhead = node.Value;
            int attackGiven = (int) (this.Damage * 0.5 * this.Level);
            friendAhead.AddDamage(attackGiven);
        }
    }
}

public class ElephantPet : PetData {
    public override void OnBeforeAttack(Team myTeam, Team otherTeam)
    {
        base.OnBeforeAttack(myTeam, otherTeam);

        int numFriendsTargeted = Level;
        LinkedListNode<PetData> node = myTeam.Pets.Find(this)!.Previous;

        while(numFriendsTargeted > 0 && node != null) {
            node.Value.OnHurt(myTeam, otherTeam, 1);
            numFriendsTargeted -= 1;
            node = node.Previous;
        }
    }
}

public class FlamingoPet : PetData {
    public override void OnFaint(Team myTeam, Team otherTeam)
    {
        base.OnFaint(myTeam, otherTeam);

        int numFriendsTargeted = 2;
        LinkedListNode<PetData> node = myTeam.Pets.Find(this)!.Previous;

        while(numFriendsTargeted > 0 && node != null) {
            PetData friend = node.Value;

            friend.AddDamage(1 * Level);
            friend.AddHealth(1 * Level);

            numFriendsTargeted -= 1;
            node = node.Previous;
        }
    }
}

public class HedgehogPet : PetData {
    public override void OnFaint(Team myTeam, Team otherTeam)
    {
        base.OnFaint(myTeam, otherTeam);

        foreach(PetData enemy in otherTeam.Pets) {
            enemy.OnHurt(otherTeam, myTeam, 2 * Level);
        }
        foreach(PetData friend in myTeam.Pets) {
            friend.OnHurt(myTeam, otherTeam, 2 * Level);
        }
    }
}

public class PeacockPet : PetData {

    int charges = 1;

    public override bool OnStack(Team myTeam, PetData pet)
    {
        if(base.OnStack(myTeam, pet)) {
            if(StackHeight == 3 || StackHeight == 6) {
                charges = 1 + (StackHeight / 3);
            }

            return true;
        }
        
        return false;
    }
    public override int OnHurt(Team myTeam, Team otherTeam, int damageTaken)
    {
        damageTaken = base.OnHurt(myTeam, otherTeam, damageTaken);

        if(this.Health >= 0 && damageTaken > 0 && charges > 0) {
            this.AddDamage((int) (this.Damage * 1.5));
            charges -= 1;
        }

        return damageTaken;
    }
}

public class RatPet : PetData {
    public override void OnFaint(Team myTeam, Team otherTeam)
    {
        base.OnFaint(myTeam, otherTeam);

        //Summon Level * 1 dirty rats on opponents team

        //otherTeam.TryAddFriend(dirtyRat, 1);
    }
}

public class ShrimpPet : PetData {
    public override void OnFriendSold(Team myTeam) 
    {
        base.OnFriendSold(myTeam);

        List<PetData> friends = new(myTeam.Pets);

        if(friends.Count > 0) {
            PetData friend = friends.ElementAt(Random.Range(0, friends.Count));
            friend.AddHealth(1 * Level);
        }
    }
}

public class SpiderPet : PetData {
    public override void OnFaint(Team myTeam, Team otherTeam)
    {
        base.OnFaint(myTeam, otherTeam);

        //Create random tier 2 pet at level this.Level

        //myTeam.TryAddFriend(friend, this.Position);
    }
}

public class SwanPet : PetData {
    public override void OnTurnStart(Team myTeam)
    {
        base.OnTurnStart(myTeam);

        myTeam.Coins += Level;
    }
}

public class DogPet : PetData {
    public override void OnFriendSummoned(Team myTeam, PetData summonedFriend)
    {
        base.OnFriendSummoned(myTeam, summonedFriend);

        this.AddDamage(1 * Level);
        this.AddHealth(1 * Level);
    }
}

public class BadgerPet : PetData {
    public override void OnFaint(Team myTeam, Team otherTeam)
    {
        LinkedListNode<PetData> node = myTeam.Pets.Find(this);

        if(node.Next == null) {
            PetData enemy = otherTeam.Pets.First.Value;
            enemy.OnHurt(otherTeam, myTeam, this.Damage);
        } else {
            PetData friendAhead = node.Next.Value;
            friendAhead.OnHurt(myTeam, otherTeam, this.Damage);
        }

        if(node.Previous != null){
            PetData friendBehind = node.Previous.Value;
            friendBehind.OnHurt(myTeam, otherTeam, this.Damage);
        }

        base.OnFaint(myTeam, otherTeam);
    }
}

public class BlowfishPet : PetData {
    public override int OnHurt(Team myTeam, Team otherTeam, int damageTaken)
    {
        damageTaken = base.OnHurt(myTeam, otherTeam, damageTaken);

        if(Health > 0 && damageTaken > 0 && otherTeam.Pets.Count > 0) {
            PetData enemy = otherTeam.Pets.ElementAt(Random.Range(0, otherTeam.Pets.Count));
            enemy.OnHurt(otherTeam, myTeam, 2 * Level);
        }

        return damageTaken;
    }
}

public class CamelPet : PetData {
    public override int OnHurt(Team myTeam, Team otherTeam, int damageTaken) 
    {   
        damageTaken = base.OnHurt(myTeam, otherTeam, damageTaken);

        LinkedListNode<PetData> friendBehind = myTeam.Pets.Find(this).Previous;

        if(Health > 0 && damageTaken > 0 && friendBehind != null) {
            PetData friend = friendBehind.Value;
            friend.AddDamage(1 * Level);
            friend.AddHealth(2 * Level);
        }

        return damageTaken;
    }
    
}

public class GiraffePet : PetData {
    public override void OnTurnEnd(Team myTeam)
    {
        base.OnTurnEnd(myTeam);

        int numFriendsTargeted = Level;
        LinkedListNode<PetData> node = myTeam.Pets.Find(this)!.Next;

        while(numFriendsTargeted > 0 && node != null) {
            PetData friend = node.Value;

            friend.AddDamage(1);
            friend.AddHealth(1);

            numFriendsTargeted -= 1;
            node = node.Next;
        }
    }
}

public class KangarooPet : PetData {
    public override void OnPetAheadAttack(Team myTeam, Team otherTeam)
    {
        base.OnPetAheadAttack(myTeam, otherTeam);

        this.AddDamage(2 * Level);
        this.AddHealth(2 * Level);
    }
}

public class OxPet : PetData {
    public override void OnPetAheadFaint(Team myTeam, Team otherTeam) 
    {
        base.OnPetAheadFaint(myTeam, otherTeam);

        this.AddDamage(2 * Level);
        //Gain melon armor
    }
    
}

public class RabbitPet : PetData {
    public override void OnFriendEatsShopFood(Team myTeam, PetData friend)
    {
        base.OnFriendEatsShopFood(myTeam, friend);

        friend.AddHealth(1 * Level);
    }
}

public class SheepPet : PetData {
    public override void OnFaint(Team myTeam, Team otherTeam)
    {
        base.OnFaint(myTeam, otherTeam);

        //Create two rams at health and attack 2 * Level

        //myTeam.TryAddFriend(ram1, this.Position);
        //myTeam.TryAddFriend(ram2, this.Position);
    }
}

public class SnailPet : PetData {
    public override void OnBuy(Team myTeam)
    {
        foreach(PetData friend in myTeam.Pets) {
            friend.AddDamage(1 * Level);
            friend.AddHealth(1 * Level);
        }

        base.OnBuy(myTeam);
    }
}

public class TurtlePet : PetData {
    public override void OnFaint(Team myTeam, Team otherTeam)
    {
        base.OnFaint(myTeam, otherTeam);

        int numFriendsTargeted = Level;
        LinkedListNode<PetData> node = myTeam.Pets.Find(this)!.Previous;

        while(numFriendsTargeted > 0 && node != null) {
            PetData friend = node.Value;

            friend.Food = FoodData.Food.Melon;

            numFriendsTargeted -= 1;
            node = node.Previous;
        }
    }
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