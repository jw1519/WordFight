using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    BasePanel shopPanel;
    BasePlayer player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        player = FindFirstObjectByType<BasePlayer>();
        shopPanel = UIManager.instance.GetPanel("ShopPanel");
    }
    public bool BuyItem(int price, SetItem item)
    {
        if (player.gold - price >= 0)
        {
            //add item to items UI
            if (item.item.type == BaseItem.ItemType.abilitycard)
            {
                if (player.itemParent.childCount < player.maxItems)
                {
                    player.gold -= price;
                    UpdatePrices();
                    shopPanel.gameObject.GetComponent<ShopPanel>().itemsInShop.Remove(item);
                    player.AddItem(item);
                }
            }
            else
            {
                player.gold -= price;
                UpdatePrices();
                shopPanel.gameObject.GetComponent<ShopPanel>().itemsInShop.Remove(item);
            }
            return true;
        }
        else
        {
            Debug.Log("Not enough money");
            return false;
        }
    }
    public void UpdatePrices()
    {
        foreach (SetItem item in shopPanel.gameObject.GetComponent<ShopPanel>().itemsInShop)
        {
            if (item.item.itemPrice <= player.gold)
            {
                item.priceText.color = Color.green;
            }
            else
            {
                item.priceText.color = Color.red;
            }
        }
    }
}
