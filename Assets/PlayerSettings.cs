using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    public float playerVolume, playerSense;

    private void Start()
    {
        playerVolume = PlayerPrefs.GetFloat("volume") / 100;
        playerSense = PlayerPrefs.GetFloat("sense");
    }
}
