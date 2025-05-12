using UnityEngine;
using UnityEngine.UI;

public class SelectCard : MonoBehaviour
{
    CardPackPanel panel;
    public void Awake()
    {
        panel = FindAnyObjectByType<CardPackPanel>();
    }
    public void ChooseCard()
    {
        CardManager.instance.deck.Add(gameObject);
        gameObject.transform.SetParent(CardManager.instance.cards);
        gameObject.SetActive(false);
        CardPool.instance.pooledCards.Add(gameObject);
        panel.cards.Remove(gameObject);
        panel.ClosePanel();
        GetComponent<Button>().enabled = false;
    }
}
