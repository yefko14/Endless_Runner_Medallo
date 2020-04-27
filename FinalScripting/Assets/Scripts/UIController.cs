using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static bool dead;
    public GameObject CanvasOnPlay;
    public GameObject CanvasOnDead;
    public GameObject Spray;
    public Text text;
    public Text text2;

    void Start()
    {
        dead = false;
        CanvasOnPlay.SetActive(true);
        CanvasOnDead.SetActive(false);
        Spray.SetActive(false);
    }

    void Update()
    {
        text.text = PlayerController.counterCoin.ToString();
        text2.text = PlayerController.counterCoin.ToString();

        if (PlayerController.counterSpray == 1)
        {
            Spray.SetActive(true);
        }
        else
        {
            Spray.SetActive(false);
        }

        if (dead == true)
        {
            StartCoroutine(Dead());
        }
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(1.1f);
        CanvasOnPlay.SetActive(false);
        CanvasOnDead.SetActive(true);
    }
}
