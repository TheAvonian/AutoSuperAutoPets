using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class PetData : ScriptableObject, IShopItem, IEntity
{
    public PetType Type;
    public Image Image;
    public List< Ability > Abilities;
    
    public void OnBuy( Team petTeam )
    {
        
    }

    public void OnSell( Team petTeam )
    {
    }

    public void OnFaint( Team myTeam, Team otherTeam )
    {
        
    }

    public void OnHurt( Team myTeam, Team otherTeam )
    {
    }

    public void OnBeforeAttack( Team myTeam, Team otherTeam )
    {
    }

    public void OnFrontPet( Team myTeam, Team otherTeam )
    {
    }
}

public enum PetType
{
    None,
    Ant,
    
}