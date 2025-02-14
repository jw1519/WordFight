using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Defence Card")]
public class DefenceCard : Card, ICard
{
    Player player;

    public void Start()
    {
        cardType = CardType.Defence;
    }
    public void Play()
    {
        player = FindObjectOfType<Player>();
        if (player != null )
        {
            player.SetDefence(value);
        }
        AbilityManager.instance.ApplyDecorator("Shield", new ShieldDecorator(AbilityManager.instance.gameObject));
    }
}
