using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour, IPool
{
    public bool dead { get; set; }
    Animator anim;
    Player player;
    [SerializeField] float lifeTime;
    Vector3 Initial;

    void Update()
    {
        if (!dead)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);

            if (Vector3.Distance(transform.position, player.transform.position) < 8)
            {
                anim.SetBool("Shooting", true);
                player.PlayerDead();
            }
        }
    }
    public void Instantiate()
    {
        Initial = transform.position;
        anim = GetComponent<Animator>();
        player = Player.Instance;
        dead = false;
        anim.SetBool("Shooting", false);
    }
    public void Spawn(Vector3 position)
    {
        anim.SetBool("Shooted", false);
        transform.position = position;
        Invoke("Destroy", lifeTime);
        dead = false;
    }
    public void Destroy()
    {
        transform.position = Initial;
    }
    public void Killed()
    {
        anim.SetBool("Shooted", true);
        dead = true;
    }
}
