using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IPool
{
    [SerializeField] float lifeTime;
    public Vector3 Initial { get; set; }
    public Player player { get; set; }

    void Update()
    {
        transform.Rotate(2, 1, 1, Space.World);
    }
    public void Instantiate()
    {
        player = Player.Instance;
        Initial = transform.position;
    }
    public void Spawn(Vector3 position)
    {
        transform.position = position;
        Invoke("Destroy", lifeTime);
    }
    public virtual void Destroy()
    {
        player.PlusPoints();
        transform.position = Initial;
    }
    void OnTriggerEnter(Collider other)
    {
        Destroy();
    }
}
