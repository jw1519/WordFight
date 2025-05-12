using TMPro;
using UnityEngine;
public abstract class BaseItem : ScriptableObject, IUse
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

    public virtual void Use()
    {
        
    }
}
