using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Defence Card")]
public class DefenceCard : Card
{
    [HideInInspector] public Player player;
    [HideInInspector] public AbilityManager abilityManager;
    private void Awake()
    {
        cardType = CardType.Defence;
        player = FindFirstObjectByType<Player>();
        abilityManager = player.GetComponent<AbilityManager>();
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
