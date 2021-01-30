using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualSequence : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject blockExitWall;
    [SerializeField] ParticleSystem particleSequence1, particleSequence2, particleSequence3;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Sequence()
    {
        blockExitWall.SetActive(true);
        particleSequence2.Play();
        player.transform.Find("HandLamp_LowJoined").gameObject.SetActive(false);
    }
}
