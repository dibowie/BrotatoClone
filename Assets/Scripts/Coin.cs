using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour,ICollectable
{
    public static EventHandler OnCoinCollect;


    public void Collect()
    {
        OnCoinCollect?.Invoke(this,EventArgs.Empty);
    }
}
