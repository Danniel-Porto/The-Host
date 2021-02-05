using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualAreaAutoSpawn : MonoBehaviour
{
    [SerializeField] GameObject ritualArea;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player.GetComponent<Inventory>().placedItems == 6)
        {
            ritualArea.SetActive(true);
            this.enabled = false;
        }
    }
}
