using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject coin;
    public GameObject spray;
    public GameObject hole;
    public GameObject cone;
    public GameObject road;
    public GameObject police;

    private bool CanSpawnRoad;
    private bool CanSpawnObj;
    private bool CanSpawnPolice;

    private int randNum;
    private int randxPos;
    private int cant;

    private float zPosRoad;
    private float xPosObj;
    private float zPosObj;
    private float xPosPol;
    private float zPosPol;

    void Start()
    {
        cant = 1;
        CanSpawnObj = true;
        CanSpawnRoad = true;
        CanSpawnPolice = true;
        zPosPol = 70;
        zPosRoad = 100;
        zPosObj = 10;
    }

    void Update()
    {
        randxPos = Random.Range(1, 3);
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
            Instantiate(coin, new Vector3(xPosObj, 0.7f, zPosObj), coin.transform.rotation);
            zPosObj += 2;
        }

        else if (randNum > 8 && CanSpawnObj == true)
        {
            Instantiate(cone, new Vector3(xPosObj, 0, zPosObj), cone.transform.rotation);
            zPosObj += 2;
        }

        else if (randNum == 6 && CanSpawnObj == true)
        {
            Instantiate(hole, new Vector3(xPosObj, -0.08f, zPosObj), hole.transform.rotation);
            zPosObj += 2;
        }
        else if(randNum == 5 && CanSpawnObj == true)
        {
            Instantiate(spray, new Vector3(xPosObj, 0.7f, zPosObj), spray.transform.rotation);
            zPosObj += 2;
        }
        else if (randNum == 7 && CanSpawnPolice == true)
        {
            Instantiate(police, new Vector3(xPosPol, 0.2f, zPosPol), police.transform.rotation);
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
            Instantiate(road, new Vector3(0, 0, zPosRoad), road.transform.rotation);
            zPosRoad += 100;
            CanSpawnRoad = false;
            StartCoroutine(WaitRoadSpawn());
        }
    }

    IEnumerator WaitPoliceSpawn()
    {
        yield return new WaitForSeconds(10f);
        CanSpawnPolice = true;
    }

    IEnumerator WaitObjSpawn()
    {
        yield return new WaitForSeconds(10f);
        CanSpawnObj = true;
    }

    IEnumerator WaitRoadSpawn()
    {
        yield return new WaitForSeconds(10f);
        CanSpawnRoad = true;
    }
}
