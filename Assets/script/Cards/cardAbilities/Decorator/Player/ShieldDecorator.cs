using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShieldDecorator : BaseAbilityDecorator
{
    GameObject shieldObject;
    GameObject shieldAmountDisplay;
    Material shieldMaterial;
    public int shieldValue;
    public ShieldDecorator(GameObject player) : base(player) { }

    public override void Apply(GameObject player)
    {
        base.Apply(player); // Log application
        if (shieldObject == null)
        {
            // make object
            shieldObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            shieldObject.transform.SetParent(player.transform);
            shieldObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 0.5f);
            shieldObject.GetComponent<Renderer>().material.SetFloat("_Mode", 3); //makes it transparent

            //make text to display amount of shield
            shieldAmountDisplay = new GameObject();
            shieldAmountDisplay.transform.SetParent(shieldObject.transform);
            shieldAmountDisplay.AddComponent<TextMeshProUGUI>();
        }
        shieldAmountDisplay.GetComponent<TextMeshProUGUI>().SetText(shieldValue.ToString());
    }
    public override void Remove(GameObject player)
    {
        base.Remove(player);
        if (shieldObject != null)
        {
            GameObject.Destroy(shieldObject);
            shieldObject = null;
            player.GetComponent<Player>().defence = 0;
        }
    }
}
