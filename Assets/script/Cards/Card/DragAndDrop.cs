using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    Transform parentAfterDrag;
    CanvasGroup canvasGroup;
    RectTransform rectTransform;

    bool isDragging;

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

    int cardposition;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isDragging == false)
        {
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isDragging == false)
        {
            transform.SetParent(parentAfterDrag);
            parentAfterDrag.GetComponent<CardSlots>().UpdateCards();
        }
    }
}
