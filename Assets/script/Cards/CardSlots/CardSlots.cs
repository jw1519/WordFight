// needs to go on any thing the card can be dropped on
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CardSlots : MonoBehaviour, IDropHandler
{
    public List<GameObject> cards;
    public virtual void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            
            eventData.pointerDrag.transform.SetParent(transform, false);
            if (!cards.Contains(eventData.pointerDrag))
            {
                cards.Add(eventData.pointerDrag);
            }
            UpdateCards();
        }
    }
    public virtual void UpdateCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.localPosition = new Vector2(i * 60, 0);
            cards[i].transform.localScale = new Vector2(1, 1);
        }
    }
}
