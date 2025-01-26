using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDecorator : BaseAbilityDecorator
{
    public Sprite shieldSprite;
    private GameObject shieldObject;
    public ShieldDecorator(GameObject player) : base(player) { }

    public override void Apply(GameObject player)
    {
        base.Apply(player); // Log application
        if (shieldObject != null)
        {
            // make object
            shieldObject = new GameObject("Shield");
            shieldObject.transform.SetParent(player.transform);
            shieldObject.AddComponent<SpriteRenderer>();
            shieldObject.GetComponent<SpriteRenderer>().sprite = shieldSprite;

        }
    }
    public override void Remove(GameObject player)
    {
        base.Remove(player);
        if (shieldObject != null)
        {
            GameObject.Destroy(shieldObject);
            shieldObject = null;
        }
    }
}
