using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseItem : MonoBehaviour
{
    public string itemDescription;
    public Sprite cardSprite;
    public int itemPrice;

    public virtual void Awake()
    {
        gameObject.GetComponent<Image>().sprite = cardSprite;
    }
    public void BuyItem()
    {
        ShopManager.instance.BuyItem(itemPrice, this);
    }
}
