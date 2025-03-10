using UnityEngine;

public class SavedCardSlot: CardSlots
{
    public override void UpdateCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.localPosition = new Vector2(i * 20,0);
            cards[i].transform.localScale = new Vector2(0.5f, 0.5f);
        }
    }
}
