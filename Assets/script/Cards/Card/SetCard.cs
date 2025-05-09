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
        switch (card.cardType)
        {
            case Card.CardType.Strength:
                description.SetText("This card doubles damage");
                break;
            case Card.CardType.Heal:
                description.SetText($"This card heals for {card.value}");
                break;
            case Card.CardType.Defence:
                description.SetText($"This card defends for {card.value}");
                break;
            case Card.CardType.Attack:
                description.SetText($"This card Attacks for {card.value}");
                break;
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
