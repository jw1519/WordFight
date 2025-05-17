using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "CardPack")]
public class CardPack : BaseItem
{
    public int amountInPack;
    CardPackManager manager;

    public override void Awake()
    {
        base.Awake();
        manager = FindAnyObjectByType<CardPackManager>();
    }

    public override void Use()
    {
        manager.OpenPack(this);
    }

}
