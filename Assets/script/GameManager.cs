using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform cardDeck;
    public GameObject cardPrefab;
    public Button submitButton;
    public Button endTurnButton;

    int turnCount;
    SetEnemy enemy;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        enemy = FindObjectOfType<SetEnemy>();
        turnCount = 0;
    }
    public void SetUpGame()
    {

    }

    public void BeginTurn()
    {
        if ( turnCount == 0 )
        {

        }
        CardManager.instance.DrawCards();
        submitButton.gameObject.SetActive(true);
        endTurnButton.gameObject.SetActive(true);
    }
    public void EndTurn()
    {
        turnCount++;
        Player.instance.RemoveDecorator();
        CardManager.instance.DiscardCards();
        submitButton.gameObject.SetActive(false);
        endTurnButton.gameObject.SetActive(false);
        enemy.StartTurn();
    }
}
