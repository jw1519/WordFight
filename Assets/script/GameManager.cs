using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int maxCards = 7;
    [Header("transforms")]
    public Transform cards;
    public Transform handCards;
    public Transform useCards;
    public Transform discardedCards;

    [Header("Lists")]
    public List<SetCard> deck = new List<SetCard>();
    public List<SetCard> hand = new List<SetCard>();
    public List<SetCard> discard = new List<SetCard>();

    [Header("Text")]
    public TextMeshProUGUI deckAmountText;
    public TextMeshProUGUI DiscardedAmountText;

    [Header("Buttons")]
    public Button submitButton;
    public Button endTurnButton;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        deckAmountText.SetText(deck.Count.ToString());
        BeginTurn();
    }

    public void BeginTurn()
    {
        DrawCards();
        submitButton.gameObject.SetActive(true);
        endTurnButton.gameObject.SetActive(true);
    }
    public void EndTurn()
    {
        DiscardCards();
        submitButton.gameObject.SetActive(false);
        endTurnButton.gameObject.SetActive(false);
    }
    public void DrawCards()
    {
        DiscardCards();
        if (deck.Count >= maxCards)
        {
            for (int i = 0; i < maxCards; i ++)
            {
                SetCard RandomCard = deck[Random.Range(0, deck.Count)];
                RandomCard.gameObject.SetActive(true);
                RandomCard.transform.SetParent(handCards);
                hand.Add(RandomCard);
                deck.Remove(RandomCard);
            }
            deckAmountText.SetText(deck.Count.ToString());
            
        }
        else
        {
            // put cards from discard pile into deck if deck is empty
            discard.Clear();
            foreach (SetCard card in discard)
            {
                deck.Add(card);
            }
        }
    }
    //discard any unused cards when turn ends
    public void DiscardCards()
    {
        
        foreach (SetCard card in hand)
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
