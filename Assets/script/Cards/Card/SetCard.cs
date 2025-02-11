using UnityEngine;
using TMPro;

public class SetCard : MonoBehaviour
{
    public Card card;
    public TextMeshProUGUI cardLetterText;
    public TextMeshProUGUI description;

    void Start()
    {
        SetCardvalues();
    }
    public void SetCardvalues()
    {
        cardLetterText.SetText(card.letter);

        if (card.cardType != Card.CardType.Ability)
        {
            description.SetText($"This card does {card.value} {card.cardType}");
        }
        else
        {
            description.SetText("This card doubles damage");
        }
    }
    
}
