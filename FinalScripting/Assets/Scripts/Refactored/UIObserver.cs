using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIObserver : MonoBehaviour
{
    [SerializeField] GameObject CanvasOnPlay;
    [SerializeField] GameObject CanvasOnDead;
    [SerializeField] GameObject Spray;
    [SerializeField] Text coins;
    [SerializeField] Text spray;

    Player player;

    void Start()
    {
        player = Player.Instance;

        CanvasOnPlay.SetActive(true);
        CanvasOnDead.SetActive(false);
        Spray.SetActive(false);

        OnPlayerReceivedPoints();
        if (player != null)
        {
            player.onPlayerGetSpray += new Player.OnPlayerGetSpray(OnPlayerReseivedSpray);
            player.onPlayerScoreChanged += new Player.OnPlayerScoreChanged(OnPlayerReceivedPoints);
            player.onPlayerDied += new Player.OnPlayerDied(OnPlayerDied);
        }
    }

    void OnPlayerReceivedPoints()
    {
        if (coins != null)
        {
            coins.text = player.counterCoin.ToString();
        }
    }
    void OnPlayerReseivedSpray()
    {
        if(player.counterSpray == 1)
        {
            Spray.SetActive(true);
        }
        else Spray.SetActive(false);
    }
    void OnPlayerDied()
    {
        StartCoroutine(Dead());
    }
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(1.1f);
        CanvasOnPlay.SetActive(false);
        CanvasOnDead.SetActive(true);
    }
}
