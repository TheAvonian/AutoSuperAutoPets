public class ShopData
{
    public IShopItem[] Pets { get; } = new IShopItem[ 7 ];
    public IShopItem[] Foods { get; } = new IShopItem[ 2 ];
}

public interface IShopItem
{
    
    public void OnBuy( Team petTeam );

    public void OnSell( Team petTeam );
}

public interface IEntity
{
    public void OnFaint( Team myTeam, Team otherTeam );

    public void OnHurt( Team myTeam, Team otherTeam );

    public void OnBeforeAttack( Team myTeam, Team otherTeam );

    public void OnFrontPet( Team myTeam, Team otherTeam );

}
