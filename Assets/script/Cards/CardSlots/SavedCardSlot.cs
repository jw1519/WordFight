using UnityEngine;
using UnityEngine.EventSystems;

public class SavedCardSlot: CardSlots
{
    public override void OnDrop(PointerEventData eventData)
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
    public override void UpdateCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.localPosition = new Vector2(i * 20,0);
            cards[i].transform.localScale = new Vector2(0.5f, 0.5f);
        }
    }
}
