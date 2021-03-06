﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPolice : MonoBehaviour
{
    Player player;
    Police police;
    UIObserver uIObserver;
    void Start()
    {
        player = Player.Instance;
        uIObserver = UIObserver.Instance;
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
                    police = bc.gameObject.GetComponent<Police>();
                    police.Killed();
                    player.counterSpray--;
                    uIObserver.OnPlayerReseivedSpray();
                }
            }
        }
    }
}
