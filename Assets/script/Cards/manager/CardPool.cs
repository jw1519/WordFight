using System.Collections.Generic;
using UnityEngine;

public class CardPool : MonoBehaviour
{
    public static CardPool instance;
    public List<GameObject> pooledCards;
    public List<Card> cardSO = new List<Card>();

    public Transform cardParent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        SetUp();
    }
    public void SetUp()
    {
        pooledCards = new List<GameObject>();
        GameObject gameObject;
        foreach (Card card in cardSO)
        {
            gameObject = CardFactory.instance.CreateCard(card);
            gameObject.SetActive(false);
            gameObject.transform.SetParent(cardParent);
            pooledCards.Add(gameObject);
        }
    }
    public GameObject GetPooledCard()
    {
        List<GameObject> cardDeck = CardManager.instance.deck;
        GameObject randomCard = cardDeck[Random.Range(0, cardDeck.Count)];
        return randomCard;
    }
}
