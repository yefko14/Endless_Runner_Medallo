using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizVel = 0;
    private float ZVel = 4;
    private int laneNum = 2;
    private bool controlLocked;

    private Animator animator;
    public static int counterCoin;
    public static int counterSpray;
    public static bool dead;
    private bool plus;

    void Start()
    {
        plus = true;
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("Obstacle", false);
        controlLocked = false;
        counterCoin = 0;
        counterSpray = 0;
        dead = false;
    }

    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, 0, ZVel);

        if (Input.GetKeyDown(KeyCode.A) && laneNum > 1 && controlLocked == false && UIController.dead == false)
        {
            horizVel = -4;
            laneNum -= 1;
            controlLocked = true;
            StartCoroutine(stopSlide());
        }

        if (Input.GetKeyDown(KeyCode.D) && laneNum < 3 && controlLocked == false && UIController.dead == false)
        {
            horizVel = 4;
            laneNum += 1;
            controlLocked = true;
            StartCoroutine(stopSlide());
        }

        if (dead == true && plus == true)
        {
            PlayerData.AddCoins();
            controlLocked = true;
            UIController.dead = true;
            animator.SetBool("Obstacle", true);
            ZVel = 0;
            MoveCam.Zvel = 0;
            plus = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            PlayerData.AddCoins();
            controlLocked = true;
            UIController.dead = true;
            animator.SetBool("Obstacle", true);
            ZVel = 0;
            MoveCam.Zvel = 0;
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            counterCoin++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Spray"))
        {
            if (counterSpray == 0)
            {
                Destroy(other.gameObject);
                counterSpray++;
            }
            else Destroy(other.gameObject);
        }
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.4f);
        horizVel = 0;
        controlLocked = false;
    }
}
