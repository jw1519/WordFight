//Manages dealing and discarding cards
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

    [Header("Lists")]
    public List<GameObject> cardsInDeck = new();
    public List<GameObject> cardsInHand = new();
    public List<GameObject> cardsInDiscard = new();
    public List<GameObject> savedCards = new();

    [Header("Text")]
    public TextMeshProUGUI deckAmountText;
    public TextMeshProUGUI discardedAmountText;

    CardSlots handSlot;
    CardHand hand;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        //Adds all card to the deck list
        foreach (Transform transform in cards)
        {
            cardsInDeck.Add(transform.gameObject);
        }
        handSlot = handCards.GetComponent<CardSlots>();
        hand = FindAnyObjectByType<CardHand>();
    }
    public void DrawCards()
    {
        DiscardCards();
        if (cardsInDeck.Count >= maxCards)
        {
            for (int i = 0; i < maxCards; i++)
            {
                GameObject RandomCard = CardPool.instance.GetPooledCard();
                if (RandomCard != null )
                {
                    //RandomCard.gameObject.SetActive(true);
                    //RandomCard.transform.SetParent(handCards);
                    //cardsInHand.Add(RandomCard);
                    //cardsInDeck.Remove(RandomCard);
                    //handSlot.cards.Add(RandomCard);

                    RandomCard.gameObject.SetActive(true);
                    //RandomCard.transform.SetParent(hand.transform, false);
                    cardsInHand.Add(RandomCard);
                    StartCoroutine(hand.AddCard(RandomCard));
                    cardsInDeck.Remove(RandomCard);
                    RandomCard.GetComponent<Hover>().enabled = true;
                    RandomCard.GetComponent<DragAndDrop>().enabled = true;
                }
            }
            //if doesnt have any vowels draw a new hand
            if (CheckForVowels() == false)
            {
                DrawCards();
            }
            deckAmountText.SetText(cardsInDeck.Count.ToString());
            //handCards.GetComponent<CardSlots>().UpdateCards();
        }
        else
        {
            // put cards from discard pile into deck if deck is empty or doesnt have enough cards
            foreach (GameObject card in cardsInDiscard)
            {
                cardsInDeck.Add(card);
            }
            cardsInDiscard.Clear();
            DrawCards();
        }
    }
    //discard any unused cards when turn ends
    public void DiscardCards()
    {
        // add all cards in hand to discard list
        foreach (GameObject card in cardsInHand)
        {
            cardsInDiscard.Add(card);
        }
        // discard all cards in hand
        for (int i = handCards.childCount - 1; i >= 0; i--)
        {
            Transform child = handCards.GetChild(i);
            child.SetParent(cards);
            child.gameObject.SetActive(false);

            // remove from saved cards list if they are in it
            if (savedCards.Contains(child.gameObject))
            {
                savedCards.Remove(child.gameObject);
                cardsInDiscard.Add(child.gameObject);
            }
        }
        //discard any cards left in use cards and lists
        DiscardUsedCards();
        cardsInHand.Clear();
        handSlot.cards.Clear();
    }
    public void DiscardUsedCards()
    {
        for (int i = useCards.childCount - 1; i >= 0; i--)
        {
            Transform child = useCards.GetChild(i);
            child.SetParent(cards);
            child.gameObject.SetActive(false);

            // remove from saved cards list if they are in it
            if (savedCards.Contains(child.gameObject))
            {
                savedCards.Remove(child.gameObject);
                cardsInDiscard.Add(child.gameObject);
            }
        }
        discardedAmountText.SetText(cardsInDiscard.Count.ToString());
        useCards.GetComponent<CardSlots>().cards.Clear();
    }
    // check if hand contains at least one vowel
    public bool CheckForVowels()
    {
        foreach (GameObject go in cardsInHand)
        {
            if (go.GetComponent<SetCard>().card.isVowel == true)
            {
                return true;
            }
        }
        return false;
    }
}
