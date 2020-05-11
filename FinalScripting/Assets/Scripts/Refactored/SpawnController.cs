using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnController : MonoBehaviour
{
    /*[SerializeField]
    private float spawnRate = 1f;

    [SerializeField]
    private float firstSpawnDelay = 0f;
    */
    [SerializeField] Pool coin;
    [SerializeField] Pool spray;
    [SerializeField] Pool hole;
    [SerializeField] Pool cone;
    [SerializeField] Pool road;
    [SerializeField] Pool police;

    bool CanSpawnRoad;
    bool CanSpawnObj;
    bool CanSpawnPolice;

    int randNum;
    int randxPos;
    int cant;

    float zPosRoad;
    float xPosObj;
    float zPosObj;
    float xPosPol;
    float zPosPol;

    Player player;
    bool spawning;

    void Awake()
    {
        player = Player.Instance;
        spawning = true;
        cant = 1;
        CanSpawnObj = true;
        CanSpawnRoad = true;
        CanSpawnPolice = true;
        zPosPol = 70;
        zPosRoad = 100;
        zPosObj = 10;

        /*if (pool != null)
        {
            InvokeRepeating("spawn", firstSpawnDelay, spawnRate);
        }*/
    }

    void Update()
    {
        if (player != null)
        {
            player.onPlayerDied += new Player.OnPlayerDied(StopSpawning);
        }
        if (spawning)
        {

            randxPos = Random.Range(1, 4);
            randNum = Random.Range(1, 10);

            switch (randxPos)
            {
                case 1:
                    xPosObj = 0;
                    xPosPol = 3.95f;
                    break;
                case 2:
                    xPosObj = -1.52f;
                    xPosPol = -3.77f;
                    break;
                case 3:
                    xPosObj = 1.68f;
                    break;
            }

            if (randNum < 5 && CanSpawnObj == true)
            {
                Vector3 position = new Vector3(xPosObj, 0.7f, zPosObj);
                coin.GetItem(position);
                zPosObj += 2;
            }

            else if (randNum > 8 && CanSpawnObj == true)
            {
                Vector3 position = new Vector3(xPosObj, 0, zPosObj);
                cone.GetItem(position);
                zPosObj += 2;
            }

            else if (randNum == 6 && CanSpawnObj == true)
            {
                Vector3 position = new Vector3(xPosObj, -0.08f, zPosObj);
                hole.GetItem(position);
                zPosObj += 2;
            }
            else if (randNum == 5 && CanSpawnObj == true)
            {
                Vector3 position = new Vector3(xPosObj, 0.7f, zPosObj);
                spray.GetItem(position);
                zPosObj += 2;
            }
            else if (randNum == 7 && CanSpawnPolice == true)
            {
                Vector3 position = new Vector3(xPosPol, 0.2f, zPosPol);
                police.GetItem(position);
                zPosPol += 40;
                CanSpawnPolice = false;
                StartCoroutine(WaitPoliceSpawn());
            }

            if ((zPosObj / (100 * cant)) == 1)
            {
                CanSpawnObj = false;
                StartCoroutine(WaitObjSpawn());
                cant++;
            }

            if (zPosRoad < 100000000 && CanSpawnRoad == true)
            {
                Vector3 position = new Vector3(0, 0, zPosRoad);
                road.GetItem(position);
                zPosRoad += 100;
                CanSpawnRoad = false;
                StartCoroutine(WaitRoadSpawn());
            } 
        }
    }
    public void StopSpawning()
    {
        spawning = false;
    }
    IEnumerator WaitPoliceSpawn()
    {
        yield return new WaitForSeconds(10f);
        CanSpawnPolice = true;
    }

    IEnumerator WaitObjSpawn()
    {
        yield return new WaitForSeconds(15f);
        CanSpawnObj = true;
    }

    IEnumerator WaitRoadSpawn()
    {
        yield return new WaitForSeconds(15f);
        CanSpawnRoad = true;
    }
}
