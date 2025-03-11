// needs to go on any thing the card can be dropped on
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSlots : MonoBehaviour, IDropHandler
{
    public int maxCards;
    public List<GameObject> cards;
    public virtual void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            
            eventData.pointerDrag.transform.SetParent(transform, false);
            if (!cards.Contains(eventData.pointerDrag.gameObject))
            {
                cards.Add(eventData.pointerDrag.gameObject);
            }
            UpdateCards();
        }
    }
    public virtual void UpdateCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.localPosition = new Vector2(-i * 20, 0);
            cards[i].transform.localScale = new Vector2(1, 1);
        }
    }
}
