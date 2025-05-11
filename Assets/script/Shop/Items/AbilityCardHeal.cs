using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability Cards", menuName = "Cards/Heal")]
public class AbilityCardHeal : BaseItem, IUse
{
    public int healAmount;
    Player player;
    public override void Awake()
    {
        itemDescription = "Card heals player for " + healAmount.ToString();
        player =FindAnyObjectByType<Player>();
        base.Awake();
    }
    public void Use()
    {
        player.Heal(healAmount);
    }
}
