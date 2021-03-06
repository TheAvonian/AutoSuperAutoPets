using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

[Serializable]
public abstract class PetData
{
    public int PetID;

    public enum AllPets
    {
        Ant,
        Beaver,
        Cricket,
        Duck,
        Fish,
        Horse,
        Mosquito,
        Otter,
        Pig,
        Crab,
        Dodo,
        Elephant,
        Flamingo,
        Hedgehog,
        Peacock,
        Rat,
        Shrimp,
        Spider,
        Swan,
        Dog,
        Badger,
        Blowfish,
        Camel,
        Giraffe,
        Kangaroo,
        Ox,
        Rabbit,
        Sheep,
        Snail,
        Turtle,
        Whale,
        Bison,
        Deer,
        Dolphin,
        Hippo,
        Penguin,
        Rooster,
        Skunk,
        Squirrel,
        Worm,
        Parrot,
        Monkey,
        Cow,
        Crocodile,
        Rhino,
        Scorpion,
        Seal,
        Shark,
        Turkey,
        Cat,
        Boar,
        Dragon,
        Fly,
        Gorilla,
        Leopard,
        Mammoth,
        Snake,
        Tiger,
        ZombieCricket,
        Bus,
        ZombieFly,
        DirtyRat,
        Chick,
        Ram,
        Bee,
    }

    public enum TierOnePets
    {
        Ant = AllPets.Ant,
        Beaver = AllPets.Beaver,
        Cricket = AllPets.Cricket,
        Duck = AllPets.Duck,
        Fish = AllPets.Fish,
        Horse = AllPets.Horse,
        Mosquito = AllPets.Mosquito,
        Otter = AllPets.Otter,
        Pig = AllPets.Pig,
    }

    public enum TierTwoPets
    {
        Crab = AllPets.Crab,
        Dodo = AllPets.Dodo,
        Elephant = AllPets.Elephant,
        Flamingo = AllPets.Flamingo,
        Hedgehog = AllPets.Hedgehog,
        Peacock = AllPets.Peacock,
        Rat = AllPets.Rat,
        Shrimp = AllPets.Shrimp,
        Spider = AllPets.Spider,
        Swan = AllPets.Swan,
    }

    public enum TierThreePets
    {
        Dog = AllPets.Dog,
        Badger = AllPets.Badger,
        Blowfish = AllPets.Blowfish,
        Camel = AllPets.Camel,
        Giraffe = AllPets.Giraffe,
        Kangaroo = AllPets.Kangaroo,
        Ox = AllPets.Ox,
        Rabbit = AllPets.Rabbit,
        Sheep = AllPets.Sheep,
        Snail = AllPets.Snail,
        Turtle = AllPets.Turtle,
    }

    public enum TierFourPets
    {
        Whale = AllPets.Whale,
        Bison = AllPets.Bison,
        Deer = AllPets.Deer,
        Dolphin = AllPets.Dolphin,
        Hippo = AllPets.Hippo,
        Penguin = AllPets.Penguin,
        Rooster = AllPets.Rooster,
        Skunk = AllPets.Skunk,
        Squirrel = AllPets.Squirrel,
        Worm = AllPets.Worm,
        Parrot = AllPets.Parrot,
    }

    public enum TierFivePets
    {
        Monkey = AllPets.Monkey,
        Cow = AllPets.Cow,
        Crocodile = AllPets.Crocodile,
        Rhino = AllPets.Rhino,
        Scorpion = AllPets.Scorpion,
        Seal = AllPets.Seal,
        Shark = AllPets.Shark,
        Turkey = AllPets.Turkey,
    }

    public enum TierSixPets
    {
        Cat = AllPets.Cat,
        Boar = AllPets.Boar,
        Dragon = AllPets.Dragon,
        Fly = AllPets.Fly,
        Gorilla = AllPets.Gorilla,
        Leopard = AllPets.Leopard,
        Mammoth = AllPets.Mammoth,
        Snake = AllPets.Snake,
        Tiger = AllPets.Tiger,
    }

    public enum SummonedPets
    {
        ZombieCricket = AllPets.ZombieCricket,
        Bus = AllPets.Bus,
        ZombieFly = AllPets.ZombieFly,
        DirtyRat = AllPets.DirtyRat,
        Chick = AllPets.Chick,
        Ram = AllPets.Ram,
        Bee = AllPets.Bee,
    }

    public enum TierTwoShop
    {
        Ant = AllPets.Ant,
        Beaver = AllPets.Beaver,
        Cricket = AllPets.Cricket,
        Duck = AllPets.Duck,
        Fish = AllPets.Fish,
        Horse = AllPets.Horse,
        Mosquito = AllPets.Mosquito,
        Otter = AllPets.Otter,
        Pig = AllPets.Pig,
        Crab = AllPets.Crab,
        Dodo = AllPets.Dodo,
        Elephant = AllPets.Elephant,
        Flamingo = AllPets.Flamingo,
        Hedgehog = AllPets.Hedgehog,
        Peacock = AllPets.Peacock,
        Rat = AllPets.Rat,
        Shrimp = AllPets.Shrimp,
        Spider = AllPets.Spider,
        Swan = AllPets.Swan,
    }

    public enum TierThreeShop
    {
        Ant = AllPets.Ant,
        Beaver = AllPets.Beaver,
        Cricket = AllPets.Cricket,
        Duck = AllPets.Duck,
        Fish = AllPets.Fish,
        Horse = AllPets.Horse,
        Mosquito = AllPets.Mosquito,
        Otter = AllPets.Otter,
        Pig = AllPets.Pig,
        Crab = AllPets.Crab,
        Dodo = AllPets.Dodo,
        Elephant = AllPets.Elephant,
        Flamingo = AllPets.Flamingo,
        Hedgehog = AllPets.Hedgehog,
        Peacock = AllPets.Peacock,
        Rat = AllPets.Rat,
        Shrimp = AllPets.Shrimp,
        Spider = AllPets.Spider,
        Swan = AllPets.Swan,
        Dog = AllPets.Dog,
        Badger = AllPets.Badger,
        Blowfish = AllPets.Blowfish,
        Camel = AllPets.Camel,
        Giraffe = AllPets.Giraffe,
        Kangaroo = AllPets.Kangaroo,
        Ox = AllPets.Ox,
        Rabbit = AllPets.Rabbit,
        Sheep = AllPets.Sheep,
        Snail = AllPets.Snail,
        Turtle = AllPets.Turtle,
    }

    public enum TierFourShop
    {
        Ant = AllPets.Ant,
        Beaver = AllPets.Beaver,
        Cricket = AllPets.Cricket,
        Duck = AllPets.Duck,
        Fish = AllPets.Fish,
        Horse = AllPets.Horse,
        Mosquito = AllPets.Mosquito,
        Otter = AllPets.Otter,
        Pig = AllPets.Pig,
        Crab = AllPets.Crab,
        Dodo = AllPets.Dodo,
        Elephant = AllPets.Elephant,
        Flamingo = AllPets.Flamingo,
        Hedgehog = AllPets.Hedgehog,
        Peacock = AllPets.Peacock,
        Rat = AllPets.Rat,
        Shrimp = AllPets.Shrimp,
        Spider = AllPets.Spider,
        Swan = AllPets.Swan,
        Dog = AllPets.Dog,
        Badger = AllPets.Badger,
        Blowfish = AllPets.Blowfish,
        Camel = AllPets.Camel,
        Giraffe = AllPets.Giraffe,
        Kangaroo = AllPets.Kangaroo,
        Ox = AllPets.Ox,
        Rabbit = AllPets.Rabbit,
        Sheep = AllPets.Sheep,
        Snail = AllPets.Snail,
        Turtle = AllPets.Turtle,
        Whale = AllPets.Whale,
        Bison = AllPets.Bison,
        Deer = AllPets.Deer,
        Dolphin = AllPets.Dolphin,
        Hippo = AllPets.Hippo,
        Penguin = AllPets.Penguin,
        Rooster = AllPets.Rooster,
        Skunk = AllPets.Skunk,
        Squirrel = AllPets.Squirrel,
        Worm = AllPets.Worm,
        Parrot = AllPets.Parrot,
    }

    public enum TierFiveShop
    {
        Ant = AllPets.Ant,
        Beaver = AllPets.Beaver,
        Cricket = AllPets.Cricket,
        Duck = AllPets.Duck,
        Fish = AllPets.Fish,
        Horse = AllPets.Horse,
        Mosquito = AllPets.Mosquito,
        Otter = AllPets.Otter,
        Pig = AllPets.Pig,
        Crab = AllPets.Crab,
        Dodo = AllPets.Dodo,
        Elephant = AllPets.Elephant,
        Flamingo = AllPets.Flamingo,
        Hedgehog = AllPets.Hedgehog,
        Peacock = AllPets.Peacock,
        Rat = AllPets.Rat,
        Shrimp = AllPets.Shrimp,
        Spider = AllPets.Spider,
        Swan = AllPets.Swan,
        Dog = AllPets.Dog,
        Badger = AllPets.Badger,
        Blowfish = AllPets.Blowfish,
        Camel = AllPets.Camel,
        Giraffe = AllPets.Giraffe,
        Kangaroo = AllPets.Kangaroo,
        Ox = AllPets.Ox,
        Rabbit = AllPets.Rabbit,
        Sheep = AllPets.Sheep,
        Snail = AllPets.Snail,
        Turtle = AllPets.Turtle,
        Whale = AllPets.Whale,
        Bison = AllPets.Bison,
        Deer = AllPets.Deer,
        Dolphin = AllPets.Dolphin,
        Hippo = AllPets.Hippo,
        Penguin = AllPets.Penguin,
        Rooster = AllPets.Rooster,
        Skunk = AllPets.Skunk,
        Squirrel = AllPets.Squirrel,
        Worm = AllPets.Worm,
        Parrot = AllPets.Parrot,
        Monkey = AllPets.Monkey,
        Cow = AllPets.Cow,
        Crocodile = AllPets.Crocodile,
        Rhino = AllPets.Rhino,
        Scorpion = AllPets.Scorpion,
        Seal = AllPets.Seal,
        Shark = AllPets.Shark,
        Turkey = AllPets.Turkey,
    }

    public enum TierSixShop
    {
        Ant = AllPets.Ant,
        Beaver = AllPets.Beaver,
        Cricket = AllPets.Cricket,
        Duck = AllPets.Duck,
        Fish = AllPets.Fish,
        Horse = AllPets.Horse,
        Mosquito = AllPets.Mosquito,
        Otter = AllPets.Otter,
        Pig = AllPets.Pig,
        Crab = AllPets.Crab,
        Dodo = AllPets.Dodo,
        Elephant = AllPets.Elephant,
        Flamingo = AllPets.Flamingo,
        Hedgehog = AllPets.Hedgehog,
        Peacock = AllPets.Peacock,
        Rat = AllPets.Rat,
        Shrimp = AllPets.Shrimp,
        Spider = AllPets.Spider,
        Swan = AllPets.Swan,
        Dog = AllPets.Dog,
        Badger = AllPets.Badger,
        Blowfish = AllPets.Blowfish,
        Camel = AllPets.Camel,
        Giraffe = AllPets.Giraffe,
        Kangaroo = AllPets.Kangaroo,
        Ox = AllPets.Ox,
        Rabbit = AllPets.Rabbit,
        Sheep = AllPets.Sheep,
        Snail = AllPets.Snail,
        Turtle = AllPets.Turtle,
        Whale = AllPets.Whale,
        Bison = AllPets.Bison,
        Deer = AllPets.Deer,
        Dolphin = AllPets.Dolphin,
        Hippo = AllPets.Hippo,
        Penguin = AllPets.Penguin,
        Rooster = AllPets.Rooster,
        Skunk = AllPets.Skunk,
        Squirrel = AllPets.Squirrel,
        Worm = AllPets.Worm,
        Parrot = AllPets.Parrot,
        Monkey = AllPets.Monkey,
        Cow = AllPets.Cow,
        Crocodile = AllPets.Crocodile,
        Rhino = AllPets.Rhino,
        Scorpion = AllPets.Scorpion,
        Seal = AllPets.Seal,
        Shark = AllPets.Shark,
        Turkey = AllPets.Turkey,
        Cat = AllPets.Cat,
        Boar = AllPets.Boar,
        Dragon = AllPets.Dragon,
        Fly = AllPets.Fly,
        Gorilla = AllPets.Gorilla,
        Leopard = AllPets.Leopard,
        Mammoth = AllPets.Mammoth,
        Snake = AllPets.Snake,
        Tiger = AllPets.Tiger,
    }

    public static PetData PetConstructor( AllPets petType )
    {
        PetData newPet = petType switch
        {
            AllPets.Ant => new AntPet {PetID = 0, Health = 1, Damage = 2},
            AllPets.Beaver => new BeaverPet {PetID = 1, Health = 2, Damage = 2},
            AllPets.Cricket => new CricketPet {PetID = 2, Damage = 1, Health = 2},
            AllPets.Duck => new DuckPet {PetID = 3, Damage = 1, Health = 3},
            AllPets.Fish => new FishPet {PetID = 4, Health = 3, Damage = 2},
            AllPets.Horse => new HorsePet {PetID = 5, Damage = 2, Health = 1},
            AllPets.Mosquito => new MosquitoPet {PetID = 6, Damage = 2, Health = 2},
            AllPets.Otter => new OtterPet {PetID = 7, Damage = 1, Health = 2},
            AllPets.Pig => new PigPet {PetID = 8, Damage = 3, Health = 1},
            AllPets.Crab => new CrabPet {PetID = 9, Damage = 3, Health = 3},
            AllPets.Dodo => new DodoPet {PetID = 10, Damage = 2, Health = 3},
            AllPets.Elephant => new ElephantPet {PetID = 11, Damage = 3, Health = 5},
            AllPets.Flamingo => new FlamingoPet {PetID = 12, Damage = 3, Health = 1},
            AllPets.Hedgehog => new HedgehogPet {PetID = 13, Damage = 3, Health = 2},
            AllPets.Peacock => new PeacockPet {PetID = 14, Damage = 2, Health = 5},
            AllPets.Rat => new RatPet {PetID = 15, Damage = 4, Health = 5},
            AllPets.Shrimp => new ShrimpPet {PetID = 16, Damage = 2, Health = 5},
            AllPets.Spider => new SpiderPet {PetID = 17, Damage = 2, Health = 2},
            AllPets.Swan => new SwanPet {PetID = 18, Damage = 1, Health = 3},
            AllPets.Dog => new DogPet {PetID = 19, Damage = 2, Health = 2},
            AllPets.Badger => new BadgerPet {PetID = 20, Damage = 5, Health = 4},
            AllPets.Blowfish => new BlowfishPet {PetID = 21, Damage = 3, Health = 5},
            AllPets.Camel => new CamelPet {PetID = 22, Damage = 2, Health = 5},
            AllPets.Giraffe => new GiraffePet {PetID = 23, Damage = 2, Health = 5},
            AllPets.Kangaroo => new KangarooPet {PetID = 24, Health = 2, Damage = 1},
            AllPets.Ox => new OxPet {PetID = 25, Damage = 1, Health = 4},
            AllPets.Rabbit => new RabbitPet {PetID = 26, Damage = 3, Health = 2},
            AllPets.Sheep => new SheepPet {PetID = 27, Damage = 2, Health = 2},
            AllPets.Snail => new SnailPet {PetID = 28, Damage = 2, Health = 2},
            AllPets.Turtle => new TurtlePet {PetID = 29, Damage = 1, Health = 2},
            AllPets.Whale => new WhalePet {PetID = 30, Damage = 3, Health = 8},
            AllPets.Bison => new BisonPet {PetID = 31, Damage = 6, Health = 6},
            AllPets.Deer => new DeerPet {PetID = 32, Health = 1, Damage = 1},
            AllPets.Dolphin => new DolphinPet {PetID = 33, Damage = 4, Health = 6},
            AllPets.Hippo => new HippoPet {PetID = 34, Damage = 4, Health = 7},
            AllPets.Penguin => new PenguinPet {PetID = 35, Damage = 1, Health = 2},
            AllPets.Rooster => new RoosterPet {PetID = 36, Damage = 5, Health = 3},
            AllPets.Skunk => new SkunkPet {PetID = 37, Damage = 3, Health = 6},
            AllPets.Squirrel => new SquirrelPet {PetID = 38, Damage = 2, Health = 2},
            AllPets.Worm => new WormPet {PetID = 39, Damage = 2, Health = 2},
            AllPets.Parrot => new ParrotPet {PetID = 40, Damage = 5, Health = 3},
            AllPets.Monkey => new MonkeyPet {PetID = 41, Damage = 1, Health = 2},
            AllPets.Cow => new CowPet {PetID = 42, Damage = 4, Health = 6},
            AllPets.Crocodile => new CrocodilePet {PetID = 43, Damage = 8, Health = 4},
            AllPets.Rhino => new RhinoPet {PetID = 44, Damage = 5, Health = 8},
            AllPets.Scorpion => new ScorpionPet {PetID = 45, Damage = 1, Health = 1},
            AllPets.Seal => new SealPet {PetID = 46, Damage = 3, Health = 8},
            AllPets.Shark => new SharkPet {PetID = 47, Damage = 4, Health = 4},
            AllPets.Turkey => new TurkeyPet {PetID = 48, Damage = 3, Health = 4},
            AllPets.Cat => new CatPet {PetID = 49, Damage = 4, Health = 5},
            AllPets.Boar => new BoarPet {PetID = 50, Damage = 8, Health = 6},
            AllPets.Dragon => new DragonPet {PetID = 51, Damage = 6, Health = 8},
            AllPets.Fly => new FlyPet {PetID = 52, Damage = 5, Health = 5},
            AllPets.Gorilla => new GorillaPet {PetID = 53, Damage = 6, Health = 9},
            AllPets.Leopard => new LeopardPet {PetID = 54, Damage = 10, Health = 4},
            AllPets.Mammoth => new MammothPet {PetID = 55, Damage = 3, Health = 10},
            AllPets.Snake => new SnakePet {PetID = 56, Damage = 6, Health = 6},
            AllPets.Tiger => new TigerPet {PetID = 57, Damage = 4, Health = 3},
            AllPets.ZombieCricket => new ZombieCricketPet {PetID = 58, Damage = 1, Health = 1},
            AllPets.Bus => new BusPet {PetID = 59, Damage = 5, Health = 5, Food = FoodData.Food.Chili},
            AllPets.ZombieFly => new ZombieFlyPet {PetID = 60, Damage = 5, Health = 5},
            AllPets.DirtyRat => new DirtyRatPet {PetID = 61, Damage = 1, Health = 1},
            AllPets.Chick => new ChickPet {PetID = 62, Damage = 4, Health = 1},
            AllPets.Ram => new RamPet {PetID = 63, Damage = 2, Health = 2},
            AllPets.Bee => new BeePet {PetID = 64, Damage = 1, Health = 1},
            _ => throw new ArgumentOutOfRangeException(),
        };
        newPet.BaseDamage = newPet.Damage;
        newPet.BaseHealth = newPet.Health;
        return newPet;
    }

    public static PetData RandomPet( int tier, bool tierSpecific )
    {
        Array list;
        if ( tierSpecific )
        {
            list = tier switch
            {
                1 => Enum.GetValues( typeof( TierOnePets ) ),
                2 => Enum.GetValues( typeof( TierTwoPets ) ),
                3 => Enum.GetValues( typeof( TierThreePets ) ),
                4 => Enum.GetValues( typeof( TierFourPets ) ),
                5 => Enum.GetValues( typeof( TierFivePets ) ),
                6 => Enum.GetValues( typeof( TierSixPets ) ),
                _ => throw new ArgumentOutOfRangeException(),
            };
        } else
        {
            list = tier switch
            {
                1 => Enum.GetValues( typeof( TierOnePets ) ),
                2 => Enum.GetValues( typeof( TierTwoShop ) ),
                3 => Enum.GetValues( typeof( TierThreeShop ) ),
                4 => Enum.GetValues( typeof( TierFourShop ) ),
                5 => Enum.GetValues( typeof( TierFiveShop ) ),
                6 => Enum.GetValues( typeof( TierSixShop ) ),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        AllPets randomPet = (AllPets) list.GetValue( Random.Range( 0, list.Length ) );
        return PetConstructor( randomPet );
    }

    public int Health;
    public int BaseHealth;
    public int Damage;
    public int BaseDamage;
    public int Level = 1;
    public int StackHeight = 1;
    public int Position = -1;
    public string Color = "FFFFFF";
    public FoodData.Food Food;

    public override string ToString()
    {
        return $"<color=#{Color}><b>{(AllPets) PetID}</b></color> <color=#C91F37>{Damage}</color> <color=#8DB255>{Health}</color> <color=#22A7F0>{StackHeight}</color>";
    }

    public void AddHealth( int amountGiven, bool temp = false )
    {
        if ( !temp )
        {
            BaseHealth += amountGiven;
        }

        Health += amountGiven;
        if ( Health > 50 )
        {
            Health = 50;
        }

        if ( BaseHealth > 50 )
        {
            BaseHealth = 50;
        }
    }

    public void AddDamage( int amountGiven, bool temp = false )
    {
        if ( !temp )
        {
            BaseDamage += amountGiven;
        }

        Damage += amountGiven;
        if ( Health > 50 )
        {
            Damage = 50;
        }

        if ( BaseDamage > 50 )
        {
            BaseDamage = 50;
        }
    }

    public void ReduceHealth( double reductionPercent )
    {
        Health = (int) Math.Ceiling( Health * reductionPercent );
    }

    public virtual void OnBuy( Team myTeam )
    {

    }

    public virtual void OnSell( Team myTeam )
    {
        myTeam.Pets.RemovePet( this );
        myTeam.Coins += Level;

        for ( int i = 0; i < myTeam.Pets.Size; i++ )
        {
            PetData pet = myTeam.Pets.GetPet( i );

            pet?.OnFriendSold( myTeam );
        }
    }


    public virtual void OnFaint( Team myTeam, Team otherTeam )
    {
        myTeam.Pets.GetPetBehind( Position )?.OnPetAheadFaint( myTeam, otherTeam );

        myTeam.Pets.RemovePet( this );

        switch ( Food )
        {
            case FoodData.Food.Honey:
                myTeam.Pets.TryAddFriend( new BeePet {BaseHealth = 1, BaseDamage = 1, Health = 1, Damage = 1, PetID = 64}, Position );
                break;
            case FoodData.Food.Mushroom:
            {
                PetData selfCopy = PetConstructor( (AllPets) PetID );
                selfCopy.Health = 1;
                selfCopy.BaseHealth = 1;
                selfCopy.Damage = 1;
                selfCopy.BaseDamage = 1;
                selfCopy.Food = FoodData.Food.None;
                if ( myTeam.Pets.TryAddFriend( selfCopy, Position ) )
                {
                    selfCopy.OnSummon( myTeam );
                }

                break;
            }
        }

        for ( int i = 0; i < myTeam.Pets.Size; i++ )
        {
            PetData pet = myTeam.Pets.GetPet( i );

            pet?.OnFriendFaints( myTeam, otherTeam, this );
        }
    }

    //Subtracts health the applicable amount and returns the final amount of damage taken
    public virtual int OnHurt( Team myTeam, Team otherTeam, int damageTaken )
    {
        if ( Health <= 0 )
        {
            return 0;
        }

        switch ( Food )
        {
            case FoodData.Food.Garlic:
            {
                damageTaken -= 2;
                if ( damageTaken <= 0 )
                {
                    damageTaken = 1;
                }

                break;
            }
            case FoodData.Food.Melon:
            {
                damageTaken -= 20;
                if ( damageTaken < 0 )
                {
                    damageTaken = 0;
                }

                Food = FoodData.Food.None;
                break;
            }
            case FoodData.Food.Coconut:
                damageTaken = 0;
                Food = FoodData.Food.None;
                break;
        }

        if ( damageTaken > 0 )
        {
            Health -= damageTaken;
            BaseHealth -= damageTaken;
        }

        if ( Health <= 0 )
        {
            OnFaint( myTeam, otherTeam );
        }

        return damageTaken;
    }

    public virtual void OnAttack( Team myTeam, Team otherTeam )
    {
        OnBeforeAttack( myTeam, otherTeam );

        int attack = Damage;
        switch ( Food )
        {
            case FoodData.Food.Meatbone:
                attack += 5;
                break;
            case FoodData.Food.Steak:
                attack += 20;
                Food = FoodData.Food.None;
                break;
        }


        PetData enemy = otherTeam.Pets.GetFirstPet();
        if ( enemy is { } )
        {
            int damageDone = enemy.OnHurt( otherTeam, myTeam, attack );

            //Debug.Log( $"{myTeam.TeamName}: {this} attacks {enemy} for {attack} damage." );
            PetData enemy2 = otherTeam.Pets.GetPetBehind( enemy.Position );
            if ( enemy2 is { } && Food == FoodData.Food.Chili )
            {
                //Debug.Log( $"{myTeam.TeamName}: {this} attacks {enemy2} with Chili!" );
                enemy2.OnHurt( otherTeam, myTeam, 5 );
            } else if ( Food == FoodData.Food.Poison && damageDone > 0 )
            {
                enemy.Health = 0;
                enemy.OnFaint( otherTeam, myTeam );
            }

            if ( enemy.Health <= 0 )
            {
                //Debug.Log( $"{myTeam.TeamName}: {this} killed {enemy}! {otherTeam.Pets.Count} enemies remain." );
                OnFaintEnemy( myTeam, otherTeam );
            }
        }

        myTeam.Pets.GetPetBehind( Position )?.OnPetAheadAttack( myTeam, otherTeam );

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

    public virtual void OnSummon( Team myTeam )
    {
        for ( int i = 0; i < myTeam.Pets.Size; i++ )
        {
            PetData pet = myTeam.Pets.GetPet( i );
            if ( pet is null || ReferenceEquals( this, pet ) )
            {
                continue;
            }

            pet.OnFriendSummoned( myTeam, this );
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
        if ( food.Type == FoodData.Food.Cupcake )
        {
            AddDamage( food.Damage, true );
            AddHealth( food.Health, true );
        } else if ( food.Health > 0 || food.Damage > 0 )
        {
            AddDamage( food.Damage );
            AddHealth( food.Health );
        } else
        {
            switch ( food.Type )
            {
                case FoodData.Food.Chocolate:
                {
                    PetData newPet = PetConstructor( (AllPets) PetID );
                    newPet.Health = 1;
                    newPet.Damage = 1;
                    newPet.StackHeight = 1;
                    OnStack( myTeam, newPet );
                    break;
                }
                case FoodData.Food.Salad or FoodData.Food.Pizza or FoodData.Food.Sushi:
                {
                    FoodData.Food foodType = food.Type == FoodData.Food.Pizza ? FoodData.Food.Pear : FoodData.Food.Apple;
                    List< PetData > friends = new( myTeam.Pets.List.Where( x => x is { } ) );

                    switch ( friends.Count )
                    {
                        case >= 3 when food.Type == FoodData.Food.Sushi:
                        {
                            PetData friend1 = friends[ Random.Range( 0, friends.Count ) ];
                            friends.Remove( friend1 );
                            PetData friend2 = friends[ Random.Range( 0, friends.Count ) ];
                            friends.Remove( friend2 );
                            PetData friend3 = friends[ Random.Range( 0, friends.Count ) ];

                            friend1.OnEatShopFood( myTeam, new FoodData( foodType ) );
                            friend2.OnEatShopFood( myTeam, new FoodData( foodType ) );
                            friend3.OnEatShopFood( myTeam, new FoodData( foodType ) );
                            break;
                        }
                        case >= 2:
                        {
                            PetData friend1 = friends[ Random.Range( 0, friends.Count ) ];
                            friends.Remove( friend1 );
                            PetData friend2 = friends[ Random.Range( 0, friends.Count ) ];

                            friend1.OnEatShopFood( myTeam, new FoodData( foodType ) );
                            friend2.OnEatShopFood( myTeam, new FoodData( foodType ) );
                            break;
                        }
                        case 1:
                            friends[ 0 ].OnEatShopFood( myTeam, new FoodData( foodType ) );
                            break;
                    }

                    return;
                }
                case FoodData.Food.CannedFood:
                {
                    myTeam.Shop.DamageModifier += 2;
                    myTeam.Shop.HealthModifier += 1;

                    foreach ( ShopItem shopItem in myTeam.Shop.Items )
                    {
                        if ( shopItem?.Pet is { } )
                        {
                            shopItem.Pet.AddDamage( 2 );
                            shopItem.Pet.AddHealth( 1 );
                        }
                    }

                    return;
                }
                case FoodData.Food.Pill:
                    OnFaint( myTeam, null );
                    return;
                default:
                    Food = food.Type;
                    break;
            }
        }

        foreach ( PetData friend in myTeam.Pets.List )
        {
            friend?.OnFriendEatsShopFood( myTeam, this, food );
        }
    }

    public virtual void OnFriendEatsShopFood( Team myTeam, PetData friend, FoodData food )
    {

    }

    public virtual void OnTurnStart( Team myTeam )
    {
        Health = BaseHealth;
        Damage = BaseDamage;
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
        if ( StackHeight >= 6 || pet.StackHeight == 0 )
        {
            return false;
        }

        //Stacks all copies of pets stacked on it.
        pet.StackHeight -= 1;
        OnStack( myTeam, pet );

        StackHeight += 1;

        Health = Math.Max( pet.Health, Health ) + 1;
        Damage = Math.Max( pet.Damage, Damage ) + 1;

        Level = StackHeight switch
        {
            3 => 2,
            6 => 3,
            _ => Level,
        };

        return true;
    }
}

public class AntPet : PetData
{

    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        if ( myTeam.Pets.PetCount >= 1 )
        {
            List< PetData > friends = new( myTeam.Pets.List.Where( x => x is { } ) );

            PetData randomFriend = friends[ Random.Range( 0, friends.Count ) ];
            randomFriend.AddDamage( 2 * Level );
            randomFriend.AddHealth( 1 * Level );
        }
    }
}

public class BeaverPet : PetData
{
    public override void OnSell( Team myTeam )
    {
        base.OnSell( myTeam );

        List< PetData > friends = new( myTeam.Pets.List.Where( x => x is { } ) );

        switch ( friends.Count )
        {
            case >= 2:
            {
                PetData friend1 = friends[ Random.Range( 0, friends.Count ) ];
                friends.Remove( friend1 );
                PetData friend2 = friends[ Random.Range( 0, friends.Count ) ];

                friend1.AddHealth( 1 * Level );
                friend2.AddHealth( 1 * Level );
                break;
            }
            case 1:
                friends[ 0 ].AddHealth( 1 * Level );
                break;
        }
    }
}

public class CricketPet : PetData
{
    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        //Create zombie cricket and add it to the team
        PetData zombie = new ZombieCricketPet {BaseHealth = 1 * Level, BaseDamage = 1 * Level, Health = 1 * Level, Damage = 1 * Level, PetID = 58};

        if ( myTeam.Pets.TryAddFriend( zombie, Position ) )
        {
            zombie.OnSummon( myTeam );
        }
    }
}

public class DuckPet : PetData
{
    public override void OnSell( Team myTeam )
    {
        base.OnSell( myTeam );

        //Give current shop pets +1*level health
        foreach ( ShopItem shopItem in myTeam.Shop.Items )
        {
            shopItem?.Pet?.AddHealth( 1 * Level );
        }
    }
}

public class FishPet : PetData
{
    public override bool OnStack( Team myTeam, PetData pet )
    {
        if ( base.OnStack( myTeam, pet ) )
        {
            if ( StackHeight is 3 or 6 )
            {
                List< PetData > friends = new( myTeam.Pets.List.Where( x => x is { } ) );
                friends.Remove( this );

                foreach ( PetData friend in friends )
                {
                    friend.AddHealth( 1 * Level );
                    friend.AddDamage( 1 * Level );
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

        summonedFriend?.AddDamage( 1 * Level, true );
    }
}

public class MosquitoPet : PetData
{
    public override void OnBattleStart( Team myTeam, Team otherTeam )
    {
        base.OnBattleStart( myTeam, otherTeam );

        if ( otherTeam.Pets.PetCount >= 1 )
        {
            List< PetData > enemies = new( otherTeam.Pets.List.Where( x => x is { } ) );
            for ( int i = 0; i < Level && enemies.Count > 0; i++ )
            {
                PetData enemy = enemies[ Random.Range( 0, enemies.Count ) ];
                enemy.OnHurt( otherTeam, myTeam, 1 );
                enemies.Remove( enemy );
            }
        }
    }
}

public class OtterPet : PetData
{
    public override void OnBuy( Team myTeam )
    {
        base.OnBuy( myTeam );

        List< PetData > friends = new( myTeam.Pets.List.Where( x => x is { } ) );
        friends.Remove( this );

        if ( friends.Count > 0 )
        {
            PetData friend = friends[ Random.Range( 0, friends.Count ) ];
            friend.AddDamage( 1 * Level );
            friend.AddHealth( 1 * Level );
        }
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

        int maxHealth = ( from friend in myTeam.Pets.List.Where( x => x is { } ) select friend.Health ).Prepend( -1 ).Max();

        Health = maxHealth;
    }
}

public class DodoPet : PetData
{
    public override void OnBattleStart( Team myTeam, Team otherTeam )
    {
        base.OnBattleStart( myTeam, otherTeam );

        PetData friendAhead = myTeam.Pets.GetPetAhead( Position );
        if ( friendAhead is null )
        {
            return;
        }

        int attackGiven = (int) ( Damage * 0.5 * Level );
        friendAhead.AddDamage( attackGiven );
    }
}

public class ElephantPet : PetData
{
    public override void OnBeforeAttack( Team myTeam, Team otherTeam )
    {
        base.OnBeforeAttack( myTeam, otherTeam );

        int numFriendsTargeted = Level;
        int friendIndex = Position;

        while ( numFriendsTargeted > 0 && friendIndex < myTeam.Pets.Size )
        {
            PetData friend = myTeam.Pets.GetPetBehind( friendIndex );
            if ( friend is null )
            {
                friendIndex++;
                continue;
            }

            friend.OnHurt( myTeam, otherTeam, 1 );
            numFriendsTargeted -= 1;
            friendIndex = friend.Position;
        }
    }
}

public class FlamingoPet : PetData
{
    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        int numFriendsTargeted = 2;
        int friendIndex = Position;

        while ( numFriendsTargeted > 0 && friendIndex < myTeam.Pets.Size )
        {
            PetData friend = myTeam.Pets.GetPetBehind( friendIndex );
            if ( friend is null )
            {
                friendIndex++;
                continue;
            }

            friend.AddDamage( 1 * Level );
            friend.AddHealth( 1 * Level );

            numFriendsTargeted -= 1;
            friendIndex = friend.Position;
        }
    }
}

public class HedgehogPet : PetData
{
    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        for ( int i = 0; i < otherTeam?.Pets.Size; i++ )
        {
            PetData pet = otherTeam.Pets.GetPet( i );
            pet?.OnHurt( otherTeam, myTeam, 2 * Level );
        }

        for ( int i = 0; i < myTeam.Pets.Size; i++ )
        {
            PetData pet = myTeam.Pets.GetPet( i );
            pet?.OnHurt( myTeam, otherTeam, 2 * Level );
        }
    }
}

public class PeacockPet : PetData
{

    int _charges = 1;

    public override void OnTurnStart( Team myTeam )
    {
        base.OnTurnStart( myTeam );

        _charges = Level;
    }

    public override bool OnStack( Team myTeam, PetData pet )
    {
        if ( base.OnStack( myTeam, pet ) )
        {
            if ( StackHeight is 3 or 6 )
            {
                _charges = 1 + StackHeight / 3;
            }

            return true;
        }

        return false;
    }
    public override int OnHurt( Team myTeam, Team otherTeam, int damageTaken )
    {
        damageTaken = base.OnHurt( myTeam, otherTeam, damageTaken );

        if ( Health >= 0 && damageTaken > 0 && _charges > 0 )
        {
            AddDamage( (int) ( Damage * 1.5 ) );
            _charges -= 1;
        }

        return damageTaken;
    }
}

public class RatPet : PetData
{
    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        if ( otherTeam is { } )
        {
            PetData dirtyRat = new DirtyRatPet {BaseHealth = 1, BaseDamage = 1, Health = 1, Damage = 1, PetID = 61};

            if ( otherTeam.Pets.TryAddFriend( dirtyRat, 0 ) )
            {
                dirtyRat.OnSummon( otherTeam );
            }
        }
    }
}

public class ShrimpPet : PetData
{
    public override void OnFriendSold( Team myTeam )
    {
        base.OnFriendSold( myTeam );

        List< PetData > friends = new( myTeam.Pets.List.Where( x => x is { } ) );
        friends.Remove( this );

        if ( friends.Count > 0 )
        {
            PetData friend = friends[ Random.Range( 0, friends.Count ) ];
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
        PetData summonPet = RandomPet( 2, true );

        summonPet.Level = Level;
        summonPet.BaseDamage = 2;
        summonPet.Damage = 2;
        summonPet.Health = 2;
        summonPet.BaseHealth = 2;
        if ( myTeam.Pets.TryAddFriend( summonPet, Position ) )
        {
            summonPet.OnSummon( myTeam );
        }
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

        AddDamage( 1 * Level );
        AddHealth( 1 * Level );
    }
}

public class BadgerPet : PetData
{
    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        List< PetData > friends = new( myTeam.Pets.List.Where( x => x is { } ) );
        int position = friends.IndexOf( this );

        //Hurt friend behind
        if ( position + 1 < friends.Count )
        {
            friends[ position + 1 ].OnHurt( myTeam, otherTeam, Damage );
        }

        //Hurt friend ahead/enemy
        if ( position - 1 >= 0 )
        {
            friends[ position - 1 ].OnHurt( myTeam, otherTeam, Damage );
        } else if ( otherTeam.Pets.GetFirstPet() is { } )
        {
            otherTeam.Pets.GetFirstPet().OnHurt( otherTeam, myTeam, Damage );
        }

        base.OnFaint( myTeam, otherTeam );
    }
}

public class BlowfishPet : PetData
{
    public override int OnHurt( Team myTeam, Team otherTeam, int damageTaken )
    {
        damageTaken = base.OnHurt( myTeam, otherTeam, damageTaken );

        List< PetData > enemies = new( otherTeam.Pets.List.Where( x => x is { } ) );

        if ( Health > 0 && damageTaken > 0 && enemies.Count > 0 )
        {
            PetData enemy = enemies[ Random.Range( 0, enemies.Count ) ];
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

        List< PetData > friends = new( myTeam.Pets.List.Where( x => x is { } ) );
        int position = friends.IndexOf( this );

        if ( Health > 0 && damageTaken > 0 && position + 1 < friends.Count )
        {
            PetData friend = friends[ position + 1 ];
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

        List< PetData > friends = new( myTeam.Pets.List.Where( x => x is { } ) );
        int position = friends.IndexOf( this );

        while ( numFriendsTargeted > 0 && position - 1 >= 0 )
        {
            PetData friend = friends[ position - 1 ];

            friend.AddDamage( 1 );
            friend.AddHealth( 1 );

            numFriendsTargeted -= 1;
            position -= 1;
        }
    }
}

public class KangarooPet : PetData
{
    public override void OnPetAheadAttack( Team myTeam, Team otherTeam )
    {
        base.OnPetAheadAttack( myTeam, otherTeam );

        AddDamage( 2 * Level );
        AddHealth( 2 * Level );
    }
}

public class OxPet : PetData
{
    public override void OnPetAheadFaint( Team myTeam, Team otherTeam )
    {
        base.OnPetAheadFaint( myTeam, otherTeam );

        AddDamage( 2 * Level );
        Food = FoodData.Food.Melon;
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
        PetData ram1 = new RamPet {BaseHealth = 2 * Level, BaseDamage = 2 * Level, Health = 2 * Level, Damage = 2 * Level, PetID = 63};
        PetData ram2 = new RamPet {BaseHealth = 2 * Level, BaseDamage = 2 * Level, Health = 2 * Level, Damage = 2 * Level, PetID = 63};

        if ( myTeam.Pets.TryAddFriend( ram1, Position ) )
        {
            ram1.OnSummon( myTeam );
        }

        if ( myTeam.Pets.TryAddFriend( ram2, Position ) )
        {
            ram2.OnSummon( myTeam );
        }
    }
}

public class SnailPet : PetData
{
    public override void OnBuy( Team myTeam )
    {
        foreach ( PetData friend in myTeam.Pets.List )
        {
            friend?.AddDamage( 1 * Level );
            friend?.AddHealth( 1 * Level );
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

        List< PetData > friends = new( myTeam.Pets.List.Where( x => x is { } ) );
        int position = friends.IndexOf( this );

        while ( numFriendsTargeted > 0 && position + 1 < friends.Count )
        {
            PetData friend = friends[ position + 1 ];

            friend.AddDamage( 1 );
            friend.AddHealth( 1 );

            numFriendsTargeted -= 1;
            position += 1;
        }
    }
}

public class WhalePet : PetData
{
    public PetData SwallowedFriend;

    public override void OnBattleStart( Team myTeam, Team otherTeam )
    {
        base.OnBattleStart( myTeam, otherTeam );

        List< PetData > friends = new( myTeam.Pets.List.Where( x => x is { } ) );
        int position = friends.IndexOf( this );
        if ( position - 1 >= 0 )
        {
            SwallowedFriend = friends[ position - 1 ];

            //Change stats to be base * Level
            SwallowedFriend.Level = Level;
            SwallowedFriend.BaseDamage *= Level;
            SwallowedFriend.Damage *= Level;
            SwallowedFriend.BaseHealth *= Level;
            SwallowedFriend.Health *= Level;

            SwallowedFriend.OnFaint( myTeam, otherTeam );
        }
    }

    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        if ( SwallowedFriend is { } && myTeam.Pets.TryAddFriend( SwallowedFriend, Position ) )
        {
            SwallowedFriend.OnSummon( myTeam );
        }
    }
}

public class BisonPet : PetData
{
    public override void OnTurnEnd( Team myTeam )
    {
        base.OnTurnEnd( myTeam );

        if ( myTeam.Pets.List.Any( friend => friend.Level == 3 ) )
        {
            AddDamage( 2 * Level );
            AddHealth( 2 * Level );
        }
    }
}

public class DeerPet : PetData
{
    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        base.OnFaint( myTeam, otherTeam );

        //Create new bus with health 5 * Level and damage
        PetData bus = new BusPet {BaseDamage = 5 * Level, Damage = 5 * Level, BaseHealth = 5 * Level, Health = 5 * Level, PetID = 59};
        bus.Food = FoodData.Food.Chili;

        if ( myTeam.Pets.TryAddFriend( bus, Position ) )
        {
            bus.OnSummon( myTeam );
        }
    }
}

public class DolphinPet : PetData
{
    public override void OnBattleStart( Team myTeam, Team otherTeam )
    {
        base.OnBattleStart( myTeam, otherTeam );

        int minHealth = int.MaxValue;
        PetData targetEnemy = null;
        foreach ( PetData enemy in otherTeam.Pets.List )
        {
            if ( enemy is { } && enemy.Health < minHealth )
            {
                targetEnemy = enemy;
                minHealth = enemy.Health;
            }
        }

        targetEnemy?.OnHurt( myTeam, otherTeam, 5 * Level );
    }
}

public class HippoPet : PetData
{
    public override void OnFaintEnemy( Team myTeam, Team otherTeam )
    {
        base.OnFaintEnemy( myTeam, otherTeam );

        AddDamage( 2 * Level );
        AddHealth( 2 * Level );
    }
}

public class PenguinPet : PetData
{
    public override void OnTurnEnd( Team myTeam )
    {
        base.OnTurnEnd( myTeam );

        foreach ( PetData friend in myTeam.Pets.List )
        {
            if ( friend?.Level is 3 or 2 )
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

        for ( int i = 0; i < Level; i++ )
        {
            PetData chick = new ChickPet {BaseHealth = 1, Health = 1, BaseDamage = (int) ( 0.5 * Damage ), Damage = (int) ( 0.5 * Damage ), PetID = 62};
            if ( myTeam.Pets.TryAddFriend( chick, Position ) )
            {
                chick.OnSummon( myTeam );
            }
        }
    }
}

public class SkunkPet : PetData
{
    public override void OnBattleStart( Team myTeam, Team otherTeam )
    {
        base.OnBattleStart( myTeam, otherTeam );

        List< PetData > enemies = new( otherTeam.Pets.List.Where( x => x is { } ) );

        if ( enemies.Count > 0 )
        {
            PetData enemy = enemies[ Random.Range( 0, enemies.Count ) ];
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

        AddDamage( 1 * Level );
        AddHealth( 1 * Level );
    }
}

public class ParrotPet : PetData
{
    public override void OnTurnEnd( Team myTeam )
    {
        base.OnTurnEnd( myTeam );

        List< PetData > friends = new( myTeam.Pets.List.Where( x => x is { } ) );
        int position = friends.IndexOf( this );

        if ( position - 1 >= 0 )
        {
            PetData friendAhead = friends[ position - 1 ];

            PetData newParrot = PetConstructor( (AllPets) friendAhead.PetID );

            newParrot.BaseDamage = BaseDamage;
            newParrot.BaseHealth = BaseHealth;
            newParrot.Damage = Damage;
            newParrot.Health = Health;
            newParrot.Food = Food;

            myTeam.Pets.RemovePet( this );
            myTeam.Pets.TryAddFriend( newParrot, Position );
        }
    }
}

public class MonkeyPet : PetData
{
    public override void OnTurnEnd( Team myTeam )
    {
        base.OnTurnEnd( myTeam );

        PetData frontFriend = myTeam.Pets.GetFirstPet();

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
        ShopItem[] shopItems = myTeam.Shop.Items;

        FoodData milk1 = new( FoodData.Food.Milk );
        milk1.Damage *= Level;
        milk1.Health *= Level;
        FoodData milk2 = new( FoodData.Food.Milk );
        milk2.Damage *= Level;
        milk2.Health *= Level;

        shopItems[ 5 ] = new ShopItem {Food = milk1};
        shopItems[ 6 ] = new ShopItem {Food = milk2};
    }
}

public class CrocodilePet : PetData
{
    public override void OnBattleStart( Team myTeam, Team otherTeam )
    {
        base.OnBattleStart( myTeam, otherTeam );

        List< PetData > enemies = new( otherTeam.Pets.List.Where( x => x is { } ) );

        if ( enemies.Count > 0 )
        {
            PetData enemy = enemies[ ^1 ];
            enemy.OnHurt( otherTeam, myTeam, 8 * Level );
        }

    }
}

public class RhinoPet : PetData
{
    public override void OnFaintEnemy( Team myTeam, Team otherTeam )
    {
        base.OnFaintEnemy( myTeam, otherTeam );

        PetData enemy = otherTeam.Pets.GetFirstPet();

        if ( enemy is { } )
        {
            enemy.OnHurt( otherTeam, myTeam, 4 * Level );

            if ( enemy.Health <= 0 )
            {
                OnFaintEnemy( myTeam, otherTeam );
            }
        }
    }
}

public class ScorpionPet : PetData
{
    public override void OnSummon( Team myTeam )
    {
        base.OnSummon( myTeam );

        Food = FoodData.Food.Poison;
    }
}

public class SealPet : PetData
{
    public override void OnEatShopFood( Team myTeam, FoodData food )
    {
        base.OnEatShopFood( myTeam, food );

        List< PetData > friends = new( myTeam.Pets.List.Where( x => x is { } ) );
        friends.Remove( this );

        switch ( friends.Count )
        {
            case >= 2:
            {
                PetData friend1 = friends[ Random.Range( 0, friends.Count ) ];
                friends.Remove( friend1 );
                PetData friend2 = friends[ Random.Range( 0, friends.Count ) ];

                friend1.AddHealth( 1 * Level );
                friend1.AddDamage( 1 * Level );

                friend2.AddHealth( 1 * Level );
                friend2.AddDamage( 1 * Level );
                break;
            }
            case 1:
                friends[ 0 ].AddDamage( 1 * Level );
                friends[ 0 ].AddDamage( 1 * Level );
                break;
        }
    }
}

public class SharkPet : PetData
{
    public override void OnFriendSummoned( Team myTeam, PetData summonedFriend )
    {
        base.OnFriendSummoned( myTeam, summonedFriend );

        AddDamage( 2 * Level );
        AddHealth( 1 * Level );
    }
}

public class TurkeyPet : PetData
{
    public override void OnFriendSummoned( Team myTeam, PetData summonedFriend )
    {
        base.OnFriendSummoned( myTeam, summonedFriend );

        summonedFriend?.AddDamage( 3 * Level );
        summonedFriend?.AddHealth( 3 * Level );
    }
}

public class CatPet : PetData
{
    public override void OnFriendEatsShopFood( Team myTeam, PetData friend, FoodData food )
    {
        base.OnFriendEatsShopFood( myTeam, friend, food );

        //Give pet base food stats {Level} more times
        for ( int i = 0; i < Level; i++ )
        {
            friend.AddDamage( food.Damage );
            friend.AddHealth( food.Health );
        }
    }
}

public class BoarPet : PetData
{
    public override void OnBeforeAttack( Team myTeam, Team otherTeam )
    {
        base.OnBeforeAttack( myTeam, otherTeam );

        AddDamage( 2 * Level );
        AddHealth( 2 * Level );
    }
}

public class DragonPet : PetData
{
    public override void OnFriendBought( Team myTeam, PetData friendBought )
    {
        base.OnFriendBought( myTeam, friendBought );

        //If friend bought in tier 1
        if ( friendBought.PetID < 9 )
        {
            foreach ( PetData friend in myTeam.Pets.List )
            {
                if ( friend is null || friend == this )
                {
                    continue;
                }

                friend.AddDamage( 1 * Level );
                friend.AddHealth( 1 * Level );
            }
        }
    }
}

public class FlyPet : PetData
{

    public int Charges = 3;
    public override void OnFriendFaints( Team myTeam, Team otherTeam, PetData friend )
    {
        base.OnFriendFaints( myTeam, otherTeam, friend );

        if ( Charges > 0 )
        {
            //Create zombie fly with stats 5 * Level
            PetData zombieFly = new ZombieFlyPet {BaseDamage = 5 * Level, Damage = 5 * Level, BaseHealth = 5 * Level, Health = 5 * Level, PetID = 60};
            //Try add zombie fly at friend.Position
            if ( myTeam.Pets.TryAddFriend( zombieFly, friend.Position ) )
            {
                zombieFly.OnSummon( myTeam );
                Charges--;
            }
        }
    }
}

public class GorillaPet : PetData
{
    public override int OnHurt( Team myTeam, Team otherTeam, int damageTaken )
    {
        damageTaken = base.OnHurt( myTeam, otherTeam, damageTaken );

        if ( Health > 0 && damageTaken > 0 )
        {
            Food = FoodData.Food.Coconut;
        }

        return damageTaken;
    }
}

public class LeopardPet : PetData
{
    public override void OnBattleStart( Team myTeam, Team otherTeam )
    {
        base.OnBattleStart( myTeam, otherTeam );

        List< PetData > enemies = new( otherTeam.Pets.List.Where( x => x is { } ) );

        if ( enemies.Count > 0 )
        {
            PetData enemy = enemies[ Random.Range( 0, enemies.Count ) ];
            enemy.OnHurt( otherTeam, myTeam, (int) ( Damage * 0.5 * Level ) );
        }
    }
}

public class MammothPet : PetData
{
    public override void OnFaint( Team myTeam, Team otherTeam )
    {
        foreach ( PetData friend in myTeam.Pets.List )
        {
            if ( friend is null || friend == this )
            {
                continue;
            }

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

        List< PetData > enemies = new( otherTeam.Pets.List.Where( x => x is { } ) );

        if ( enemies.Count > 0 )
        {
            PetData enemy = enemies[ Random.Range( 0, enemies.Count ) ];
            enemy.OnHurt( otherTeam, myTeam, 5 * Level );
        }
    }
}

public class TigerPet : PetData
{
    PetData _friendAhead;

    public override void OnBattleStart( Team myTeam, Team otherTeam )
    {
        _friendAhead = myTeam.Pets.GetPetAhead( Position );
        _friendAhead?.OnBattleStart( myTeam, otherTeam );
    }

    public override void OnFriendSummoned( Team myTeam, PetData summonedFriend )
    {
        _friendAhead = myTeam.Pets.GetPetAhead( Position );
        _friendAhead?.OnFriendSummoned( myTeam, summonedFriend );
    }

    public override void OnPetAheadFaint( Team myTeam, Team otherTeam )
    {
        _friendAhead = myTeam.Pets.GetPetAhead( Position );
        base.OnPetAheadFaint( myTeam, otherTeam );
    }

    public override void OnBeforeAttack( Team myTeam, Team otherTeam )
    {
        _friendAhead = myTeam.Pets.GetPetAhead( Position );
        _friendAhead?.OnBeforeAttack( myTeam, otherTeam );
    }

    public override void OnPetAheadAttack( Team myTeam, Team otherTeam )
    {
        _friendAhead = myTeam.Pets.GetPetAhead( Position );
        _friendAhead?.OnPetAheadAttack( myTeam, otherTeam );
    }


}


public class BeePet : PetData
{

}

public class ZombieCricketPet : PetData
{

}

public class RamPet : PetData
{

}

public class DirtyRatPet : PetData
{

}

public class BusPet : PetData
{

}

public class ZombieFlyPet : PetData
{

}

public class ChickPet : PetData
{

}
