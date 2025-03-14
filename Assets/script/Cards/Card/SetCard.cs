using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SetCard : MonoBehaviour
{
    public Card card;
    public TextMeshProUGUI cardLetterText;
    public TextMeshProUGUI description;

    void Start()
    {
        cardLetterText.SetText(card.letter);

        if (card.cardType == Card.CardType.Strength)
        {
            description.SetText("This card doubles damage");
        }
        else if (card.cardType == Card.CardType.Heal)
        {
            description.SetText($"This card heals for {card.value}");
        }
        else
        {
            description.SetText($"This card does {card.value} {card.cardType}");
        }
        if (card.sprite != null)
        {
            gameObject.GetComponent<Image>().sprite = card.sprite;
        }
    }
    public void SetCardvalues(int value)
    {
        card.value = value;
        if (card.cardType == Card.CardType.Attack)
        {
            description.SetText($"This card does {card.value} {card.cardType}");
        }
    }
    
}
