using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDestroy : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim.SetBool("Shooted", false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && PlayerController.counterSpray == 1)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider bc = hit.collider as BoxCollider;
                if(bc != null)
                {
                    anim.SetBool("Shooted", true);
                    PoliceController.dead = true;
                    PlayerController.counterSpray--;
                }
            }
        }
    }
}
