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
    void LateUpdate()
    {
        _document.rootVisualElement.Q< Label >( "TeamHealth" ).text = GameManager.TeamOne.Health.ToString();
        _document.rootVisualElement.Q< Label >( "TeamCoins" ).text = GameManager.TeamOne.Coins.ToString();
    }
}
