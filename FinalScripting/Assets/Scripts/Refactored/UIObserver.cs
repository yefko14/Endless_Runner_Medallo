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
    [SerializeField] Text coins2;

    Player player;

    public static UIObserver Instance { get; private set; }

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
    public void OnPlayerReseivedSpray()
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
        coins2.text = player.counterCoin.ToString();
    }
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(1.1f);
        CanvasOnPlay.SetActive(false);
        CanvasOnDead.SetActive(true);
    }
}
