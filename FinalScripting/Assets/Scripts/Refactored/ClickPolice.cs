using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPolice : MonoBehaviour
{
    Animator anim;
    Police police;
    Player player;

    void Start()
    {
        player = Player.Instance;
        police = GetComponent<Police>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && player.counterSpray == 1)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider bc = hit.collider as BoxCollider;
                if (bc != null)
                {
                    police.Killed();
                    player.counterSpray--;
                }
            }
        }
    }
}
