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
        panel.gameObject.GetComponent<CardPackPanel>().cards.Remove(gameObject);
        panel.ClosePanel();
        gameObject.GetComponent<DragAndDrop>().parentAfterDrag = CardManager.instance.handCards; //for now
        GetComponent<Button>().enabled = false;
        gameObject.SetActive(false);
    }
}
