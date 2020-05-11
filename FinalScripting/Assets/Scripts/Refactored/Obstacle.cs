using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IPool
{
    [SerializeField] float lifeTime;
    Vector3 Initial;
    Player player;

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
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 8)
        {
            player.PlayerDead();
        }
    }
}
