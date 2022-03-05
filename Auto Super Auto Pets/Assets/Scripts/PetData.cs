using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PetData
{
    public Image Image;

    public abstract void OnBuy( Team petTeam );

    public abstract void OnSell( Team petTeam );

    public abstract void OnFaint( Team myTeam, Team otherTeam );

    public abstract void OnHurt( Team myTeam, Team otherTeam );

    public abstract void OnBeforeAttack( Team myTeam, Team otherTeam );
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