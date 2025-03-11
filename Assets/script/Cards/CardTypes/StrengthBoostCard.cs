using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Ability Card")]
public class StrengthBoostCard : Card, ICard
{
    private void OnEnable()
    {
        cardType = CardType.Strength;
    }
    public void Play()
    {
        AbilityManager.instance.ApplyDecorator("Strength", new StrengthBoostDecorator(AbilityManager.instance.gameObject));
    }
}
