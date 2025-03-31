using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Ability/Heal")]
public class HealCard : Card, ICard
{
    Player player;
    private void OnEnable()
    {
        cardType = CardType.Heal;
        player = FindObjectOfType<Player>();
    }
    public void Play()
    {
        if (player != null)
        {
            player.Heal(value);
        }
    }
}
