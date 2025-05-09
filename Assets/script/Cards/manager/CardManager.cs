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
    public List<GameObject> deck = new();
    public List<GameObject> hand = new();
    public List<GameObject> discard = new();
    public List<GameObject> savedCards = new();

    [Header("Text")]
    public TextMeshProUGUI deckAmountText;
    public TextMeshProUGUI discardedAmountText;

    CardSlots handSlot;
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
        handSlot = handCards.GetComponent<CardSlots>();
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
                    handSlot.cards.Add(RandomCard);
                }
            }
            //if doesnt have any vowels draw a new hand
            if (CheckForVowels() == false)
            {
                DrawCards();
            }
            deckAmountText.SetText(deck.Count.ToString());
            handCards.GetComponent<CardSlots>().UpdateCards();
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
        // add all cards in hand to discard list
        foreach (GameObject card in hand)
        {
            discard.Add(card);
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
                discard.Add(child.gameObject);
            }
        }
        //discard any cards left in use cards and lists
        DiscardUsedCards();
        hand.Clear();
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
                discard.Add(child.gameObject);
            }
        }
        discardedAmountText.SetText(discard.Count.ToString());
        useCards.GetComponent<CardSlots>().cards.Clear();
    }
    // check if hand contains at least one vowel
    public bool CheckForVowels()
    {
        foreach (GameObject go in hand)
        {
            if (go.GetComponent<SetCard>().card.isVowel == true)
            {
                return true;
            }
        }
        return false;
    }
}
