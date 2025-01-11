using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetCard : MonoBehaviour
{
    public Card card;
    public TextMeshProUGUI cardLetterText;
    public TextMeshProUGUI cardDamageText;

    void Start()
    {
        cardLetterText.SetText(card.letter);
        cardDamageText.SetText(card.damage.ToString());
    }
}
