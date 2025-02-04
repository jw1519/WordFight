using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Defence Card")]
public class DefenceCard : Card
{
    [HideInInspector] public Player player;
    [HideInInspector] public AbilityManager abilityManager;
    private void Awake()
    {
        cardType = CardType.Defence;
    }
    public override void Play()
    {
        if (player != null )
        {
            player.defence = player.defence + value; 
        }
        AbilityManager.instance.ApplyDefence();
    }
}
