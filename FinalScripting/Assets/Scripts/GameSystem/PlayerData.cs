using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static int coins;
    //Player player;

    //public static PlayerData Instance { get; private set; }

    /*void Awake()
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
        player = Player.Instance;
    }*/

    public void SaveGame()
    {
        SaveSystem.SaveGame(this);
    }

    public void LoadGame()
    {
        GameData data = SaveSystem.LoadGame();
        coins = data.coins;
    }

    public static void AddCoins()
    {
        coins += PlayerController.counterCoin;
        //coins += player.counterCoin;
    }
}
