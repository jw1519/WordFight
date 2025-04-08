using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform parentAfterDrag;
    CanvasGroup canvasGroup;
    RectTransform rectTransform;

    public bool isDragging;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        isDragging = false;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        //parentAfterDrag = transform.parent;
        parentAfterDrag.gameObject.GetComponent<CardSlots>().cards.Remove(gameObject);
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if (transform.parent == transform.root)
        {
            transform.SetParent(parentAfterDrag);
            parentAfterDrag.GetComponent<CardSlots>().cards.Add(eventData.pointerDrag);  
        }
        parentAfterDrag.GetComponent<CardSlots>().UpdateCards();
        parentAfterDrag = transform.parent;
        isDragging = false;
    }
}
