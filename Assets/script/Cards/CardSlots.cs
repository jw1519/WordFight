using UnityEngine;
using UnityEngine.EventSystems;

public class CardSlots : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("Dropped");
            eventData.pointerDrag.transform.SetParent(transform, false);
        }
    }
}
