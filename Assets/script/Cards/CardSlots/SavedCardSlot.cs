using UnityEngine;
using UnityEngine.EventSystems;

public class SavedCardSlot: CardSlots
{
    int maxCards = 5;
    public override void OnDrop(PointerEventData eventData)
    {
        if (cards.Count < maxCards)
        {
            base.OnDrop(eventData);
            if (eventData.pointerDrag != null)
            {
                if (!CardManager.instance.savedCards.Contains(eventData.pointerDrag))
                {
                    CardManager.instance.savedCards.Add(eventData.pointerDrag);
                    CardManager.instance.hand.Remove(eventData.pointerDrag);
                }
            }
        }
    }
    public override void UpdateCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.localPosition = new Vector2(-100 + i * 30, 0);
            cards[i].transform.localScale = new Vector2(0.5f, 0.5f);
        }
    }
}
