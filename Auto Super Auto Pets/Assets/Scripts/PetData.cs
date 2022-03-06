using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public abstract class PetData
{
    public int PetID;

    public enum AllPets {
        Ant, Beaver, Cricket, Duck, Fish, Horse, Mosquito, Otter, Pig, 
        Crab, Dodo, Elephant, Flamingo, Hedgehog, Peacock, Rat, Shrimp, Spider, Swan, 
        Dog, Badger, Blowfish, Camel, Giraffe, Kangaroo, Ox, Rabbit, Sheep, Snail, Turtle,
        Whale, Bison, Deer, Dolphin, Hippo, Penguin, Rootser, Skunk, Squirrel, Worm, Parrot,
        Monkey, Cow, Crocodile, Rhino, Scorpion, Seal, Shark, Turkey,
        Cat, Boar, Dragon, Fly, Gorilla, Leopard, Mammoth, Snake, Tiger
    }

    public enum TierOnePets {Ant = AllPets.Ant, Beaver = AllPets.Beaver, Cricket = AllPets.Cricket, Duck = AllPets.Duck, Fish = AllPets.Fish, Horse = AllPets.Horse, Mosquito = AllPets.Mosquito, Otter = AllPets.Otter, Pig = AllPets.Pig}
    public enum TierTwoPets {Crab = AllPets.Crab, Dodo = AllPets.Dodo, Elephant = AllPets.Elephant, Flamingo = AllPets.Flamingo, Hedgehog = AllPets.Hedgehog, Peacock = AllPets.Peacock, Rat = AllPets.Rat, Shrimp = AllPets.Shrimp, Spider = AllPets.Shrimp, Swan = AllPets.Swan}
    public enum TierThreePets {Dog = AllPets.Dog, Badger = AllPets.Badger, Blowfish = AllPets.Blowfish, Camel = AllPets.Camel, Giraffe = AllPets.Giraffe, Kangaroo = AllPets.Kangaroo, Ox = AllPets.Ox, Rabbit = AllPets.Rabbit, Sheep = AllPets.Sheep, Snail = AllPets.Snail, Turtle = AllPets.Turtle}
    public enum TierFourPets {Whale = AllPets.Whale, Bison = AllPets.Bison, Deer = AllPets.Deer, Dolphin = AllPets.Dolphin, Hippo = AllPets.Hippo, Penguin = AllPets.Penguin, Rootser = AllPets.Rootser, Skunk = AllPets.Skunk, Squirrel = AllPets.Squirrel, Worm = AllPets.Worm, Parrot = AllPets.Parrot}
    public enum TierFivePets {Monkey = AllPets.Monkey, Cow = AllPets.Cow, Crocodile = AllPets.Crocodile, Rhino = AllPets.Rhino, Scorpion = AllPets.Scorpion, Seal = AllPets.Seal, Shark = AllPets.Shark, Turkey = AllPets.Turkey}
    public enum TierSixPets {Cat = AllPets.Cat, Boar = AllPets.Boar, Dragon = AllPets.Dragon, Fly = AllPets.Fly, Gorilla = AllPets.Gorilla, Leopard = AllPets.Leopard, Mammoth = AllPets.Mammoth, Snake = AllPets.Snake, Tiger = AllPets.Tiger}

    public static PetData PetConstructor(PetData.AllPets petType) {
        return petType switch {
            AllPets.Ant => new AntPet { PetID = 0, Health = 1, Damage = 2, },
            AllPets.Beaver =>  new BeaverPet { PetID = 2, Health = 2, Damage = 2, },
            AllPets.Cricket => new CricketPet { PetID = 3, Damage = 1, Health = 2, },
            AllPets.Duck => new DuckPet { PetID = 4, Damage = 1, Health = 3, },
            AllPets.Fish => new FishPet { PetID = 5, Health = 3, Damage = 2, },
            AllPets.Horse => new HorsePet { PetID = 6, Damage = 2, Health = 1, },
            AllPets.Mosquito => new MosquitoPet { PetID = 7, Damage = 2, Health = 2, },
            AllPets.Otter =>new OtterPet { PetID = 8, Damage = 1, Health = 2, },
            AllPets.Pig => new PigPet { PetID = 9, Damage = 3, Health = 2, },
            AllPets.Crab => new CrabPet { PetID = 10, Damage = 3, Health = 3, },
            AllPets.Dodo => new DodoPet { PetID = 11, Damage = 2, Health = 3, },
            AllPets.Elephant => new ElephantPet { PetID = 12, Damage = 3, Health = 5, },
            AllPets.Flamingo => new FlamingoPet { PetID = 13, Damage = 3, Health = 1, },
            AllPets.Hedgehog => new HedgehogPet { PetID = 14, Damage = 3, Health = 2, },
            AllPets.Peacock => new PeacockPet { PetID = 15, Damage = 1, Health = 5, },
            AllPets.Rat => new RatPet { PetID = 16, Damage = 4, Health = 5, },
            AllPets.Shrimp => new ShrimpPet { PetID = 17, Damage = 2, Health = 5, },
            AllPets.Spider => new SpiderPet { PetID = 18, Damage = 2, Health = 2, },
            AllPets.Swan => new SwanPet { PetID = 19, Damage = 1, Health = 3, },
            AllPets.Dog => new DogPet { PetID = 20, Damage = 2, Health = 2, },
            AllPets.Badger => new BadgerPet { PetID = 21, Damage = 5, Health = 4, },
            AllPets.Blowfish => new BlowfishPet { PetID = 22, Damage = 3, Health = 5, },
            AllPets.Camel => new CamelPet { PetID = 23, Damage = 2, Health = 5, },
            AllPets.Giraffe => new GiraffePet { PetID = 24, Damage = 2, Health = 5, },
            AllPets.Kangaroo => new KangarooPet { PetID = 25, Health = 2, Damage = 1, },
            AllPets.Ox => new OxPet { PetID = 26, Damage = 1, Health = 4, },
            AllPets.Rabbit => new RabbitPet { PetID = 27, Damage = 3, Health = 2, },
            AllPets.Sheep => new SheepPet { PetID = 28, Damage = 2, Health = 2, },
            AllPets.Snail => new SnailPet { PetID = 29, Damage = 2, Health = 2, },
            AllPets.Turtle => new TurtlePet { PetID = 30, Damage = 1, Health = 2, },
            AllPets.Whale => new WhalePet { PetID = 31, Damage = 3, Health = 8, },
            AllPets.Bison => new BisonPet { PetID = 32, Damage = 6, Health = 6, },
            AllPets.Deer => new DeerPet { PetID = 33, Health = 1, Damage = 1, },
            AllPets.Dolphin => new DolphinPet { PetID = 34, Damage = 4, Health = 6, },
            AllPets.Hippo => new HippoPet { PetID = 35, Damage = 4, Health = 7, },
            AllPets.Penguin => new PenguinPet { PetID = 36, Damage = 1, Health = 2, },
            AllPets.Rootser => new RoosterPet { PetID = 37, Damage = 5, Health = 3, },
            AllPets.Skunk => new SkunkPet { PetID = 38, Damage = 3, Health = 6, },
            AllPets.Squirrel => new SquirrelPet { PetID = 39, Damage = 2, Health = 2, },
            AllPets.Worm => new WormPet { PetID = 40, Damage = 2, Health = 2, },
            AllPets.Parrot => new ParrotPet { PetID = 41, Damage = 5, Health = 3, },
            AllPets.Monkey => new MonkeyPet { PetID = 42, Damage = 1, Health = 2, },
            AllPets.Cow => new CowPet { PetID = 43, Damage = 4, Health = 6, },
            AllPets.Crocodile => new CrocodilePet { PetID = 44, Damage = 8, Health = 4, },
            AllPets.Rhino => new RhinoPet { PetID = 45, Damage = 5, Health = 8, },
            AllPets.Scorpion => new ScorpionPet { PetID = 46, Damage = 1, Health = 1, },
            AllPets.Seal => new SealPet { PetID = 47, Damage = 3, Health = 8, },
            AllPets.Shark => new SharkPet { PetID = 48, Damage = 4, Health = 4, },
            AllPets.Turkey => new TurkeyPet { PetID = 49, Damage = 3, Health = 4, },
            AllPets.Cat => new CatPet { PetID = 50, Damage = 4, Health = 5, },
            AllPets.Boar => new BoarPet { PetID = 51, Damage = 8, Health = 6, },
            AllPets.Dragon => new DragonPet { PetID = 52, Damage = 6, Health = 8, },
            AllPets.Fly => new FlyPet { PetID = 53, Damage = 5, Health = 5, },
            AllPets.Gorilla => new GorillaPet { PetID = 54, Damage = 6, Health = 9, },
            AllPets.Leopard => new LeopardPet { PetID = 55, Damage = 10, Health = 4, },
            AllPets.Mammoth => new MammothPet { PetID = 56, Damage = 3, Health = 10, },
            AllPets.Snake => new SnakePet { PetID = 57, Damage = 6, Health = 6, },
            AllPets.Tiger => new TigerPet { PetID = 58, Damage = 4, Health = 3, },
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static PetData RandomPet(int tier) {
        var list = tier switch {
            1 => Enum.GetValues( typeof(TierOnePets) ),
            2 => Enum.GetValues( typeof(TierTwoPets) ),
            3 => Enum.GetValues( typeof(TierThreePets) ),
            4 => Enum.GetValues( typeof(TierFourPets) ),
            5 => Enum.GetValues( typeof(TierFivePets) ),
            6 => Enum.GetValues( typeof(TierSixPets) ),
            _ => throw new ArgumentOutOfRangeException()
        };
            
        AllPets randomPet = (AllPets) list.GetValue(Random.Range(0, list.Length));
        return PetConstructor(randomPet);
    }

    public int Health;
    public int BaseHealth;
    public int Damage;
    public int BaseDamage;
    public int Level = 1;
    public int StackHeight = 1;
    public int Position = -1;
    public FoodData.Food Food;

    protected PetData()
    {
        
    }

    public override string ToString()
    {
        return $"D:{Damage} H:{Health} ID:{PetID}";
    }

    public void AddHealth( int amountGiven, bool temp = false)
    {
        if(!temp) this.BaseHealth += amountGiven;
        this.Health += amountGiven;
        if ( this.Health > 50 )
        {
            this.Health = 50;
        }
        if(this.BaseHealth > 50) {
            this.BaseHealth = 50;
        }
    }

    public void AddDamage(int amountGiven, bool temp = false) {
        if(!temp) this.BaseDamage += amountGiven;
        this.Damage += amountGiven;
        if ( this.Health > 50 )
        {
            this.Damage = 50;
        }
        if(this.BaseDamage > 50) {
            this.BaseDamage = 50;
        }
    }

    public void ReduceHealth( double reductionPercent )
    {
        this.Health = (int) Math.Ceiling( this.Health * reductionPercent );
    }

    public virtual void OnBuy( Team myTeam )
    {
        
    }

    public virtual void OnSell( Team myTeam )
    {
        myTeam.Pets.Remove( this );
        myTeam.Coins += Level;

        foreach ( PetData friend in myTeam.Pets )
        {
            friend.OnFriendSold( myTeam );
        }
    }

    
    public virtual void OnFaint( Team myTeam, Team otherTeam )
    {
        myTeam.Pets.Remove(this);

        if(this.Food == FoodData.Food.Honey) {
            myTeam.TryAddFriend(new BeePet { BaseHealth = 1, BaseDamage = 1, Health = 1, Damage = 1 }, this.Position);
        } else if (this.Food == FoodData.Food.Mushroom) {
            PetData selfCopy = CloneObject(this) as PetData;
            selfCopy.Health = 1;
            selfCopy.BaseHealth = 1;
            selfCopy.Damage = 1;
            selfCopy.BaseDamage = 1;
            selfCopy.Food = FoodData.Food.None;
            if(myTeam.TryAddFriend(selfCopy, this.Position)) selfCopy.OnSummon(myTeam);
        }

        foreach(PetData friend in myTeam.Pets) {
            friend.OnFriendFaints(myTeam, otherTeam, this);
        }
    }

    //Subtracts health the applicable amount and returns the final amount of damage taken
    public virtual int OnHurt( Team myTeam, Team otherTeam, int damageTaken )
    {
        if ( this.Food == FoodData.Food.Garlic )
        {
            damageTaken -= 2;
            if ( damageTaken <= 0 ) damageTaken = 1;
        } else if ( this.Food == FoodData.Food.Melon )
        {
            damageTaken -= 20;
            if ( damageTaken < 0 ) damageTaken = 0;
            this.Food = FoodData.Food.None;
        } else if ( this.Food == FoodData.Food.Coconut )
        {
            damageTaken = 0;
            this.Food = FoodData.Food.None;
        }

        if ( damageTaken > 0 )
        {
            Health -= damageTaken;
        }

        if ( Health <= 0 )
        {
            this.OnFaint( myTeam, otherTeam );
        }

        return damageTaken;
    }

    public virtual void OnAttack( Team myTeam, Team otherTeam )
    {
        this.OnBeforeAttack( myTeam, otherTeam );

        int attack = this.Damage;
        if(this.Food == FoodData.Food.Meatbone) attack += 5;
        else if(this.Food == FoodData.Food.Steak) {
            attack += 20;
            this.Food = FoodData.Food.None;
        }

        LinkedListNode< PetData > node = otherTeam.Pets.First;
        if ( node != null )
        {
            PetData enemy = node.Value;
            enemy.OnHurt( otherTeam, myTeam, attack );
            
            Debug.Log( $"{myTeam.TeamName} attacks {otherTeam.TeamName} for {attack} damage." );
            if ( node.Next != null && this.Food == FoodData.Food.Chili )
            {
                PetData enemy2 = node.Next.Value;

                enemy2.OnHurt( otherTeam, myTeam, 5 );
            }

            if ( enemy.Health <= 0 )
            {
                this.OnFaintEnemy( myTeam, otherTeam );
                Debug.Log( $"{myTeam.TeamName} killed a pet of {otherTeam.TeamName}! {otherTeam.Pets.Count} enemies remain." );
            }
        }

        LinkedListNode< PetData > petBehind = myTeam.Pets.Find( this ).Previous;
        if ( petBehind != null )
        {
            petBehind.Value.OnPetAheadAttack( myTeam, otherTeam );
        }
        
    }

    public virtual void OnBeforeAttack( Team myTeam, Team otherTeam )
    {

    }

    public virtual void OnFriendBought( Team myTeam, PetData friendBought )
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

    public virtual void OnSummon(Team myTeam) {
        foreach ( PetData friend in myTeam.Pets )
        {
            if ( friend == this ) continue;
            friend.OnFriendSummoned( myTeam, null );
        }
    }

    public virtual void OnFriendSummoned( Team myTeam, PetData summonedFriend )
    {

    }

    public virtual void OnFaintEnemy( Team myTeam, Team otherTeam )
    {

    }

    public virtual void OnFriendFaints( Team myTeam, Team otherTeam, PetData friend )
    {

    }

    public virtual void OnEatShopFood( Team myTeam, FoodData food )
    {
        if(food.Type == FoodData.Food.Cupcake) {
            this.AddDamage(food.Damage, temp:true);
            this.AddHealth(food.Health, temp:true);
        } else if(food.Health > 0 || food.Damage > 0) {
            this.AddDamage(food.Damage);
            this.AddHealth(food.Health);
        } else if(food.Type == FoodData.Food.Chocolate) {
            PetData newPet = CloneObject(this) as PetData;
            newPet.Health = 1;
            newPet.Damage = 1;
            newPet.StackHeight = 1;
            this.OnStack(myTeam, newPet);
        } else if(food.Type == FoodData.Food.Salad || food.Type == FoodData.Food.Pizza || food.Type == FoodData.Food.Sushi) {
            FoodData.Food foodType = (food.Type == FoodData.Food.Pizza) ? FoodData.Food.Pear : FoodData.Food.Apple;
            List<PetData> friends = new List<PetData>(myTeam.Pets);

            if(friends.Count >= 3 && food.Type == FoodData.Food.Sushi) {
                PetData friend1 = friends[Random.Range(0, friends.Count)];
                friends.Remove(friend1);
                PetData friend2 = friends[Random.Range(0, friends.Count)];
                friends.Remove(friend2);
                PetData friend3 = friends[Random.Range(0, friends.Count)];

                friend1.OnEatShopFood(myTeam, new FoodData(foodType));
                friend2.OnEatShopFood(myTeam, new FoodData(foodType));
                friend3.OnEatShopFood(myTeam, new FoodData(foodType));
            } else if(friends.Count >= 2) {
                PetData friend1 = friends[Random.Range(0, friends.Count)];
                friends.Remove(friend1);
                PetData friend2 = friends[Random.Range(0, friends.Count)];

                friend1.OnEatShopFood(myTeam, new FoodData(foodType));
                friend2.OnEatShopFood(myTeam, new FoodData(foodType));
            } else if (friends.Count == 1) {
                friends[0].OnEatShopFood(myTeam, new FoodData(foodType));
            }

            return;
        } else if(food.Type == FoodData.Food.CannedFood) {
            myTeam.Shop.DamageModifier += 2;
            myTeam.Shop.HealthModifier += 1;

            foreach(ShopItem shopItem in myTeam.Shop.Items) {
                if(shopItem?.Pet != null) {
                    shopItem?.Pet.AddDamage(2);
                    shopItem?.Pet.AddHealth(1);
                }
            }

            return;
        } else if (food.Type == FoodData.Food.Pill) {
            this.OnFaint(myTeam, null);
            return;
        } else {
            this.Food = food.Type;
        }

        foreach(PetData friend in myTeam.Pets) {
            friend.OnFriendEatsShopFood(myTeam, this, food);
        }
    }

    public virtual void OnFriendEatsShopFood( Team myTeam, PetData friend, FoodData food )
    {

    }

    public virtual void OnTurnStart( Team myTeam )
    {
        this.Health = BaseHealth;
        this.Damage = BaseDamage;
    }

    public virtual void OnTurnEnd( Team myTeam )
    {

    }

    public virtual void OnFriendSold( Team myTeam )
    {

    }

    //Returns true if legal stack, false if not
    //Needs to return false if not the same type of pet??
    public virtual bool OnStack( Team myTeam, PetData pet )
    {
        if ( StackHeight >= 6 || pet.StackHeight == 0 ) return false;

        //Stacks all copies of pets stacked on it.
        pet.StackHeight -= 1;
        this.OnStack( myTeam, pet );

        StackHeight += 1;

        this.Health = Math.Max( pet.Health, this.Health ) + 1;
        this.Damage = Math.Max( pet.Damage, this.Damage ) + 1;

        if ( StackHeight == 3 )
        {
            Level = 2;
        } else if ( StackHeight == 6 )
        {
            Level = 3;
        }

        return true;
    }
}

public class AntPet : PetData
{

    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        PetData randomFriend = myTeam.Pets.ElementAt( Random.Range( 0, myTeam.Pets.Count ) );
        randomFriend.AddDamage(2 * Level);
        randomFriend.AddHealth(1 * Level);
    }
}

public class BeaverPet : PetData
{
    public override void OnSell( Team myTeam )
    {
        base.OnSell( myTeam );

        List< PetData > friends = new List< PetData >( myTeam.Pets );

        if ( friends.Count >= 2 )
        {
            PetData friend1 = friends[ Random.Range( 0, friends.Count ) ];
            friends.Remove( friend1 );
            PetData friend2 = friends[ Random.Range( 0, friends.Count ) ];

            friend1.AddHealth(1 * Level);
            friend2.AddHealth(1 * Level);
        } else if (friends.Count == 1) {
            friends[0].AddHealth(1 * Level);
        }
    }
}

public class CricketPet : PetData
{
    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        //Create zombie cricket and add it to the team
        PetData zombie = new ZombieCricketPet { BaseHealth = 1 * Level, BaseDamage = 1 * Level, Health = 1 * Level, Damage = 1 * Level};

        if(myTeam.TryAddFriend(zombie, this.Position)) zombie.OnSummon(myTeam);
    }
}

public class DuckPet : PetData
{
    public override void OnSell( Team myTeam )
    {
        base.OnSell( myTeam );

        //Give current shop pets +1*level health
        foreach(ShopItem shopItem in myTeam.Shop.Items) {
            if(shopItem?.Pet != null) {
                shopItem?.Pet.AddHealth(1 * Level);
            }
        }
    }
}

public class FishPet : PetData
{
    public override bool OnStack( Team myTeam, PetData pet )
    {
        if ( base.OnStack( myTeam, pet ) )
        {
            if ( StackHeight == 3 || StackHeight == 6 )
            {
                List< PetData > friends = new( myTeam.Pets );
                friends.Remove( this );

                foreach ( PetData friend in friends )
                {
                    friend.AddHealth(1 * Level);
                    friend.AddDamage(1 * Level);
                }
            }

            return true;
        }

        return false;
    }
}

public class HorsePet : PetData
{
    public override void OnFriendSummoned( Team myTeam, PetData summonedFriend )
    {
        base.OnFriendSummoned( myTeam, summonedFriend );

        summonedFriend.AddDamage(1 * Level, temp:true);
    }
}

public class MosquitoPet : PetData
{
    public override void OnBattleStart( Team myTeam, Team otherTeam )
    {
        base.OnBattleStart( myTeam, otherTeam );

        if ( otherTeam.Pets.Count >= 1 )
        {
            for ( int i = 0; i < Level; i++ )
            {
                PetData enemy = otherTeam.Pets.ElementAt( Random.Range( 0, myTeam.Pets.Count ) );
                enemy.OnHurt( otherTeam, myTeam, 1 );
            }
        }
    }
}

public class OtterPet : PetData
{
    public override void OnBuy( Team myTeam )
    {
        base.OnBuy( myTeam );

        List< PetData > friends = new List< PetData >( myTeam.Pets );
        friends.Remove( this );

        PetData friend = friends.ElementAt( Random.Range( 0, friends.Count ) );
        friend.AddDamage( 1 * Level );
        friend.AddHealth( 1 * Level );
    }
}

public class PigPet : PetData
{
    public override void OnSell( Team myTeam )
    {
        base.OnSell( myTeam );

        myTeam.Coins += Level;
    }
}

public class CrabPet : PetData
{
    public override void OnBuy( Team myTeam )
    {
        base.OnBuy( myTeam );

        int maxHealth = -1;
        foreach ( PetData friend in myTeam.Pets )
        {
            maxHealth = Math.Max( friend.Health, maxHealth );
        }

        this.Health = maxHealth;
    }
}

public class DodoPet : PetData
{
    public override void OnBattleStart( Team myTeam, Team otherTeam )
    {
        base.OnBattleStart( myTeam, otherTeam );

        LinkedListNode< PetData > node = myTeam.Pets.Find( this )!.Next;
        if ( node != null )
        {
            PetData friendAhead = node.Value;
            int attackGiven = (int) ( this.Damage * 0.5 * this.Level );
            friendAhead.AddDamage( attackGiven );
        }
    }
}

public class ElephantPet : PetData
{
    public override void OnBeforeAttack( Team myTeam, Team otherTeam )
    {
        base.OnBeforeAttack( myTeam, otherTeam );

        int numFriendsTargeted = Level;
        LinkedListNode< PetData > node = myTeam.Pets.Find( this )!.Previous;

        while ( numFriendsTargeted > 0 && node != null )
        {
            node.Value.OnHurt( myTeam, otherTeam, 1 );
            numFriendsTargeted -= 1;
            node = node.Previous;
        }
    }
}

public class FlamingoPet : PetData
{
    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        int numFriendsTargeted = 2;
        LinkedListNode< PetData > node = myTeam.Pets.Find( this )!.Previous;

        while ( numFriendsTargeted > 0 && node != null )
        {
            PetData friend = node.Value;

            friend.AddDamage( 1 * Level );
            friend.AddHealth( 1 * Level );

            numFriendsTargeted -= 1;
            node = node.Previous;
        }
    }
}

public class HedgehogPet : PetData
{
    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        foreach ( PetData enemy in otherTeam.Pets )
        {
            enemy.OnHurt( otherTeam, myTeam, 2 * Level );
        }

        foreach ( PetData friend in myTeam.Pets )
        {
            friend.OnHurt( myTeam, otherTeam, 2 * Level );
        }
    }
}

public class PeacockPet : PetData
{

    int charges = 1;

    public override void OnTurnStart(Team myTeam)
    {
        base.OnTurnStart(myTeam);

        charges = Level;
    }

    public override bool OnStack(Team myTeam, PetData pet)
    {
        if ( base.OnStack( myTeam, pet ) )
        {
            if ( StackHeight == 3 || StackHeight == 6 )
            {
                charges = 1 + ( StackHeight / 3 );
            }

            return true;
        }

        return false;
    }
    public override int OnHurt( Team myTeam, Team otherTeam, int damageTaken )
    {
        damageTaken = base.OnHurt( myTeam, otherTeam, damageTaken );

        if ( this.Health >= 0 && damageTaken > 0 && charges > 0 )
        {
            this.AddDamage( (int) ( this.Damage * 1.5 ) );
            charges -= 1;
        }

        return damageTaken;
    }
}

public class RatPet : PetData
{
    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        if(otherTeam != null) {
            PetData dirtyRat = new DirtyRatPet { BaseHealth = 1, BaseDamage = 1, Health = 1, Damage = 1 };

            if(otherTeam.TryAddFriend(dirtyRat, 1)) dirtyRat.OnSummon(otherTeam);
        }
    }
}

public class ShrimpPet : PetData
{
    public override void OnFriendSold( Team myTeam )
    {
        base.OnFriendSold( myTeam );

        List< PetData > friends = new( myTeam.Pets );

        if ( friends.Count > 0 )
        {
            PetData friend = friends.ElementAt( Random.Range( 0, friends.Count ) );
            friend.AddHealth( 1 * Level );
        }
    }
}

public class SpiderPet : PetData
{
    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        //Create random tier 2 pet at level this.Level
        PetData summonPet = RandomPet(2);

        summonPet.Level = this.Level;
        summonPet.BaseDamage = 2;
        summonPet.Damage = 2;
        summonPet.Health = 2;
        summonPet.BaseHealth = 2;
        if(myTeam.TryAddFriend(summonPet, this.Position)) summonPet.OnSummon(myTeam);
    }
}

public class SwanPet : PetData
{
    public override void OnTurnStart( Team myTeam )
    {
        base.OnTurnStart( myTeam );

        myTeam.Coins += Level;
    }
}

public class DogPet : PetData
{
    public override void OnFriendSummoned( Team myTeam, PetData summonedFriend )
    {
        base.OnFriendSummoned( myTeam, summonedFriend );

        this.AddDamage( 1 * Level );
        this.AddHealth( 1 * Level );
    }
}

public class BadgerPet : PetData
{
    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        LinkedListNode< PetData > node = myTeam.Pets.Find( this );

        if ( node.Next == null )
        {
            PetData enemy = otherTeam.Pets.First.Value;
            enemy.OnHurt( otherTeam, myTeam, this.Damage );
        } else
        {
            PetData friendAhead = node.Next.Value;
            friendAhead.OnHurt( myTeam, otherTeam, this.Damage );
        }

        if ( node.Previous != null )
        {
            PetData friendBehind = node.Previous.Value;
            friendBehind.OnHurt( myTeam, otherTeam, this.Damage );
        }

        base.OnFaint( myTeam, otherTeam );
    }
}

public class BlowfishPet : PetData
{
    public override int OnHurt( Team myTeam, Team otherTeam, int damageTaken )
    {
        damageTaken = base.OnHurt( myTeam, otherTeam, damageTaken );

        if ( Health > 0 && damageTaken > 0 && otherTeam.Pets.Count > 0 )
        {
            PetData enemy = otherTeam.Pets.ElementAt( Random.Range( 0, otherTeam.Pets.Count ) );
            enemy.OnHurt( otherTeam, myTeam, 2 * Level );
        }

        return damageTaken;
    }
}

public class CamelPet : PetData
{
    public override int OnHurt( Team myTeam, Team otherTeam, int damageTaken )
    {
        damageTaken = base.OnHurt( myTeam, otherTeam, damageTaken );

        LinkedListNode< PetData > friendBehind = myTeam.Pets.Find( this ).Previous;

        if ( Health > 0 && damageTaken > 0 && friendBehind != null )
        {
            PetData friend = friendBehind.Value;
            friend.AddDamage( 1 * Level );
            friend.AddHealth( 2 * Level );
        }

        return damageTaken;
    }

}

public class GiraffePet : PetData
{
    public override void OnTurnEnd( Team myTeam )
    {
        base.OnTurnEnd( myTeam );

        int numFriendsTargeted = Level;
        LinkedListNode< PetData > node = myTeam.Pets.Find( this )!.Next;

        while ( numFriendsTargeted > 0 && node != null )
        {
            PetData friend = node.Value;

            friend.AddDamage( 1 );
            friend.AddHealth( 1 );

            numFriendsTargeted -= 1;
            node = node.Next;
        }
    }
}

public class KangarooPet : PetData
{
    public override void OnPetAheadAttack( Team myTeam, Team otherTeam )
    {
        base.OnPetAheadAttack( myTeam, otherTeam );

        this.AddDamage( 2 * Level );
        this.AddHealth( 2 * Level );
    }
}

public class OxPet : PetData
{
    public override void OnPetAheadFaint( Team myTeam, Team otherTeam )
    {
        base.OnPetAheadFaint( myTeam, otherTeam );

        this.AddDamage(2 * Level);
        this.Food = FoodData.Food.Melon;
    }

}

public class RabbitPet : PetData
{
    public override void OnFriendEatsShopFood( Team myTeam, PetData friend, FoodData food )
    {
        base.OnFriendEatsShopFood( myTeam, friend, food );

        friend.AddHealth( 1 * Level );
    }
}

public class SheepPet : PetData
{
    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        //Create two rams at health and attack 2 * Level
        PetData ram1 = new RamPet { BaseHealth = 2 * Level, BaseDamage = 2 * Level, Health = 2 * Level, Damage = 2 * Level };
        PetData ram2 = CloneObject(ram1) as PetData;

        if(myTeam.TryAddFriend(ram1, this.Position)) ram1.OnSummon(myTeam);
        if(myTeam.TryAddFriend(ram2, this.Position)) ram2.OnSummon(myTeam);
    }
}

public class SnailPet : PetData
{
    public override void OnBuy( Team myTeam )
    {
        foreach ( PetData friend in myTeam.Pets )
        {
            friend.AddDamage( 1 * Level );
            friend.AddHealth( 1 * Level );
        }

        base.OnBuy( myTeam );
    }
}

public class TurtlePet : PetData
{
    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        int numFriendsTargeted = Level;
        LinkedListNode< PetData > node = myTeam.Pets.Find( this )!.Previous;

        while ( numFriendsTargeted > 0 && node != null )
        {
            PetData friend = node.Value;

            friend.Food = FoodData.Food.Melon;

            numFriendsTargeted -= 1;
            node = node.Previous;
        }
    }
}

public class WhalePet : PetData
{
    public PetData swallowedFriend;

    public override void OnBattleStart( Team myTeam, Team otherTeam )
    {
        base.OnBattleStart( myTeam, otherTeam );

        LinkedListNode< PetData > friendAhead = myTeam.Pets.Find( this ).Next;
        if ( friendAhead != null )
        {
            swallowedFriend = friendAhead.Value;

            //Change stats to be base * Level
            swallowedFriend.BaseDamage = 1 * Level;
            swallowedFriend.Damage = 1 * Level;
            swallowedFriend.BaseHealth = 1 * Level;
            swallowedFriend.Health = 1 * Level;

            swallowedFriend.OnFaint( myTeam, otherTeam );
        }
    }

    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        if(myTeam.TryAddFriend( swallowedFriend, this.Position)) swallowedFriend.OnSummon(myTeam);
    }
}

public class BisonPet : PetData
{
    public override void OnTurnEnd( Team myTeam )
    {
        base.OnTurnEnd( myTeam );

        foreach ( PetData friend in myTeam.Pets )
        {
            if ( friend.Level == 3 )
            {
                this.AddDamage( 2 * Level );
                this.AddHealth( 2 * Level );
                break;
            }
        }
    }
}

public class DeerPet : PetData
{
    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        //Create new bus with health 5 * Level and damage
        PetData bus = new BusPet { BaseDamage = 5 * Level, Damage = 5 * Level, BaseHealth = 5 * Level, Health = 5 * Level };
        bus.Food = FoodData.Food.Chili;

        if(myTeam.TryAddFriend(bus, this.Position)) bus.OnSummon(myTeam);
    }
}

public class DolphinPet : PetData
{
    public override void OnBattleStart( Team myTeam, Team otherTeam )
    {
        base.OnBattleStart( myTeam, otherTeam );

        int minHealth = int.MaxValue;
        PetData targetEnemy = null;
        foreach ( PetData enemy in otherTeam.Pets )
        {
            if ( enemy.Health < minHealth )
            {
                targetEnemy = enemy;
                minHealth = enemy.Health;
            }
        }

        targetEnemy.OnHurt( myTeam, otherTeam, 5 * Level );
    }
}

public class HippoPet : PetData
{
    public override void OnFaintEnemy( Team myTeam, Team otherTeam )
    {
        base.OnFaintEnemy( myTeam, otherTeam );

        this.AddDamage( 2 * Level );
        this.AddHealth( 2 * Level );
    }
}

public class PenguinPet : PetData
{
    public override void OnTurnEnd( Team myTeam )
    {
        base.OnTurnEnd( myTeam );

        foreach ( PetData friend in myTeam.Pets )
        {
            if ( friend.Level == 3 || friend.Level == 2 )
            {
                friend.AddDamage( 1 * Level );
                friend.AddHealth( 1 * Level );
                break;
            }
        }
    }
}

public class RoosterPet : PetData
{
    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        for(int i = 0; i < Level; i++) {
            PetData chick = new ChickPet { BaseHealth = 1, Health = 1, BaseDamage = (int) (0.5 * this.Damage), Damage = (int) (0.5 * Damage) };
            if(myTeam.TryAddFriend(chick, this.Position)) chick.OnSummon(myTeam);
        }
    }
}

public class SkunkPet : PetData
{
    public override void OnBattleStart( Team myTeam, Team otherTeam )
    {
        base.OnBattleStart( myTeam, otherTeam );

        if ( otherTeam.Pets.Count > 0 )
        {
            PetData enemy = otherTeam.Pets.ElementAt( Random.Range( 0, otherTeam.Pets.Count ) );
            enemy.ReduceHealth( 0.33f * Level );
        }
    }
}

public class SquirrelPet : PetData
{
    public override void OnTurnStart( Team myTeam )
    {
        base.OnTurnStart( myTeam );

        //Reduce cost of food in shop by 1 * Level
    }
}

public class WormPet : PetData
{
    public override void OnEatShopFood( Team myTeam, FoodData food )
    {
        base.OnEatShopFood( myTeam, food );

        this.AddDamage( 1 * Level );
        this.AddHealth( 1 * Level );
    }
}

public class ParrotPet : PetData
{
    public override void OnTurnStart( Team myTeam )
    {
        base.OnTurnStart( myTeam );

        LinkedListNode< PetData > node = myTeam.Pets.Find( this ).Next;
        if ( node != null )
        {
            PetData friendAhead = node.Value;

            PetData newParrot = CloneObject(friendAhead) as PetData;

            newParrot.BaseDamage = this.BaseDamage;
            newParrot.BaseHealth = this.BaseHealth;
            newParrot.Damage = this.Damage;
            newParrot.Health = this.Health;
            newParrot.Food = this.Food;

            myTeam.Pets.Remove(this);
            myTeam.TryAddFriend(newParrot, this.Position);
        }
    }
}

public class MonkeyPet : PetData
{
    public override void OnTurnEnd( Team myTeam )
    {
        base.OnTurnEnd( myTeam );

        PetData frontFriend = myTeam.Pets.First.Value;

        frontFriend.AddDamage( 2 * Level );
        frontFriend.AddHealth( 3 * Level );
    }
}

public class CowPet : PetData
{
    public override void OnBuy( Team myTeam )
    {
        base.OnBuy( myTeam );

        //Change the last two shop slots to be FoodData.Food.Milk
        List<ShopItem> shopItems = myTeam.Shop.Items;

        FoodData milk = new FoodData(FoodData.Food.Milk);
        milk.Damage = milk.Damage * Level;
        milk.Health = milk.Health * Level;

        shopItems[5] = new ShopItem { Food = CloneObject(milk) as FoodData };
        shopItems[6] = new ShopItem { Food = CloneObject(milk) as FoodData };
    }
}

public class CrocodilePet : PetData
{
    public override void OnBattleStart( Team myTeam, Team otherTeam )
    {
        base.OnBattleStart( myTeam, otherTeam );

        LinkedListNode< PetData > node = otherTeam.Pets.Last;

        if ( node != null )
        {
            PetData enemy = node.Value;
            enemy.OnHurt( otherTeam, myTeam, 8 * Level );
        }
    }
}

public class RhinoPet : PetData
{
    public override void OnFaintEnemy( Team myTeam, Team otherTeam )
    {
        base.OnFaintEnemy( myTeam, otherTeam );

        LinkedListNode< PetData > node = otherTeam.Pets.First;

        if ( node != null )
        {
            PetData enemy = node.Value;
            enemy.OnHurt( otherTeam, myTeam, 4 * Level );

            if ( enemy.Health <= 0 )
            {
                this.OnFaintEnemy( myTeam, otherTeam );
            }
        }
    }
}

public class ScorpionPet : PetData
{
    public override void OnAttack( Team myTeam, Team otherTeam )
    {
        LinkedListNode< PetData > node = otherTeam.Pets.First;
        int enemyHealth = 0;
        if ( node != null )
        {
            enemyHealth = node.Value.Health;
        }

        base.OnAttack( myTeam, otherTeam );

        if ( node != null && enemyHealth != node.Value.Health )
        {
            node.Value.Health = 0;
            node.Value.OnFaint( otherTeam, myTeam );
        }
    }

    public override void OnSummon(Team myTeam)
    {
        base.OnSummon(myTeam);

        this.Food = FoodData.Food.Poison;
    }
}

public class SealPet : PetData
{
    public override void OnEatShopFood( Team myTeam, FoodData food )
    {
        base.OnEatShopFood( myTeam, food );

        List< PetData > friends = new List< PetData >( myTeam.Pets );
        friends.Remove( this );

        if ( friends.Count >= 2 )
        {
            PetData friend1 = friends[ Random.Range( 0, friends.Count ) ];
            friends.Remove( friend1 );
            PetData friend2 = friends[ Random.Range( 0, friends.Count ) ];

            friend1.AddHealth( 1 * Level );
            friend1.AddDamage( 1 * Level );

            friend2.AddHealth( 1 * Level );
            friend2.AddDamage( 1 * Level );
        } else if ( friends.Count == 1 )
        {
            friends[ 0 ].AddDamage( 1 * Level );
            friends[ 0 ].AddDamage( 1 * Level );
        }
    }
}

public class SharkPet : PetData
{
    public override void OnFriendSummoned( Team myTeam, PetData summonedFriend )
    {
        base.OnFriendSummoned( myTeam, summonedFriend );

        this.AddDamage( 2 * Level );
        this.AddHealth( 1 * Level );
    }
}

public class TurkeyPet : PetData
{
    public override void OnFriendSummoned( Team myTeam, PetData summonedFriend )
    {
        base.OnFriendSummoned( myTeam, summonedFriend );

        summonedFriend.AddDamage( 3 * Level );
        summonedFriend.AddHealth( 3 * Level );
    }
}

public class CatPet : PetData
{
    public override void OnFriendEatsShopFood( Team myTeam, PetData friend, FoodData food )
    {
        base.OnFriendEatsShopFood( myTeam, friend, food );

        //Give pet base food stats {Level} more times
        for(int i = 0; i < Level; i++) {
            friend.AddDamage(food.Damage);
            friend.AddHealth(food.Health);
        }
    }
}

public class BoarPet : PetData
{
    public override void OnBeforeAttack( Team myTeam, Team otherTeam )
    {
        base.OnBeforeAttack( myTeam, otherTeam );

        this.AddDamage( 2 * Level );
        this.AddHealth( 2 * Level );
    }
}

public class DragonPet : PetData
{
    public override void OnFriendBought( Team myTeam, PetData friendBought )
    {
        base.OnFriendBought( myTeam, friendBought );

        //If friend bought in tier 1
        if ( friendBought.PetID < 10 )
        {
            foreach ( PetData friend in myTeam.Pets )
            {
                if ( friend == this ) continue;
                friend.AddDamage( 1 * Level );
                friend.AddHealth( 1 * Level );
            }
        }
    }
}

public class FlyPet : PetData
{

    public int charges = 3;
    public override void OnFriendFaints( Team myTeam, Team otherTeam, PetData friend )
    {
        base.OnFriendFaints( myTeam, otherTeam, friend );

        if ( charges > 0 )
        {
            //Create zombie fly with stats 5 * Level
            PetData zombieFly = new ZombieFlyPet { BaseDamage = 5 * Level, Damage = 5 * Level, BaseHealth = 5 * Level, Health = 5 * Level };
            //Try add zombie fly at friend.Position
            if(myTeam.TryAddFriend(zombieFly, friend.Position)) zombieFly.OnSummon(myTeam);
        }
    }
}

public class GorillaPet : PetData
{
    public override int OnHurt( Team myTeam, Team otherTeam, int damageTaken )
    {
        damageTaken = base.OnHurt( myTeam, otherTeam, damageTaken );

        LinkedListNode< PetData > friendBehind = myTeam.Pets.Find( this ).Previous;

        if ( Health > 0 && damageTaken > 0 )
        {
            this.Food = FoodData.Food.Coconut;
        }

        return damageTaken;
    }
}

public class LeopardPet : PetData
{
    public override void OnBattleStart( Team myTeam, Team otherTeam )
    {
        base.OnBattleStart( myTeam, otherTeam );

        if ( otherTeam.Pets.Count > 0 )
        {
            PetData enemy = otherTeam.Pets.ElementAt( Random.Range( 0, otherTeam.Pets.Count ) );
            enemy.OnHurt( otherTeam, myTeam, (int) ( this.Damage * 0.5 * Level ) );
        }
    }
}

public class MammothPet : PetData
{
    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        foreach ( PetData friend in myTeam.Pets )
        {
            if ( friend == this ) continue;
            friend.AddDamage( 2 * Level );
            friend.AddHealth( 2 * Level );
        }

        base.OnFaint( myTeam, otherTeam );
    }
}

public class SnakePet : PetData
{
    public override void OnPetAheadAttack( Team myTeam, Team otherTeam )
    {
        base.OnPetAheadAttack( myTeam, otherTeam );

        if ( otherTeam.Pets.Count > 0 )
        {
            PetData enemy = otherTeam.Pets.ElementAt( Random.Range( 0, otherTeam.Pets.Count ) );
            enemy.OnHurt( otherTeam, myTeam, 5 * Level );
        }
    }
}

public class TigerPet : PetData
{
    PetData _friendAhead;

    public override void OnBattleStart( Team myTeam, Team otherTeam )
    {
        _friendAhead = myTeam.Pets.Find( this )!.Next?.Value;
        _friendAhead?.OnBattleStart( myTeam, otherTeam );
    }

    public override void OnFriendSummoned( Team myTeam, PetData summonedFriend )
    {
        _friendAhead = myTeam.Pets.Find( this )!.Next?.Value;
        _friendAhead?.OnFriendSummoned( myTeam, summonedFriend );
    }

    public override void OnPetAheadFaint( Team myTeam, Team otherTeam )
    {
        _friendAhead = myTeam.Pets.Find( this )!.Next?.Value;
        base.OnPetAheadFaint( myTeam, otherTeam );
    }

    public override void OnBeforeAttack( Team myTeam, Team otherTeam )
    {
        _friendAhead = myTeam.Pets.Find( this )!.Next?.Value;
        _friendAhead?.OnBeforeAttack( myTeam, otherTeam );
    }

    public override void OnPetAheadAttack( Team myTeam, Team otherTeam )
    {
        _friendAhead = myTeam.Pets.Find( this )!.Next?.Value;
        _friendAhead?.OnPetAheadAttack( myTeam, otherTeam );
    }


}


public class BeePet : PetData {

}

public class ZombieCricketPet : PetData {

}

public class RamPet : PetData {

}

public class DirtyRatPet : PetData {

}

public class BusPet : PetData {

}

public class ZombieFlyPet : PetData {

}

public class ChickPet : PetData { 

}