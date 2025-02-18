using System.Collections.Generic;
using UnityEngine;

public class CardPool : MonoBehaviour
{
    public static CardPool instance;
    public List<GameObject> pooledCards;
    public List<Card> cardSO;

    public GameObject cardToPool;
    public Transform cardParent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        pooledCards = new List<GameObject>();
        GameObject gameObject;
        foreach (Card card in cardSO)
        {
            gameObject = Instantiate(cardToPool);
            gameObject.GetComponent<SetCard>().card = Instantiate(card);
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
