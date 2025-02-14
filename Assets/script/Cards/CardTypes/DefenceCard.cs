using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Defence Card")]
public class DefenceCard : Card, ICard
{
    Player player;

    private void OnEnable()
    {
        cardType = CardType.Defence;
        player = FindObjectOfType<Player>();
    }
    public void Play()
    {
        if (player != null )
        {
            player.SetDefence(value);
        }
        AbilityManager.instance.ApplyDecorator("Shield", new ShieldDecorator(AbilityManager.instance.gameObject));
    }
}
