using UnityEngine;

public class StrengthBoostDecorator : BaseAbilityDecorator
{
    private int boostMultiplier = 2;

    public StrengthBoostDecorator(GameObject player) : base(player) { }

    public void Apply(GameObject gameObject)
    {
        foreach (GameObject cards in CardManager.instance.hand)
        {
            cards.GetComponent<SetCard>().card.damage = cards.GetComponent<SetCard>().card.damage * boostMultiplier;
        }
        foreach (GameObject cards in CardManager.instance.deck)
        {
            cards.GetComponent<SetCard>().card.damage = cards.GetComponent<SetCard>().card.damage * boostMultiplier;
        }
        foreach (GameObject cards in CardManager.instance.discard)
        {
            cards.GetComponent<SetCard>().card.damage = cards.GetComponent<SetCard>().card.damage * boostMultiplier;
        }

    }

    public void Remove(GameObject gameObject)
    {
        foreach (GameObject cards in CardManager.instance.hand)
        {
            cards.GetComponent<SetCard>().card.damage = cards.GetComponent<SetCard>().card.damage / boostMultiplier;
        }
        foreach (GameObject cards in CardManager.instance.deck)
        {
            cards.GetComponent<SetCard>().card.damage = cards.GetComponent<SetCard>().card.damage / boostMultiplier;
        }
        foreach (GameObject cards in CardManager.instance.deck)
        {
            cards.GetComponent<SetCard>().card.damage = cards.GetComponent<SetCard>().card.damage / boostMultiplier;
        }
    }
}
