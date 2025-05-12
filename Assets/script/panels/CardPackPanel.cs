using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPackPanel : BasePanel
{
    public List<GameObject> cards;
    private void OnDisable()
    {
        foreach (var card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
    }
}
