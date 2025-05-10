using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCardHeal : AbilityCards
{
    public int healAmount;
    public override void Awake()
    {
        itemDescription = "Card heals player for " + healAmount.ToString();
        base.Awake();
    }
    public override void Use()
    {
        player.Heal(healAmount);
        base.Use();
    }
}
