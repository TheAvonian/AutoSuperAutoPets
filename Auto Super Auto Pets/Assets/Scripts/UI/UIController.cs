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

        List< VisualElement > teamOneHolder = _document.rootVisualElement.Q< GroupBox >( "TeamOne" ).Children().ToList();
        List< VisualElement > teamTwoHolder = _document.rootVisualElement.Q< GroupBox >( "TeamTwo" ).Children().ToList();

        List< VisualElement > shopHolder = _document.rootVisualElement.Q< GroupBox >( "ShopPets" ).Children().ToList();

        for ( int i = 0; i < 5; i++ )
        {
            _teamOnePets[ i ] = new PetCard
            {
                HealthElement = teamOneHolder[ i ].Q< Label >( "PetHealth" ),
                DamageElement = teamOneHolder[ i ].Q< Label >( "PetDamage" ),
                FoodElement = teamOneHolder[ i ].Q< GroupBox >( "PetFood" ),
                ImageElement = teamOneHolder[ i ].Q< GroupBox >( "PetImage" ),
            };

            _teamTwoPets[ i ] = new PetCard
            {
                HealthElement = teamTwoHolder[ i ].Q< Label >( "PetHealth" ),
                DamageElement = teamTwoHolder[ i ].Q< Label >( "PetDamage" ),
                FoodElement = teamTwoHolder[ i ].Q< GroupBox >( "PetFood" ),
                ImageElement = teamTwoHolder[ i ].Q< GroupBox >( "PetImage" ),
            };

            _shopCards[ i ] = new PetCard
            {
                HealthElement = shopHolder[ i ].Q< Label >( "PetHealth" ),
                DamageElement = shopHolder[ i ].Q< Label >( "PetDamage" ),
                FoodElement = shopHolder[ i ].Q< GroupBox >( "PetFood" ),
                ImageElement = shopHolder[ i ].Q< GroupBox >( "PetImage" ),
            };
        }

        _shopCards[ 5 ] = new PetCard
        {
            HealthElement = shopHolder[ 5 ].Q< Label >( "PetHealth" ),
            DamageElement = shopHolder[ 5 ].Q< Label >( "PetDamage" ),
            FoodElement = shopHolder[ 5 ].Q< GroupBox >( "PetFood" ),
            ImageElement = shopHolder[ 5 ].Q< GroupBox >( "PetImage" ),
        };

        _shopCards[ 6 ] = new PetCard
        {
            HealthElement = shopHolder[ 6 ].Q< Label >( "PetHealth" ),
            DamageElement = shopHolder[ 6 ].Q< Label >( "PetDamage" ),
            FoodElement = shopHolder[ 6 ].Q< GroupBox >( "PetFood" ),
            ImageElement = shopHolder[ 6 ].Q< GroupBox >( "PetImage" ),
        };
    }

    Sprite[] _allSprites;
    PetCard[] _teamOnePets;
    PetCard[] _teamTwoPets;
    PetCard[] _shopCards;

    Label _healthElement;
    Label _coinsElement;
    Label _turnsElement;
    Label _winsElement;
    void LateUpdate()
    {
        _healthElement.text = GameManager.TeamOne.Health.ToString();
        _coinsElement.text = GameManager.TeamOne.Coins.ToString();
        _turnsElement.text = GameManager.TeamOne.Shop.Turn.ToString();
        _winsElement.text = GameManager.TeamOne.Wins.ToString();

        LinkedListNode< PetData > oneNode = GameManager.State is GameManager.GameState.Battle or GameManager.GameState.BattleStart or GameManager.GameState.BattleEnd ? GameManager.BattleTeamOne?.Pets?.First : GameManager.TeamOne?.Pets?.First;
        LinkedListNode< PetData > twoNode = GameManager.BattleTeamTwo?.Pets?.First;
        ShopItem shopNode = GameManager.TeamOne.Shop?.Items?.Count != 0 ? GameManager.TeamOne.Shop?.Items?[ 0 ] : null;
        for ( int i = 0; i < 5; i++ )
        {

            if ( oneNode != null )
            {
                CreatePetCard( _teamOnePets[ i ], oneNode.Value );
                oneNode = oneNode.Next;
            }

            if ( twoNode != null )
            {
                CreatePetCard( _teamTwoPets[ i ], twoNode.Value );
                twoNode = twoNode.Next;
            }

            if ( shopNode != null )
            {
                CreatePetCard( _shopCards[ i ], shopNode );
                shopNode = GameManager.TeamOne.Shop.TryGetItem( i + 1 );
            }
        }

        if ( GameManager.TeamOne.Shop?.Items != null )
        {
            if ( GameManager.TeamOne.Shop.Items.Count > 5 )
            {
                CreatePetCard( _shopCards[ 5 ], GameManager.TeamOne.Shop.Items[ 5 ] );
            }

            if ( GameManager.TeamOne.Shop.Items.Count > 6 )
            {
                CreatePetCard( _shopCards[ 6 ], GameManager.TeamOne.Shop.Items[ 6 ] );
            }
        }

    }

    void CreatePetCard( PetCard petCard, PetData petItem )
    {
        petCard.ImageElement.style.backgroundImage = new StyleBackground( _allSprites.First( x => x.name.Equals( GetPetName( petItem ) ) ) );
        petCard.DamageElement.text = petItem.Damage.ToString();
        petCard.HealthElement.text = petItem.Health.ToString();
        if ( petItem.Food != FoodData.Food.None )
        {
            petCard.FoodElement.style.opacity = 100f;
            petCard.FoodElement.style.backgroundColor = _borderColor;
            petCard.FoodElement.style.backgroundImage = new StyleBackground( _allSprites.First( x => x.name.Equals( petItem.Food.ToString() ) ) );
        } else
        {
            petCard.FoodElement.style.opacity = 0f;
        }

        petCard.ImageElement.style.backgroundColor = _borderColor;
    }

    readonly StyleFloat _borderWidth = new( 0f );
    readonly StyleColor _borderColor = new( new Color( 1, 1, 1, 0 ) );

    readonly StyleFloat _frozenWidth = new( 2f );
    readonly StyleColor _frozenColor = new( Color.cyan );
    void CreatePetCard( PetCard petCard, ShopItem shopItem )
    {
        if ( shopItem.Pet != null )
        {
            CreatePetCard( petCard, shopItem.Pet );
            petCard.DamageElement.parent.style.opacity = 100f;
            petCard.HealthElement.parent.style.opacity = 100f;
        } else if ( shopItem.Food != null )
        {
            petCard.ImageElement.style.backgroundImage = new StyleBackground( _allSprites.First( x => x.name.Equals( shopItem.Food.ToString() ) ) );
            petCard.DamageElement.parent.style.opacity = 0;
            petCard.HealthElement.parent.style.opacity = 0;
        }

        petCard.ImageElement.style.backgroundColor = shopItem.Frozen ? _frozenColor : _borderColor;

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
}
