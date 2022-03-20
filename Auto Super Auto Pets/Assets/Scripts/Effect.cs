
using System;

[Serializable]
public class Ability
{
    public Trigger Trigger;
    public Effect Effect;

    public GiveStatsData StatsData;
}

[Serializable]
public class Trigger
{
    public TriggerType TriggerType;
    public Target Target;
}

public enum TriggerType
{
    None,
    OnBuy,
    OnSell,
    OnBattleStart,
    OnTurnStart,
    OnTurnEnd,
    OnHurt,
    OnFaint,
    OnAttack,
    OnAbility,
}

public enum Target
{
    None,
    Self,
    FriendBehind,
    FriendAhead,
    FriendInFront,
    FriendInBack,
    AllOnlyFriends,
    AllSelfFriends,
    AllEnemies,
    All,
    ShopPets,
    ShopFoods,
}

public enum Effect
{
    None,
    Faint,
    GiveStats,
    Hurt,
    Swallow,
    Repeat,
    
}

[Serializable]
public class GiveStatsData
{
    public int Damage;
    public int Health;

    public bool Temporary;
}