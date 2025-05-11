using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : BasePanel
{
    public List<SetItem> possibleItemsForShop;
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

        itemsInShop.Clear();

        int childAmount = abilityCardContainer.transform.childCount;
        for (int i = 0; i < childAmount; childAmount--)
        {
            Destroy(abilityCardContainer.transform.GetChild(i));
        }

        childAmount = cardPackContainer.transform.childCount;
        for (int i = 0; i < childAmount; childAmount--)
        {
            Destroy(abilityCardContainer.transform.GetChild(i));
        }

        for (int i = 0; i < abilityCardContainerMaxAmount; i++)
        {
            GameObject item = CardFactory.instance.CreateAbilityItem(possibleItemsForShop[i].item);
            itemsInShop.Add(item.GetComponent<SetItem>());
            item.transform.SetParent(abilityCardContainer);
        }
    }

    public void AddItemToShop(SetItem item)
    {
        itemsInShop.Add(item);
        switch (item.item.type)
        {
            case BaseItem.ItemType.constantCardPack:
                if (cardPackContainer.childCount < cardPackContainerMaxAmount)
                {
                    Instantiate(item, cardPackContainer);
                }
                break;
            case BaseItem.ItemType.vowelCardpack:
                if (cardPackContainer.childCount < cardPackContainerMaxAmount)
                {
                    Instantiate(item, cardPackContainer);
                }
                break;

            case BaseItem.ItemType.abilitycard:
                if (abilityCardContainer.childCount < abilityCardContainerMaxAmount)
                {
                    Instantiate(item, abilityCardContainer);
                }
                break;
        }
    }

}
