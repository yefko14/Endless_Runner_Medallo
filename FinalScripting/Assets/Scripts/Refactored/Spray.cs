using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray : Coin
{
    public override void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 8)
        {
            player.GetSpray();
            Destroy();
        }
    }
}
