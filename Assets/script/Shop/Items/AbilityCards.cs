using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AbilityCards : BaseItem, IUse
{
    public string itemDescription;
    public TextMeshProUGUI descriptionText;

    public override void Awake()
    {
        base.Awake();
        descriptionText.text = itemDescription;
    }
    public void Use()
    {
        Destroy(gameObject);
    }
}
