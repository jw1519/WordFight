using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetItem : MonoBehaviour
{
    public BaseItem item;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI descriptionText;
    public GameObject buyButton;
    public GameObject UseButton;

    Player player;
    public void Awake()
    {
        gameObject.GetComponent<Image>().sprite = item.cardSprite;
        item.priceText = priceText;
        priceText.text = item.itemPrice.ToString();
        if (descriptionText != null )
        {
            descriptionText.text = item.itemDescription;
        }

        player = FindAnyObjectByType<Player>();
        item.isSold = false;
    }

    public void Use()
    {
        if (item.isSold == true)
        {
            if (item.type == BaseItem.ItemType.abilitycard)
            {
                player.RemoveItem(item);
            }
            item.Use();
            Destroy(gameObject);
        }
    }
    public void BuyItem()
    {
        //is it isnt sold check if it can be
        if (!item.isSold)
        {
            item.isSold = ShopManager.instance.BuyItem(item.itemPrice, this);
            if (item.isSold)
            {
                priceText.enabled = false;
                buyButton.SetActive(false);
                if (UseButton != null)
                    UseButton.SetActive(true);
            }
        }
    }
}
