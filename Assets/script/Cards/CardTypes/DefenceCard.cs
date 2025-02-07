using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Defence Card")]
public class DefenceCard : Card, ICard
{
    [HideInInspector] public Player player;
    [HideInInspector] public AbilityManager abilityManager;
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
        AbilityManager.instance.ApplyDefence();
    }
}
