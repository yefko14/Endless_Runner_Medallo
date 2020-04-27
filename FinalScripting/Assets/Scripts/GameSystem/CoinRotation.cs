using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(2, 1, 1, Space.World);
    }
}
