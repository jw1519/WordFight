using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    List <BaseItem> items;
    BasePlayer player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        player = FindFirstObjectByType<BasePlayer>();
    }
    public void AddItemToList(BaseItem item)
    {
        items.Add(item);
    }
    public void BuyItem(int price, BaseItem item)
    {
        if (player.gold - price >= 0)
        {
            items.Remove(item);
            //add item to items UI
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
}
