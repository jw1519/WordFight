using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    public string itemDescription;
    public Sprite cardSprite;
    public int itemPrice;

    public void BuyItem()
    {
        ShopManager.instance.BuyItem(itemPrice, this);
    }
}
