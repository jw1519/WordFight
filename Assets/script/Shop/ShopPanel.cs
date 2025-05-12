using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : BasePanel
{
    public List<BaseItem> possibleItemsForShop;
    public List<SetItem> itemsInShop;

    [Header("itemsPanels")]
    public Transform cardPackContainer;
    public Transform abilityCardContainer;
    public int cardPackContainerMaxAmount;
    public int abilityCardContainerMaxAmount;

    private void OnEnable()
    {
        ShopManager.instance.UpdatePrices();
        GameManager.instance.isGameDone = true;
        foreach (SetItem item in itemsInShop)
        {
            Destroy(item.gameObject);
        }
        itemsInShop.Clear();

        for (int i = 0; i < abilityCardContainerMaxAmount; i++)
        {
            AddItemToShop(possibleItemsForShop[i]);
        }

        for (int i = 0; i < cardPackContainerMaxAmount; ++i)
        {
            AddItemToShop(possibleItemsForShop[i]);
        }
    }

    public void AddItemToShop(BaseItem item)
    {
        switch (item.type)
        {
            case BaseItem.ItemType.constantCardPack:
                if (cardPackContainer.childCount < cardPackContainerMaxAmount)
                {
                    GameObject instance = CardFactory.instance.CreateItem(Instantiate(item));
                    instance.transform.SetParent(cardPackContainer);
                    itemsInShop.Add(instance.GetComponent<SetItem>());
                }
                break;
            case BaseItem.ItemType.vowelCardpack:
                if (cardPackContainer.childCount < cardPackContainerMaxAmount)
                {
                    GameObject instance = CardFactory.instance.CreateItem(Instantiate(item));
                    instance.transform.SetParent(cardPackContainer);
                    itemsInShop.Add(instance.GetComponent<SetItem>());
                }
                break;

            case BaseItem.ItemType.abilitycard:
                if (abilityCardContainer.childCount < abilityCardContainerMaxAmount)
                {
                    GameObject instance = CardFactory.instance.CreateItem(Instantiate(item));
                    instance.transform.SetParent(abilityCardContainer);
                    itemsInShop.Add(instance.GetComponent<SetItem>());
                }
                break;
        }
    }

}
