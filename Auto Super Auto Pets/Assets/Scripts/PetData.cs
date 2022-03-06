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
    public int PetID;

    public static List< PetData > TierOnePets { get; } = new()
    {
        new AntPet
        {
            PetID = 0,
            Health = 1,
            Damage = 2,
        },
        new BeaverPet
        {
            PetID = 2,
            Health = 2,
            Damage = 2,
        },
        new CricketPet
        {
            PetID = 3,
            Damage = 1,
            Health = 2,
        },
        new DuckPet
        {
            PetID = 4,
            Damage = 1,
            Health = 3,
        },
        new FishPet
        {
            PetID = 5,
            Health = 3,
            Damage = 2,
        },
        new HorsePet
        {
            PetID = 6,
            Damage = 2,
            Health = 1,
        },
        new MosquitoPet
        {
            PetID = 7,
            Damage = 2,
            Health = 2,
        },
        new OtterPet
        {
            PetID = 8,
            Damage = 1,
            Health = 2,
        },
        new PigPet
        {
            PetID = 9,
            Damage = 3,
            Health = 2,
        },
    };

    public static List< PetData > TierTwoPets { get; } = new()
    {
        new CrabPet
        {
            PetID = 10,
            Damage = 3,
            Health = 3,
        },
        new DodoPet
        {
            PetID = 11,
            Damage = 2,
            Health = 3,
        },
        new ElephantPet
        {
            PetID = 12,
            Damage = 3,
            Health = 5,
        },
        new FlamingoPet
        {
            PetID = 13,
            Damage = 3,
            Health = 1,
        },
        new HedgehogPet
        {
            PetID = 14,
            Damage = 3,
            Health = 2,
        },
        new PeacockPet
        {
            PetID = 15,
            Damage = 1,
            Health = 5,
        },
        new RatPet
        {
            PetID = 16,
            Damage = 4,
            Health = 5,
        },
        new ShrimpPet
        {
            PetID = 17,
            Damage = 2,
            Health = 5,
        },
        new SpiderPet
        {
            PetID = 18,
            Damage = 2,
            Health = 2,
        },
        new SwanPet
        {
            PetID = 19,
            Damage = 1,
            Health = 3,
        },
    };

    public static List< PetData > TierThreePets { get; } = new()
    {
        new DogPet
        {
            PetID = 20,
            Damage = 2,
            Health = 2,
        },
        new BadgerPet
        {
            PetID = 21,
            Damage = 5,
            Health = 4,
        },
        new BlowfishPet
        {
            PetID = 22,
            Damage = 3,
            Health = 5,
        },
        new CamelPet
        {
            PetID = 23,
            Damage = 2,
            Health = 5,
        },
        new GiraffePet
        {
            PetID = 24,
            Damage = 2,
            Health = 5,
        },
        new KangarooPet
        {
            PetID = 25,
            Health = 2,
            Damage = 1,
        },
        new OxPet
        {
            PetID = 26,
            Damage = 1,
            Health = 4,
        },
        new BadgerPet
        {
            PetID = 1,
            Health = 4,
            Damage = 5,
        },
        new RabbitPet
        {
            PetID = 27,
            Damage = 3,
            Health = 2,
        },
        new SheepPet
        {
            PetID = 28,
            Damage = 2,
            Health = 2,
        },
        new SnailPet
        {
            PetID = 29,
            Damage = 2,
            Health = 2,
        },
        new TurtlePet
        {
            PetID = 30,
            Damage = 1,
            Health = 2,
        },
    };

    public static List< PetData > TierFourPets { get; } = new()
    {
        new WhalePet
        {
            PetID = 31,
            Damage = 3,
            Health = 8,
        },
        new BisonPet
        {
            PetID = 32,
            Damage = 6,
            Health = 6,
        },
        new DeerPet
        {
            PetID = 33,
            Health = 1,
            Damage = 1,
        },
        new DolphinPet
        {
            PetID = 34,
            Damage = 4,
            Health = 6,
        },
        new HippoPet
        {
            PetID = 35,
            Damage = 4,
            Health = 7,
        },
        new PenguinPet
        {
            PetID = 36,
            Damage = 1,
            Health = 2,
        },
        new RoosterPet
        {
            PetID = 37,
            Damage = 5,
            Health = 3,
        },
        new SkunkPet
        {
            PetID = 38,
            Damage = 3,
            Health = 6,
        },
        new SquirrelPet
        {
            PetID = 39,
            Damage = 2,
            Health = 2,
        },
        new WormPet
        {
            PetID = 40,
            Damage = 2,
            Health = 2,
        },
        new ParrotPet
        {
            PetID = 41,
            Damage = 5,
            Health = 3,
        },
    };

    public static List< PetData > TierFivePets { get; } = new()
    {
        new MonkeyPet
        {
            PetID = 42,
            Damage = 1,
            Health = 2,
        },
        new CowPet
        {
            PetID = 43,
            Damage = 4,
            Health = 6,
        },
        new CrocodilePet
        {
            PetID = 44,
            Damage = 8,
            Health = 4,
        },
        new RhinoPet
        {
            PetID = 45,
            Damage = 5,
            Health = 8,
        },
        new ScorpionPet
        {
            PetID = 46,
            Damage = 1,
            Health = 1,
        },
        new SealPet
        {
            PetID = 47,
            Damage = 3,
            Health = 8,
        },
        new SharkPet
        {
            PetID = 48,
            Damage = 4,
            Health = 4,
        },
        new TurkeyPet
        {
            PetID = 49,
            Damage = 3,
            Health = 4,
        },
    };

    public static List< PetData > TierSixPets { get; } = new()
    {
        new CatPet
        {
            PetID = 50,
            Damage = 4,
            Health = 5,
        },
        new BoarPet
        {
            PetID = 51,
            Damage = 8,
            Health = 6,
        },
        new DragonPet
        {
            PetID = 52,
            Damage = 6,
            Health = 8,
        },
        new FlyPet
        {
            PetID = 53,
            Damage = 5,
            Health = 5,
        },
        new GorillaPet
        {
            PetID = 54,
            Damage = 6,
            Health = 9,
        },
        new LeopardPet
        {
            PetID = 55,
            Damage = 10,
            Health = 4,
        },
        new MammothPet
        {
            PetID = 56,
            Damage = 3,
            Health = 10,
        },
        new SnakePet
        {
            PetID = 57,
            Damage = 6,
            Health = 6,
        },
        new TigerPet
        {
            PetID = 58,
            Damage = 4,
            Health = 3,
        },
    };

    public int Health;
    public int Damage;
    public int Level = 1;
    public int StackHeight = 1;
    public int Position = -1;
    public FoodData.Food Food;

    public static object CloneObject( object objSource )
    {
        //step : 1 Get the type of source object and create a new instance of that type
        Type typeSource = objSource.GetType();
        object objTarget = Activator.CreateInstance( typeSource );
        //Step2 : Get all the properties of source object type
        PropertyInfo[] propertyInfo = typeSource.GetProperties( BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance );
        //Step : 3 Assign all source property to taget object 's properties
        foreach ( PropertyInfo property in propertyInfo )
        {
            //Check whether property can be written to
            if ( property.CanWrite )
            {
                //Step : 4 check whether property type is value type, enum or string type
                if ( property.PropertyType.IsValueType || property.PropertyType.IsEnum || property.PropertyType == typeof( string ) )
                {
                    property.SetValue( objTarget, property.GetValue( objSource, null ), null );
                }
                //else property type is object/complex types, so need to recursively call this method until the end of the tree is reached
                else
                {
                    object objPropertyValue = property.GetValue( objSource, null );
                    property.SetValue( objTarget, objPropertyValue == null ? null : CloneObject( objPropertyValue ), null );
                }
            }
        }

        return objTarget;
    }

    public override string ToString()
    {
        return $"D:{Damage} H:{Health} ID:{PetID}";
    }

    public void AddHealth( int amountGiven )
    {
        this.Health += amountGiven;
        if ( this.Health > 50 )
        {
            this.Health = 50;
        }
    }

    public void AddDamage( int amountGiven )
    {
        this.Damage += amountGiven;
        if ( this.Health > 50 )
        {
            this.Damage = 50;
        }
    }

    public void ReduceHealth( double reductionPercent )
    {
        this.Health = (int) Math.Ceiling( this.Health * reductionPercent );
    }

    public virtual void OnBuy( Team myTeam )
    {
        foreach ( PetData friend in myTeam.Pets )
        {
            if ( friend == this ) continue;
            friend.OnFriendSummoned( myTeam, null );
        }
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
        myTeam.Pets.Remove( this );
        foreach ( PetData friend in myTeam.Pets )
        {
            friend.OnFriendFaints( myTeam, otherTeam, this );
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
        if ( this.Food == FoodData.Food.Meatbone ) attack += 5;
        else if ( this.Food == FoodData.Food.Steak ) attack += 20;

        if ( attack > 50 ) attack = 50;

        LinkedListNode< PetData > node = otherTeam.Pets.First;
        if ( node != null )
        {
            PetData enemy = node.Value;
            enemy.OnHurt( otherTeam, myTeam, attack );

            if ( node.Next != null && this.Food == FoodData.Food.Chili )
            {
                PetData enemy2 = node.Next.Value;

                enemy2.OnHurt( otherTeam, myTeam, 5 );
            }

            if ( enemy.Health <= 0 )
            {
                this.OnFaintEnemy( myTeam, otherTeam );
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
        foreach ( PetData friend in myTeam.Pets )
        {
            friend.OnFriendEatsShopFood( myTeam, this, food );
        }
    }

    public virtual void OnFriendEatsShopFood( Team myTeam, PetData friend, FoodData food )
    {

    }

    public virtual void OnTurnStart( Team myTeam )
    {

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

    public static PetData RandomPet( int i )
    {
        List< PetData > allPets = new();

        allPets.AddRange( TierOnePets );

        if ( i > 1 )
        {
            allPets.AddRange( TierTwoPets );
        }

        if ( i > 2 )
        {
            allPets.AddRange( TierThreePets );
        }

        if ( i > 3 )
        {
            allPets.AddRange( TierFourPets );
        }

        if ( i > 4 )
        {
            allPets.AddRange( TierFivePets );
        }

        if ( i > 5 )
        {
            allPets.AddRange( TierSixPets );
        }

        return allPets[ Random.Range( 0, allPets.Count ) ];
    }
}

public class AntPet : PetData
{
    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        PetData randomFriend = myTeam.Pets.ElementAt( Random.Range( 0, myTeam.Pets.Count ) );
        randomFriend.Damage += 2 * Level;
        randomFriend.Health += 1 * Level;
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

            friend1.Health += 1 * Level;
            friend2.Health += 1 * Level;
        } else if ( friends.Count == 1 )
        {
            friends[ 0 ].Health += 1 * Level;
        }
    }
}

public class CricketPet : PetData
{
    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        //Create zombie cricket and add it to the team

        //myTeam.TryAddFriend();
    }
}

public class DuckPet : PetData
{
    public override void OnSell( Team myTeam )
    {
        base.OnSell( myTeam );

        //Give current shop pets +1*level health
        //myTeam.Shop(); 
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
                    friend.Health += 1 * Level;
                    friend.Damage += 1 * Level;
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

        summonedFriend.Damage += 1 * Level;
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

    public override bool OnStack( Team myTeam, PetData pet )
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

        //Summon Level * 1 dirty rats on opponents team

        //otherTeam.TryAddFriend(dirtyRat, 1);
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

        //myTeam.TryAddFriend(friend, this.Position);
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

        this.AddDamage( 2 * Level );
        //Gain melon armor
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

        //myTeam.TryAddFriend(ram1, this.Position);
        //myTeam.TryAddFriend(ram2, this.Position);
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

            swallowedFriend.OnFaint( myTeam, otherTeam );
        }
    }

    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        myTeam.TryAddFriend( swallowedFriend, this.Position );
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

        //myTeam.TryAddFriend(bus, this.Position);
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

        //Create 1 * Level chicks with 0.5 * this.Damage

        //Add each chick to the team
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

            //Make new friend based on petID of friendAhead
            PetData newParrot = null;

            newParrot.Damage = this.Damage;
            newParrot.Health = this.Health;
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
        if ( true )
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

            //Try add zombie fly at friend.Position
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
