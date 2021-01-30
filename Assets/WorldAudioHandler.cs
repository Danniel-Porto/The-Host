using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldAudioHandler : MonoBehaviour
{
    [SerializeField] AudioClip[] rustlingBushes;
    [SerializeField] AudioClip ambience;
    [SerializeField] AudioClip helpScream;
    [SerializeField] AudioSource screamAudioSource;
    [SerializeField] AudioSource[] bush;

    [SerializeField] PlayerSettings settings;
    [SerializeField] AudioSource playerAudioSource;
    AudioSource audioSource;
    
    private void Start()
    {
        //settings = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSettings>();
        //playerAudioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        Invoke("StartAmbience", 0.1f);
        //playerAudioSource.PlayOneShot(ambience, 0.3f * settings.playerVolume);
    }

    void StartAmbience()
    {
        audioSource.PlayOneShot(ambience, 0.3f * settings.playerVolume);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            PlayRandomBushes();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            screamAudioSource.PlayOneShot(helpScream, settings.playerVolume);
        }
    }

    void PlayRandomBushes()
    {
        bush[Random.Range(0, 3)].PlayOneShot(rustlingBushes[Random.Range(0, 4)], 1f * settings.playerVolume);
    }
}
