using System.Collections.Generic;
using UnityEngine;

public class StrengthBoostDecorator : BaseAbilityDecorator
{
    int boostMultiplier = 2;

    public StrengthBoostDecorator(GameObject player) : base(player) { }

    public void Apply(GameObject player)
    {
        base.Apply(player);
        foreach (GameObject gameObject in GameManager.instance.GetComponent<CardPool>().pooledCards)
        {
            if (gameObject.GetComponent<AttackCard>() != null)
            {
                int value = gameObject.GetComponent<AttackCard>().value;
                value = value * boostMultiplier;
                gameObject.GetComponent<SetCard>().SetCardvalues(value);
            }
        }
    }

    public void Remove(GameObject player)
    {
        base.Remove(player);
        foreach (GameObject gameObject in GameManager.instance.GetComponent<CardPool>().pooledCards)
        {
            if (gameObject.GetComponent<AttackCard>() != null)
            {
                int value = gameObject.GetComponent<AttackCard>().value;
                value = value / boostMultiplier;
                gameObject.GetComponent<SetCard>().SetCardvalues(value);
            }
        }
    }
}
