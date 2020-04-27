using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour, IPool
{
    [SerializeField] float lifeTime;
    Vector3 Initial;

    public void Instantiate()
    {
        Initial = transform.position;
    }
    public void Spawn(Vector3 position)
    {
        transform.position = position;
        Invoke("Destroy", lifeTime);
    }
    public void Destroy()
    {
        transform.position = Initial;
    }
}
