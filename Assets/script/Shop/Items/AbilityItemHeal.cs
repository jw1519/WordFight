using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "AbilityItem/Heal")]
public class AbilityItemHeal : BaseItem
{
    public int healAmount;
    Player player;
    public override void Awake()
    {
        itemDescription = "Card heals player for " + healAmount.ToString();
        player = FindAnyObjectByType<Player>();
        base.Awake();
    }
    public override void Use()
    {
        player.Heal(healAmount);
    }
}
