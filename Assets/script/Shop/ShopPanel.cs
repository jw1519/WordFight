using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : BasePanel
{
    public List<BaseItem> possibleItemsForShop;
    public List<SetItem> itemsInShop;

    [Header("itemsPanels")]
    public Transform cardPackContainer;
    public Transform abilityCardContainer;

    [Header("AmountInShop")]
    public int cardPackContainerMaxAmount;
    public int abilityCardContainerMaxAmount;

    private void OnEnable()
    {
        if (ShopManager.instance != null)
        {
            ShopManager.instance.UpdatePrices();
        }

        foreach (SetItem item in itemsInShop)
        {
            Destroy(item.gameObject);
        }
        itemsInShop.Clear();

        for (int i = 0; i < abilityCardContainerMaxAmount; i++)
        {
            AddItemToShop(possibleItemsForShop[i]);
        }

        //for (int i = 0; i < cardPackContainerMaxAmount; ++i)
        //{
        //    if (possibleItemsForShop[i] != null)
        //    {
        //        AddItemToShop(possibleItemsForShop[i]);
        //    }
        //}
    }

    public void AddItemToShop(BaseItem item)
    {
        switch (item.type)
        {
            case BaseItem.ItemType.constantCardPack:
                if (cardPackContainer.childCount < cardPackContainerMaxAmount)
                {
                    if (CardFactory.instance != null)
                    {
                        GameObject instance = CardFactory.instance.CreateItem(Instantiate(item));
                        instance.transform.SetParent(cardPackContainer);
                        itemsInShop.Add(instance.GetComponent<SetItem>());
                    }  
                }
                break;
            case BaseItem.ItemType.vowelCardpack:
                if (cardPackContainer.childCount < cardPackContainerMaxAmount)
                {
                    if (CardFactory.instance != null)
                    {
                        GameObject instance = CardFactory.instance.CreateItem(Instantiate(item));
                        instance.transform.SetParent(cardPackContainer);
                        itemsInShop.Add(instance.GetComponent<SetItem>());
                    }
                }
                break;

            case BaseItem.ItemType.abilitycard:
                if (abilityCardContainer.childCount < abilityCardContainerMaxAmount)
                {
                    if (CardFactory.instance != null)
                    {
                        GameObject instance = CardFactory.instance.CreateItem(Instantiate(item));
                        instance.transform.SetParent(abilityCardContainer);
                        itemsInShop.Add(instance.GetComponent<SetItem>());
                    }   
                }
                break;
        }
    }

}
