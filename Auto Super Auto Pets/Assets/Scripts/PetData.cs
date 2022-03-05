using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PetData
{
    public Image Image;

    public virtual void OnBuy( Team petTeam )
    {
    }

    public virtual void OnSell( Team petTeam )
    {
    }

    public virtual void OnFaint( Team myTeam, Team otherTeam )
    {
    }

    public virtual void OnHurt( Team myTeam, Team otherTeam )
    {
    }

    public virtual void OnBeforeAttack( Team myTeam, Team otherTeam )
    {
    }

    public virtual void OnTurnStart( Team myTeam )
    {
    }
}

public class AntPet : PetData
{

    public override void OnBuy( Team petTeam )
    {
    }

    public override void OnSell( Team petTeam )
    {
    }

    public override void OnFaint( Team myTeam, Team otherTeam )
    {
    }

    public override void OnHurt( Team myTeam, Team otherTeam )
    {
    }

    public override void OnBeforeAttack( Team myTeam, Team otherTeam )
    {
    }
}