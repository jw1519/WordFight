using UnityEngine;
using TMPro;

public class SetCard : MonoBehaviour
{
    public Card card;
    public TextMeshProUGUI cardLetterText;
    public TextMeshProUGUI description;

    void Awake()
    {
        cardLetterText.SetText(card.letter);

        if (card.cardType != Card.CardType.Ability)
        {
            description.SetText($"This card does {card.damageOrDefence} {card.cardType}");
        }
        else
        {
            description.SetText("This card does a thing");
        }
        
    }
}
