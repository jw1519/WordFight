using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Ability Card")]
public class AbilityCard : Card
{
    private void Awake()
    {
        cardType = CardType.Ability;
        defence = 0;
        damage = 0;
    }
}
