using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent( typeof( UIDocument ) )]
public class UIController : MonoBehaviour
{
    public GameManager GameManager;

    UIDocument _document;

    VisualElement _teamsElement;
    VisualElement _teamOneElement;
    VisualElement _teamTwoElement;
    VisualElement _shopElement;

    void Awake()
    {
        _document = GetComponent< UIDocument >();
    }

    void Start()
    {
        _allSprites = Resources.LoadAll( "Pets", typeof( Sprite ) ).Cast< Sprite >().ToArray();

        _teamOnePets = new PetCard[ 5 ];
        _teamTwoPets = new PetCard[ 5 ];

        _shopCards = new PetCard[ 7 ];

        _healthElement = _document.rootVisualElement.Q< Label >( "TeamHealth" );
        _coinsElement = _document.rootVisualElement.Q< Label >( "TeamCoins" );
        _turnsElement = _document.rootVisualElement.Q< Label >( "TeamTurns" );
        _winsElement = _document.rootVisualElement.Q< Label >( "TeamWins" );

        _teamOneElement = _document.rootVisualElement.Q< GroupBox >( "TeamOne" );
        _teamTwoElement = _document.rootVisualElement.Q< GroupBox >( "TeamTwo" );
        _shopElement = _document.rootVisualElement.Q< GroupBox >( "ShopPets" );
        _teamsElement = _teamOneElement.parent;

        List< VisualElement > teamOneHolder = _teamOneElement.Children().ToList();
        List< VisualElement > teamTwoHolder = _teamTwoElement.Children().ToList();

        List< VisualElement > shopHolder = _shopElement.Children().ToList();

        for ( int i = 0; i < 5; i++ )
        {
            _teamOnePets[ i ] = CreateCard( teamOneHolder[ i ] );

            _teamTwoPets[ i ] = CreateCard( teamTwoHolder[ i ] );

            _shopCards[ i ] = CreateCard( shopHolder[ i ] );
        }

        _shopCards[ 5 ] = CreateCard( shopHolder[ 5 ] );

        _shopCards[ 6 ] = CreateCard( shopHolder[ 6 ] );

        PetCard CreateCard( VisualElement element )
        {
            return new PetCard
            {
                HealthElement = element.Q< Label >( "PetHealth" ),
                DamageElement = element.Q< Label >( "PetDamage" ),
                FoodElement = element.Q< GroupBox >( "PetFood" ),
                ImageElement = element.Q< GroupBox >( "PetImage" ),
                LevelElement = element.Q< Label >( "Level" ),
                StackElement = element.Q< Label >( "Stack" ),
            };
        }
    }

    const string FIGHT_STYLE_TEAM = "fight-style";
    const string FIGHT_STYLE_BOX = "fight-box";

    Sprite[] _allSprites;
    PetCard[] _teamOnePets;
    PetCard[] _teamTwoPets;
    PetCard[] _shopCards;

    Label _healthElement;
    Label _coinsElement;
    Label _turnsElement;
    Label _winsElement;
    void FixedUpdate()
    {
        _healthElement.text = GameManager.TeamOne.Health.ToString();
        _coinsElement.text = GameManager.TeamOne.Coins.ToString();
        _turnsElement.text = GameManager.TeamOne.Shop.Turn.ToString();
        _winsElement.text = GameManager.TeamOne.Wins.ToString();

        bool inBattle = GameManager.State is GameManager.GameState.Battle or GameManager.GameState.BattleStart or GameManager.GameState.BattleEnd;

        LinkedListNode< PetData > oneNode = inBattle ? GameManager.BattleTeamOne?.Pets?.First : GameManager.TeamOne?.Pets?.First;
        LinkedListNode< PetData > twoNode = GameManager.BattleTeamTwo?.Pets?.First;
        ShopItem shopNode = GameManager.TeamOne.Shop.GetFirst();

        _teamsElement.EnableInClassList( FIGHT_STYLE_BOX, inBattle );
        _teamOneElement.EnableInClassList( FIGHT_STYLE_TEAM, inBattle );
        for ( int i = 0; i < 5; i++ )
        {
            CreatePetCard( _teamOnePets[ i ], oneNode?.Value );
            oneNode = oneNode?.Next;

            CreatePetCard( _teamTwoPets[ i ], twoNode?.Value );
            twoNode = twoNode?.Next;

            CreatePetCard( _shopCards[ i ], shopNode );
            shopNode = GameManager.TeamOne.Shop.TryGetItem( i + 1 );
        }

        if ( GameManager.TeamOne.Shop?.Items != null )
        {
            CreatePetCard( _shopCards[ 5 ], GameManager.TeamOne.Shop.Items[ 5 ] );

            CreatePetCard( _shopCards[ 6 ], GameManager.TeamOne.Shop.Items[ 6 ] );
        }

    }

    void CreatePetCard( PetCard petCard, PetData petItem )
    {
        if ( petItem is null )
        {
            petCard.ClearPet();
            return;
        }

        petCard.SetPetImage( new StyleBackground( _allSprites.First( x => x.name.Equals( GetPetName( petItem ) ) ) ) );
        petCard.SetStats( petItem.Damage, petItem.Health, petItem.Level, petItem.StackHeight );
        if ( petItem.Food is not FoodData.Food.None )
        {
            petCard.SetFoodImage( new StyleBackground( _allSprites.First( x => x.name.Equals( petItem.Food.ToString() ) ) ) );
        } else
        {
            petCard.FoodElement.style.opacity = 0f;
        }

        petCard.ImageElement.style.backgroundColor = Color.clear;
        petCard.ShowStats( true );
        petCard.ShowLevel( true );
    }

    void CreatePetCard( PetCard petCard, ShopItem shopItem )
    {
        if ( shopItem is null )
        {
            petCard.ClearPet();
            return;
        }

        if ( shopItem.Pet is { } )
        {
            CreatePetCard( petCard, shopItem.Pet );
            petCard.ShowStats( true );

        } else if ( shopItem.Food is { } )
        {
            petCard.SetPetImage( new StyleBackground( _allSprites.First( x => x.name.Equals( shopItem.Food.ToString() ) ) ) );
            petCard.ShowStats( false );
        }

        petCard.ShowLevel( false );
        petCard.ImageElement.style.backgroundColor = shopItem.Frozen ? Color.cyan : Color.clear;

        petCard.FoodElement.style.opacity = 0f;
    }

    static string GetPetName( PetData item )
    {
        return item != null ? ( (PetData.AllPets) item.PetID ).ToString() : null;
    }

    static string GetShopItemName( ShopItem item )
    {
        if ( item != null )
        {
            if ( item.Food != null )
            {
                return item.Food.ToString();
            }

            if ( item.Pet != null )
            {
                return ( (PetData.AllPets) item.Pet.PetID ).ToString();
            }
        }

        return null;
    }
}

class PetCard
{
    public VisualElement ImageElement;
    public VisualElement FoodElement;
    public Label DamageElement;
    public Label HealthElement;
    public Label LevelElement;
    public Label StackElement;

    public void SetPetImage( StyleBackground image )
    {
        ImageElement.style.backgroundColor = Color.clear;
        ImageElement.style.opacity = 1f;
        ImageElement.style.backgroundImage = image;
    }

    public void SetFoodImage( StyleBackground image )
    {
        FoodElement.style.opacity = 1f;
        FoodElement.style.backgroundColor = Color.clear;
        FoodElement.style.backgroundImage = image;
    }

    public void ShowStats( bool show )
    {
        DamageElement.parent.style.opacity = show ? 1f : 0;
        HealthElement.parent.style.opacity = show ? 1f : 0;
    }

    public void ShowLevel( bool show )
    {
        StackElement.parent.style.opacity = show ? 1f : 0;
    }

    public void SetStats( int damage, int health, int level, int stack )
    {
        DamageElement.parent.style.opacity = 1f;
        HealthElement.parent.style.opacity = 1f;
        DamageElement.text = damage.ToString();
        HealthElement.text = health.ToString();
        StackElement.parent.style.opacity = 1f;
        StackElement.text = stack.ToString();
        LevelElement.text = level.ToString();
    }

    public void ClearPet()
    {
        ImageElement.style.backgroundColor = Color.clear;
        ImageElement.style.opacity = 0;
        FoodElement.style.opacity = 0;
        DamageElement.parent.style.opacity = 0;
        HealthElement.parent.style.opacity = 0;
        StackElement.parent.style.opacity = 0;
    }
}
