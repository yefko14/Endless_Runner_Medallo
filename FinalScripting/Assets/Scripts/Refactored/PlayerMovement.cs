using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizVel = 0;
    float ZVel = 4;
    int laneNum = 2;
    bool controlLocked = false;

    public static PlayerMovement Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, 0, ZVel);

        if (Input.GetKeyDown(KeyCode.A) && laneNum > 1 && controlLocked && UIController.dead)
        {
            horizVel = -4;
            laneNum -= 1;
            controlLocked = true;
            StartCoroutine(stopSlide());
        }

        if (Input.GetKeyDown(KeyCode.D) && laneNum < 3 && !controlLocked && !UIController.dead)
        {
            horizVel = 4;
            laneNum += 1;
            controlLocked = true;
            StartCoroutine(stopSlide());
        }
    }

    public void Stop()
    {
        controlLocked = true;
        ZVel = 0;
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.4f);
        horizVel = 0;
        controlLocked = false;
    }
}
