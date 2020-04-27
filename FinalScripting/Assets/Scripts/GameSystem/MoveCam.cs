using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public static float Zvel;

    void Start()
    {
        Zvel = 4;
    }

    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, Zvel);
    }
}
