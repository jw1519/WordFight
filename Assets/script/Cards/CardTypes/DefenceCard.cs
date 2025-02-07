using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Defence Card")]
public class DefenceCard : Card, ICard
{
    [HideInInspector] public Player player;

    private void Awake()
    {
        cardType = CardType.Defence;
    }
    public void Play()
    {
        if (player != null )
        {
            player.defence = player.defence + value; 
        }
        AbilityManager.instance.ApplyDecorator("Shield", new ShieldDecorator(AbilityManager.instance.gameObject));
    }
}
