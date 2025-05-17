using UnityEngine;
using UnityEngine.UI;

public class SelectCard : MonoBehaviour
{
    BasePanel panel;
    public void Awake()
    {
        panel = UIManager.instance.GetPanel("CardPackPanel");
        
    }
    public void ChooseCard()
    {
        CardManager.instance.deck.Add(gameObject);
        CardPool.instance.pooledCards.Add(gameObject);
        gameObject.transform.SetParent(CardManager.instance.cards);
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(140, 160);
        panel.gameObject.GetComponent<CardPackPanel>().cards.Remove(gameObject);
        panel.ClosePanel();
        gameObject.GetComponent<DragAndDrop>().parentAfterDrag = CardManager.instance.handCards; //for now
        GetComponent<Button>().enabled = false;
        GetComponent<Hover>().enabled = true;
        gameObject.SetActive(false);
    }
}
