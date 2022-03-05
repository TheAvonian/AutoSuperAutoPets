using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PetData
{
    public Image Image;
    public int Health;
    public int Damage;
    public int Level;

    public virtual void OnBuy( Team petTeam )
    {
        foreach(PetData friend in petTeam.Pets) {
            if(friend == this) continue;
            friend.OnFriendSummoned(petTeam, null);
        }
    }

    public virtual void OnSell( Team petTeam )
    {
        
    }

    public virtual void OnFaint( Team myTeam, Team otherTeam )
    {
        myTeam.Pets.Remove(this);
    }

    public virtual void OnHurt( Team myTeam, Team otherTeam )
    {

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

    public virtual void OnFriendSummoned( Team myTeam, Team otherTeam )
    {

    }

    public virtual void OnFaintEnemy( Team myTeam, Team otherTeam )
    {

    }

    public virtual void OnFriendFaints( Team myTeam, Team otherTeam )
    {

    }

    public virtual void OnEatShopFood( Team myTeam, Team otherTeam )
    {

    }
}

public class AntPet : PetData {
    public override void OnFaint(Team myTeam, Team otherTeam)
    {
        base.OnFaint(myTeam, otherTeam);

        List<PetData> friends = new List<PetData>(myTeam.Pets);
        PetData randomFriend = friends[Random.Range(0, friends.Count-1)];
        
        randomFriend.Damage += 2 * Level;
        randomFriend.Health += 1 * Level;
    }
}

public class BeaverPet : PetData {
    public override void OnBuy(Team petTeam)
    {
        base.OnBuy(petTeam);
        PetData[] friends = petTeam.Pets;
        friends.
        
    }


}

public class CricketPet : PetData {
    
}

public class DuckPet : PetData {
    
}

public class FishPet : PetData {
    
}

public class HorsePet : PetData {
    
}

public class MosquitoPet : PetData {
    
}

public class OtterPet : PetData {
    
}

public class PigPet : PetData {
    
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