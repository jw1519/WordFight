using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : BasePanel
{
    private void OnEnable()
    {
        ShopManager.instance.UpdatePrices();
    }

}
