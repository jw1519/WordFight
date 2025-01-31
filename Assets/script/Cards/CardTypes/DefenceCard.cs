using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Defence Card")]
public class DefenceCard : Card
{
    private void Awake()
    {
        cardType = CardType.Defence;
    }
    public override void Use()
    {
        if (player != null )
        {
            player.defence = player.defence + defence; // change to decorator later
        }
        ShieldDecorator shieldDecorator = new ShieldDecorator(player.gameObject);
        abilityManager.ApplyDecorator("Shield", shieldDecorator);
    }
}
