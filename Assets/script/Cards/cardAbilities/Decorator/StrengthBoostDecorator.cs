using UnityEngine;

public class StrengthBoostDecorator : BaseAbilityDecorator
{
    private int boostMultiplier = 2;

    public StrengthBoostDecorator(GameObject player) : base(player) { }

    public void Apply(GameObject gameObject)
    {
        foreach (SetCard cards in CardManager.instance.hand)
        {
            cards.card.damage = cards.card.damage * boostMultiplier;
        }
        
    }

    public void Remove(GameObject gameObject)
    {
        foreach (SetCard cards in CardManager.instance.hand)
        {
            cards.card.damage = cards.card.damage / boostMultiplier;
        }
    }
}
