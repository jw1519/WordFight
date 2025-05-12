using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPackManager : MonoBehaviour
{
    List<Card> vowels = new();
    List<Card> constanants = new();
    List<Card> cardsToChoose;

    public int amountInPack;
    public Transform cardParent;

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
        GameObject card;
        cardParent.gameObject.SetActive(true);
        cardsToChoose = new List<Card>();

        for (int i = 0; i < cardPack.amountInPack; i++)
        {
            card = SelectRandomCard(cardPack);
            cardsToChoose.Add(card.GetComponent<SetCard>().card);
            card.transform.SetParent(cardParent);
            card.GetComponent<Button>().enabled = true;
            cardParent.GetComponent<CardPackPanel>().cards.Add(card);
        }
    }
    public GameObject SelectRandomCard(BaseItem cardPack)
    {
        GameObject instance;
        if (cardPack.type == BaseItem.ItemType.vowelCardpack)
        {
            instance = CardFactory.instance.CreateCard(vowels[Random.Range(0, vowels.Count)]);
            instance.GetComponent<Hover>().enabled = false;
            return instance;
        }
        else if (cardPack.type == BaseItem.ItemType.constantCardPack)
        {
            instance = CardFactory.instance.CreateCard(constanants[Random.Range(0, constanants.Count)]);
            instance.GetComponent<Hover>().enabled = false;
            return instance;
        }
        else 
        {
            return null; 
        }
    }
}
