using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    public int counterCoin { get; set; }
    public int counterSpray { get; set; }
    PlayerMovement playerMovement;
    //public static bool dead;
    //private bool plus;

    public delegate void OnPlayerDied();
    public event OnPlayerDied onPlayerDied;

    public delegate void OnPlayerScoreChanged();
    public event OnPlayerScoreChanged onPlayerScoreChanged;

    public delegate void OnPlayerGetSpray();
    public event OnPlayerGetSpray onPlayerGetSpray;

    public static Player Instance { get; private set; }

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

        animator = GetComponent<Animator>();
        counterCoin = 0;
        counterSpray = 0;
        playerMovement = PlayerMovement.Instance;
    }

    public void GetSpray()
    {
        if (counterSpray == 0)
        {
            counterSpray++;
            if (onPlayerGetSpray != null)
            {
                onPlayerGetSpray();
            }
        }
    }
    
    public void PlayerDead()
    {
        playerMovement.Stop();
        PlayerData.AddCoins();
        //playerMovement.controlLocked = true;
        //UIController.dead = true;
        animator.SetBool("Obstacle", true);
        //playerMovement.ZVel = 0;
        MoveCam.Zvel = 0;
        //plus = false;
        if (onPlayerDied != null)
        {
            onPlayerDied();
        }
    }

    public void PlusPoints()
    {
        counterCoin ++;
        if (onPlayerScoreChanged != null)
        {
            onPlayerScoreChanged();
        }
    }
}
