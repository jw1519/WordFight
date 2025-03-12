using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    int index;
    DragAndDrop dragAndDrop;
    private void Awake()
    {
        dragAndDrop = GetComponent<DragAndDrop>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (dragAndDrop.isDragging == false)
        {
            index = transform.GetSiblingIndex();
            dragAndDrop.parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (dragAndDrop.isDragging == false)
        {
            transform.SetParent(dragAndDrop.parentAfterDrag);
            transform.SetSiblingIndex(index);
            transform.parent.GetComponent<CardSlots>().UpdateCards();
        }
    }
}
