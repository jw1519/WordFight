using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayedCards : CardSlots
{
    public override void UpdateCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.localPosition = new Vector2(-200 + i * 70, 0);
            cards[i].transform.localScale = new Vector2(0.7f, 0.7f);
        }
    }
}
