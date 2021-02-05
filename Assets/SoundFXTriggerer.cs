using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXTriggerer : MonoBehaviour
{
    AudioSource source;
    PlayerSettings settings;

    [Header("Random Range Audio Clips")]
    [SerializeField] AudioClip[] audioClips;

    [Header("Volume Override if too loud/low")]
    [SerializeField] float volumeOverride = 1;

    [Header("Chance in % to trigger the event")]
    [SerializeField] int chance = 100;

    [Header("Retrigger?")]
    [SerializeField] bool allowRetrigger = true;

    private void Start()
    {
        settings = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSettings>();
        source = transform.Find("SoundFX").gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player")) 
        {
            if (Random.Range(0, 100) < chance)
            source.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)], settings.playerVolume * volumeOverride);
            this.gameObject.GetComponent<Collider>().enabled = allowRetrigger;
        }
    }
}
