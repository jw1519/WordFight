using UnityEngine;

public abstract class Item : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public int itemPrice;

    public void BuyItem()
    {
        ShopManager.instance.BuyItem(itemPrice, this);
    }
}
