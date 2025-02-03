using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPool : MonoBehaviour
{
    public static CardPool instance;
    public List<GameObject> pooledCards;
    public List<Card> cardSO;

    public GameObject cardToPool;
    public Transform cardParent;

    int amountToPool = 26;

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
            gameObject.GetComponent<SetCard>().card = card;
            gameObject.SetActive(false);
            gameObject.transform.SetParent(cardParent);
            pooledCards.Add(gameObject);
        }
    }
    public GameObject GetPooledCard()
    {
        List<GameObject> cardDeck = CardManager.instance.deck;
        for (int i = 0;i < cardDeck.Count;i++)
        {
            if (!pooledCards[i].activeInHierarchy && pooledCards[i].transform.parent == cardParent)
            {
                GameObject randomCard = cardDeck[Random.Range(0, cardDeck.Count)];
                return randomCard;
            }
        }
        return null;
    }
}
