using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public List<BaseItem> possibleItemsForShop;

    public Transform cardPackContainer;
    public Transform abilityCardContainer;

    public List <BaseItem> itemsInShop;
    BasePlayer player;

    private void OnEnable()
    {
        AddItemToShop(possibleItemsForShop[0]);
    }
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
            case BaseItem.ItemType.cardpack:
                Instantiate(item, cardPackContainer);
                break;

            case BaseItem.ItemType.abilitycard:
                Instantiate(item, abilityCardContainer);
                break;
        }
    }
    public bool BuyItem(int price, BaseItem item)
    {
        if (player.gold - price >= 0)
        {
            itemsInShop.Remove(item);
            //add item to items UI
            return true;
        }
        else
        {
            Debug.Log("Not enough money");
            return false;
        }
    }
}
