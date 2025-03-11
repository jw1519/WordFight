// base class for objects that need to hold cards must have
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
            cards[i].transform.localPosition = new Vector2(-100 + i * 80, 0);
            cards[i].transform.localScale = new Vector2(1, 1);
        }
        for (int i = 0; i < transform.childCount; i++)
        {

        }
    }
}
