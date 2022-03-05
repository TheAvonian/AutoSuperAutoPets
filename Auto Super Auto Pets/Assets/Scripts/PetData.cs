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

    public virtual void OnTurnStart( Team myTeam )
    {
        
    }

    public virtual void OnTurnEnd( Team myTeam )
    {
        
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
    public override void OnBuy(Team petTeam)
    {
        base.OnBuy(petTeam);
        
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