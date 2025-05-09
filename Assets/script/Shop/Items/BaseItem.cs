using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseItem : MonoBehaviour
{
    public Sprite cardSprite;

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
        gameObject.GetComponent<Image>().sprite = cardSprite;
        priceText.text = itemPrice.ToString();
    }
    public virtual void BuyItem()
    {
        bool isSold = ShopManager.instance.BuyItem(itemPrice, this);
        if (isSold)
        {
            priceText.enabled = false;
        }
    }
}
