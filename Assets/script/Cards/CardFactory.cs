using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour
{
    public static CardFactory instance;
    public GameObject cardPrefab;
    public GameObject abilityCardPrefab;
    public GameObject cardPackPrefab;

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
    public GameObject CreateItem(BaseItem item)
    {
        GameObject instance = null;
        switch (item.type)
        {
            case BaseItem.ItemType.abilitycard:
                instance = Instantiate(abilityCardPrefab);
                instance.GetComponent<SetItem>().item = item;
                return instance;

            case BaseItem.ItemType.vowelCardpack:
                instance = Instantiate(cardPackPrefab);
                instance.GetComponent<SetItem>().item = item;
                return instance;
            case BaseItem.ItemType.constantCardPack:
                instance = Instantiate(cardPackPrefab);
                instance.GetComponent<SetItem>().item = item;
                return instance;
        }
        return null;
        
    }
}
