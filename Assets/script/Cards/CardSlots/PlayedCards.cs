using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayedCards : CardSlots
{
    public override void UpdateCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.localScale = new Vector2(1, 1);
        }
    }
}
