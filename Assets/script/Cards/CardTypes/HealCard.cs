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
            if (player.health + value < player.maxHealth)
            {
                player.health += value;
            }
            else
            {
                player.health = player.maxHealth;
            }
            Debug.Log("healed");
            player.GetComponent<SetPlayerUI>().UpdatePlayerHealth(player);
        }
        
    }
}
