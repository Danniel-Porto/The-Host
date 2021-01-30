using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentDisabler : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    PlayerMotor pm;

    private void Start()
    {
        pm = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        PausePlayerController();
    }

    void PausePlayerController()
    {
        pm.enabled = pauseMenu.activeSelf ? false : true;
    }
}
