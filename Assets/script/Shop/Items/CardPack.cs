using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPack : BaseItem
{
    CardPackManager cardPackManager;
    public override void Awake()
    {
        base.Awake();
        cardPackManager = FindFirstObjectByType<CardPackManager>();
    }
    public void Open()
    {
        cardPackManager.OpenPack(this);
    }
}
