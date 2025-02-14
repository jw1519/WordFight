using System.Collections.Generic;
using UnityEngine;

public class StrengthBoostDecorator : BaseAbilityDecorator
{
    int boostMultiplier = 2;

    public StrengthBoostDecorator(GameObject player) : base(player) { }

    public override void Apply(GameObject player)
    {
        base.Apply(player);
        foreach (GameObject gameObject in GameManager.instance.GetComponent<CardPool>().pooledCards)
        {
            if (gameObject.GetComponent<SetCard>().card.cardType == Card.CardType.Attack)
            {
                int value = gameObject.GetComponent<SetCard>().card.value;
                value = value * boostMultiplier;
                gameObject.GetComponent<SetCard>().SetCardvalues(value);
            }
        }
    }

    public override void Remove(GameObject player)
    {
        base.Remove(player);
        foreach (GameObject gameObject in GameManager.instance.GetComponent<CardPool>().pooledCards)
        {
            if (gameObject.GetComponent<SetCard>().card.cardType == Card.CardType.Attack)
            {
                int value = gameObject.GetComponent<SetCard>().card.value;
                value = value / boostMultiplier;
                gameObject.GetComponent<SetCard>().SetCardvalues(value);
            }
        }
    }
}
