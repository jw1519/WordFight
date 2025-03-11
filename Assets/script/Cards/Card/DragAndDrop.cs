using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Transform parentAfterDrag;
    CanvasGroup canvasGroup;
    RectTransform rectTransform;

    GameObject placeholder = null;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;

        placeholder = new GameObject();
        placeholder.transform.parent = parentAfterDrag;
        placeholder.transform.localScale = gameObject.transform.localScale;

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
            parentAfterDrag.GetComponent<CardSlots>().UpdateCards();
        }
        Destroy(placeholder);
    }
}
