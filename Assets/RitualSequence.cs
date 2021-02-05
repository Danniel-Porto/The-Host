using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualSequence : MonoBehaviour
{
    GameObject player;
    AudioSource audioSource;
    [SerializeField] GameObject blockExitWall;
    [SerializeField] ParticleSystem particleSequence1, particleSequence2, particleSequence3;
    [SerializeField] GameObject metalGate;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
    }

    public void Sequence()
    {
        blockExitWall.SetActive(true);
        player.transform.Find("HandLamp_LowJoined").gameObject.SetActive(false);
        Invoke("SecondPart", 1);
    }

    void SecondPart()
    {
        particleSequence2.Play();

        Invoke("ThirdPart", 2);
    }

    void ThirdPart()
    {
        particleSequence3.Play();
        Invoke("FinalPart", 1.5f);
    }

    void FinalPart()
    {
        particleSequence1.Play();
        particleSequence2.Stop();
        particleSequence3.Stop();
        Invoke("End", 1.5f);
    }

    void End()
    {
        particleSequence1.Stop();
        particleSequence2.Stop();
        particleSequence3.Stop();
        blockExitWall.SetActive(false);
        metalGate.transform.Find("Gate").gameObject.SetActive(false);
        metalGate.transform.Find("BrokenGate").gameObject.SetActive(true);
        player.transform.Find("HandLamp_LowJoined").gameObject.GetComponent<Light>().enabled = false;
        player.transform.Find("HandLamp_LowJoined").gameObject.SetActive(true);
    }
}
