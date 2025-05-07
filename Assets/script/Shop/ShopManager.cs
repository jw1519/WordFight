using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    List <Item> items;

    public void AddItemToList(Item item)
    {
        items.Add(item);
    }
    public void RemoveItemFromList(Item item)
    {
        items.Remove(item);
    }
}
