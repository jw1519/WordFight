using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "AbilityItem/IncreaseMaxhealth")]
public class ItemIncreaseMaxHealth : BaseItem
{
    public int amount;
    Player player;

    public override void Awake()
    {
        base.Awake();
        itemDescription = $"Increases player max health by {amount}";
        player = FindFirstObjectByType<Player>();
    }
    public override void Use()
    {
        player.maxHealth += amount;
        player.Heal(amount);
    }
}
