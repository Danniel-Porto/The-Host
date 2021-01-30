using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStateEvents : MonoBehaviour
{
    [SerializeField] GameObject mainGate, gateHinge;
    [SerializeField] AudioClip audioCloseGate;

    [SerializeField] PlayerSettings settings;

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
