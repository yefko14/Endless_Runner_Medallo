using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceController : MonoBehaviour
{
    private GameObject player;
    public static bool dead;
    public Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dead = false;
        anim.SetBool("Shooting", false);
    }

    void Update()
    {
        if (dead == false)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);

            if (Vector3.Distance(transform.position, player.transform.position) < 8)
            {
                anim.SetBool("Shooting", true);
                PlayerController.dead = true;
            }
        }
    }
}
