using UnityEngine;

public class StrengthBoostDecorator : BaseAbilityDecorator
{
    private int boostMultiplier = 2;

    public StrengthBoostDecorator(GameObject player) : base(player) { }

    public void Apply(GameObject gameObject)
    {
        foreach (SetCard cards in CardManager.instance.hand)
        {
            cards.card.damageOrDefence = cards.card.damageOrDefence * boostMultiplier;
        }
        
    }

    public void Remove(GameObject gameObject)
    {
        foreach (SetCard cards in CardManager.instance.hand)
        {
            cards.card.damageOrDefence = cards.card.damageOrDefence / boostMultiplier;
        }
    }
}
