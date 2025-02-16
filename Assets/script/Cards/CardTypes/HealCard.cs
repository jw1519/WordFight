
public class HealCard : Card, ICard
{
    Player player;
    private void OnEnable()
    {
        cardType = CardType.Ability;
        player = FindObjectOfType<Player>();
    }
    public void Play()
    {
        if (player != null)
        {
            if (player.health + value < player.maxHealth)
            {
                player.health = player.health + value;
            }
            else
            {
                player.health = player.maxHealth;
            }
        }
        
    }
}
