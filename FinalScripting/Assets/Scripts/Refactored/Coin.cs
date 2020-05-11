using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IPool
{
    [SerializeField] float lifeTime;
    public Vector3 Initial { get; set; }
    public  Player player;

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
    public void Destroy()
    {
        transform.position = Initial;
    }
    public virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 8)
        {
            player.PlusPoints();
            Destroy();
        }
    }
}
