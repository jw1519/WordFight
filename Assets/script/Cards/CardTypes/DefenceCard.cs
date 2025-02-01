using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Defence Card")]
public class DefenceCard : Card
{
    private void Awake()
    {
        cardType = CardType.Defence;
        damage = 0;
    }
    public override void Use()
    {
        if (player != null )
        {
            player.defence = player.defence + defence; 
        }
        AbilityManager.instance.ApplyDefence();
    }
}
