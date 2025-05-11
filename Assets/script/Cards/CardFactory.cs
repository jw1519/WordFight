using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour
{
    public static CardFactory instance;
    public GameObject cardPrefab;
    public GameObject abilityCardPrefab;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }
    public GameObject CreateCard(Card card)
    {
        GameObject instance = Instantiate(cardPrefab);
        instance.GetComponent<SetCard>().card = card;
        return instance;
    }
    public GameObject CreateAbilityItem(BaseItem item)
    {
        GameObject instance = Instantiate(abilityCardPrefab);
        instance.GetComponent<SetItem>().item = item;
        return instance;
    }
}
