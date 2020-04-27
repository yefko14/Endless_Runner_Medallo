using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray : Coin
{
    public override void Destroy()
    {
        player.GetSpray();
        transform.position = Initial;
    }
}
