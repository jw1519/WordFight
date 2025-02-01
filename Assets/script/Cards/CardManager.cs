using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;

    public int maxCards = 7;
    [Header("transforms")]
    public Transform cards;
    public Transform handCards;
    public Transform useCards;
    public Transform discardedCards;

    [Header("Lists")]
    public List<GameObject> deck = new List<GameObject>();
    public List<GameObject> hand = new List<GameObject>();
    public List<GameObject> discard = new List<GameObject>();

    [Header("Text")]
    public TextMeshProUGUI deckAmountText;
    public TextMeshProUGUI DiscardedAmountText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //Adds all card to the deck list
        foreach (Transform transform in cards)
        {
            deck.Add(transform.gameObject);
        }
    }
    public void Start()
    {
        DrawCards();
    }

    public void DrawCards()
    {
        DiscardCards();
        if (deck.Count >= maxCards)
        {
            for (int i = 0; i < maxCards; i++)
            {
                GameObject RandomCard = CardPool.instance.GetPooledCard();
                if (RandomCard != null )
                {
                    RandomCard.gameObject.SetActive(true);
                    RandomCard.transform.SetParent(handCards);
                    hand.Add(RandomCard);
                    deck.Remove(RandomCard);
                }
            }
            deckAmountText.SetText(deck.Count.ToString());

        }
        else
        {
            // put cards from discard pile into deck if deck is empty or doesnt have enough cards
            foreach (GameObject card in discard)
            {
                deck.Add(card);
            }
            discard.Clear();
            DrawCards();
        }
    }
    //discard any unused cards when turn ends
    public void DiscardCards()
    {
        foreach (GameObject card in hand)
        {
            discard.Add(card);
        }
        // discard all cards in hand
        for (int i = handCards.childCount - 1; i >= 0; i--)
        {
            Transform child = handCards.GetChild(i);
            child.SetParent(discardedCards);
            child.gameObject.SetActive(false);
        }
        //discard any cards left in use cards
        DiscardUsedCards();
        hand.Clear();
    }
    public void DiscardUsedCards()
    {
        for (int i = useCards.childCount - 1; i >= 0; i--)
        {
            Transform child = useCards.GetChild(i);
            child.SetParent(discardedCards);
            child.gameObject.SetActive(false);
        }
        DiscardedAmountText.SetText(discard.Count.ToString());
    }
}
