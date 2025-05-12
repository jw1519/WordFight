using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "AbilityItem/Heal")]
public class AbilityItemHeal : BaseItem, IUse
{
    public int healAmount;
    Player player;
    public override void Awake()
    {
        itemDescription = "Card heals player for " + healAmount.ToString();
        player = FindAnyObjectByType<Player>();
        base.Awake();
    }
    public void Use()
    {
        player.Heal(healAmount);
    }
}
