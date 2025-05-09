using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPackManager : MonoBehaviour
{
    List<Card> vowels = new();
    List<Card> constanants = new();
    List<Card> cardsToChoose;

    public int amountInPack;
    public Transform cardParent;

    GameObject card;

    private void Start()
    {
        foreach (Card card in CardPool.instance.cardSO)
        {
            if (card.isVowel)
            {
                vowels.Add(card);
            }
            else
            {
                constanants.Add(card);
            }
        }
    }
    public void OpenPack(CardPack cardPack)
    {
        cardParent.gameObject.SetActive(true);
        cardsToChoose = new List<Card>();
        if (cardPack.type == BaseItem.ItemType.vowelCardpack)
        {
            card = CardFactory.instance.CreateCard(vowels[Random.Range(0, vowels.Count)]);
        }
        else
        {
            GameObject card = CardFactory.instance.CreateCard(constanants[Random.Range(0, constanants.Count)]);
        }
        for (int i = 0; i < amountInPack; i++)
        {
            
            cardsToChoose.Add(card.GetComponent<SetCard>().card);
            card.transform.SetParent(cardParent);
        }
    }
}
