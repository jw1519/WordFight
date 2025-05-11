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
    public GameObject buttonPanel;

    Player player;
    CardPackManager cardPackManager;
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
        cardPackManager = FindAnyObjectByType<CardPackManager>();
    }
    public void OnClick()
    {
        buttonPanel.SetActive(true);
    }

    public void Use()
    {
        if (item.type == BaseItem.ItemType.abilitycard)
        {
            if (item.isSold == true)
            {
                player.RemoveItem(item);
                Destroy(gameObject);
                //do thing
            }
        }
        else
        {
            cardPackManager.OpenPack(item);
        }
    }
    public void Buy()
    {
        Debug.Log("buy");
        item.BuyItem();
    }
}
