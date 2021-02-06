using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStateEvents : MonoBehaviour
{
    [SerializeField] GameObject mainGate, gateHinge;
    [SerializeField] AudioClip audioCloseGate;

    [SerializeField] PlayerSettings settings;

    [SerializeField] GameObject blinkingPost;

    int cycle, timer = 0;
    bool blink;

    bool gateIsClosing, gateIsClosed;
    int gateState = 0;

    #region States
    int open = 0; int closed = 1; int opening = 2; int closing = 3;
    #endregion

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        MoveGate();
        BlinkPost();
    }

    private void BlinkPost()
    {
        if (timer == cycle)
        {
            timer = 0;
            cycle = Random.Range(4, 20);
            blink = !blink;
            blinkingPost.transform.Find("Point Light").gameObject.GetComponent<Light>().enabled = blink;
            blinkingPost.transform.Find("Spot Light").gameObject.GetComponent<Light>().enabled = blink;
        } else
        {
            timer += 1;
        }
    }

    public void CloseGate()
    {
        if (gateState == open)
        {
            gateState = closing;
            mainGate.GetComponent<AudioSource>().PlayOneShot(audioCloseGate, 1f * settings.playerVolume);
        }
    }

    public void MoveGate()
    {
        if (gateState == closing & gateHinge.transform.rotation.z >= 0)
        {
            gateHinge.transform.Rotate(0, 0, -0.95f);
        }

        if (gateHinge.transform.rotation.z <= 0)
        {
            gateState = closed;
        }
    }
}
