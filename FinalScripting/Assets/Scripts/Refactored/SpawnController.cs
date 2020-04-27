using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private float spawnRate = 1f;

    [SerializeField]
    private float firstSpawnDelay = 0f;

    [SerializeField]
    Pool pool;

    Player player;

    void Awake()
    {
        player = Player.Instance;

        /*if (pool != null)
        {
            InvokeRepeating("spawn", firstSpawnDelay, spawnRate);
        }*/
    }

    void Update()
    {
        if (player != null)
        {
            player.onPlayerDied += StopSpawning;
        }
    }

    void spawn()
    {
        Vector3 position = new Vector3();
        pool.GetItem(position);
    }

    private void StopSpawning()
    {
        CancelInvoke();
    }
}
