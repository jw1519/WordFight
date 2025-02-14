using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Ability Card")]
public class AbilityCard : Card, ICard
{
    private void OnEnable()
    {
        cardType = CardType.Ability;
    }
    public void Play()
    {
        AbilityManager.instance.ApplyDecorator("Strength", new StrengthBoostDecorator(AbilityManager.instance.gameObject));
    }
}
