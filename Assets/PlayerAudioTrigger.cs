using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioTrigger : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] AudioClip JanitorHouseSFX;
    [SerializeField] AudioClip JanitorRoomSFX;

    PlayerSettings settings;
    AudioSource audioSource;

    private void Start()
    {
        settings = GetComponent<PlayerSettings>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "ATHouseArea":
                audioSource.PlayOneShot(JanitorHouseSFX, 0.6f * settings.playerVolume);
                other.enabled = false;
                break;
            case "ATJanitorRoom":
                audioSource.PlayOneShot(JanitorRoomSFX, settings.playerVolume);
                other.enabled = false;
                break;
            default:
                break;
        }
    }
}
