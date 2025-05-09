using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public List<BaseItem> possibleItemsForShop;
    public List<BaseItem> itemsInShop;

    [Header("itemsPanels")]
    public Transform cardPackContainer;
    public Transform abilityCardContainer;
    public int cardPackContainerMaxAmount;
    public int abilityCardContainerMaxAmount;

    BasePlayer player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        player = FindFirstObjectByType<BasePlayer>();
    }
    public void AddItemToShop(BaseItem item)
    {
        itemsInShop.Add(item);
        switch (item.type)
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
    public bool BuyItem(int price, BaseItem item)
    {
        if (player.gold - price >= 0)
        {
            
            player.gold -= price;
            UpdatePrices();
            player.items.Add(item);
            itemsInShop.Remove(item);
            player.playerUI.UpdateItemsText(player.itemsAmount);
            //add item to items UI
            return true;
        }
        else
        {
            Debug.Log("Not enough money");
            return false;
        }
    }
    public void UpdatePrices()
    {
        foreach (BaseItem item in itemsInShop)
        {
            if (item.itemPrice <= player.gold)
            {
                item.priceText.color = Color.green;
            }
            else
            {
                item.priceText.color = Color.red;
            }
        }
    }
}
