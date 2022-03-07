using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
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
        _healthElement = _document.rootVisualElement.Q< Label >( "TeamHealth" );
        _coinsElement = _document.rootVisualElement.Q< Label >( "TeamCoins" );
        _turnsElement = _document.rootVisualElement.Q< Label >( "TeamTurns" );
        _winsElement = _document.rootVisualElement.Q< Label >( "TeamWins" );
    }

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
    }
}
