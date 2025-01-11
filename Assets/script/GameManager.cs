using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Transform cards;
    public List<SetCard> deck = new List<SetCard>();
    public Transform handCards;
    public List<SetCard> hand = new List<SetCard>();
    public List<SetCard> discard = new List<SetCard>();
    public int maxCards;
    public TextMeshProUGUI deckAmountText;
    public TextMeshProUGUI DiscardedAmountText;

    public void Start()
    {
        deckAmountText.SetText(deck.Count.ToString());
        DrawCards();
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
            }
            deckAmountText.SetText(deck.Count.ToString());
            
        }
        else
        {
            discard.Clear();
            foreach (SetCard card in discard)
            {
                deck.Add(card);
            }
        }
    }
    public void DiscardCards()
    {
        hand.Clear();
        foreach (SetCard card in handCards)
        {
            discard.Add(card);
            card.gameObject.SetActive(false);
            card.transform.SetParent(cards);
        }
        DiscardedAmountText.SetText(discard.Count.ToString());
    }
}
