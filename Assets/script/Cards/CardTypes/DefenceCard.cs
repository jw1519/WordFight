using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Defence Card")]
public class DefenceCard : Card
{
    public int defence;
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
