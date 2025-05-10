using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AbilityCards : BaseItem, IUse
{
    public string itemDescription;
    public TextMeshProUGUI descriptionText;
    public Player player;

    public override void Awake()
    {
        base.Awake();
        player = FindAnyObjectByType<Player>();
        descriptionText.text = itemDescription;
    }
    public virtual void Use()
    {
        if (isSold == true)
        {
            player.RemoveItem(this);
            Destroy(gameObject);
            //do thing
        } 
    }
}
