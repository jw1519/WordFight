using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseItem : ScriptableObject
{
    public Sprite cardSprite;
    public bool isSold;
    public string itemDescription;
    [Header("Price")]
    public int itemPrice;
    public TextMeshProUGUI priceText;

    public ItemType type;
    public enum ItemType
    {
        vowelCardpack,
        constantCardPack,
        abilitycard
    }

    public virtual void Awake()
    {
        isSold = false;
    }
    public virtual void BuyItem()
    {
        //is it isnt sold check if it can be
        if (!isSold)
        {
            isSold = ShopManager.instance.BuyItem(itemPrice, this);
            if (isSold)
            {
                priceText.enabled = false;
            }
        }
    }
}
