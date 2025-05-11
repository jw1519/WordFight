using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject buttonPanel;
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonPanel.SetActive(false);
    }
}
