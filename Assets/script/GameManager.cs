using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<Card> cardSO = new List<Card>();
    public Transform cardDeck;
    public GameObject cardPrefab;

    [Header("buttons")]
    public Button submitButton;
    public Button endTurnButton;

    SetEnemy enemy;
    private void Awake()
    {
        SetUpGame();
        if (instance == null)
        {
            instance = this;
        }
        enemy = FindObjectOfType<SetEnemy>();
    }
    public void SetUpGame()
    {
        foreach (Card cards in cardSO)
        {
            GameObject card = Instantiate(cardPrefab);
            card.GetComponent<SetCard>().card = cards;
            card.transform.SetParent(cardDeck);
        }
    }

    public void BeginTurn()
    {
        CardManager.instance.DrawCards();
        submitButton.gameObject.SetActive(true);
        endTurnButton.gameObject.SetActive(true);
    }
    public void EndTurn()
    {
        Player.instance.RemoveDecorator();
        CardManager.instance.DiscardCards();
        submitButton.gameObject.SetActive(false);
        endTurnButton.gameObject.SetActive(false);
        enemy.StartTurn();
    }
}
