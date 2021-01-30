using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleSpawnManager : MonoBehaviour
{
    GameObject[] CandleSpawners;
    int candlesToSpawn = 6;

    [SerializeField] GameObject candle;

    private void Start()
    {
        CandleSpawners = GameObject.FindGameObjectsWithTag("CandleSpawn");
        int i = 0;
        while (i < candlesToSpawn)
        {
            int randomSpawn = Random.Range(0, CandleSpawners.Length);
            if (CandleSpawners[randomSpawn].GetComponent<CandleSpawnInfo>().isAvaliable)
            {
                CandleSpawners[randomSpawn].GetComponent<CandleSpawnInfo>().isAvaliable = false;
                Instantiate(candle, CandleSpawners[randomSpawn].transform.position + new Vector3(0f, 0.1f, 0f), CandleSpawners[randomSpawn].transform.rotation);
                i+=1;
            }
        }
    }
}
