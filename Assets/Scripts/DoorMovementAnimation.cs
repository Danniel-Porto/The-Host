using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovementAnimation : MonoBehaviour
{
    public bool open, opened;
    public float angle;
    void Update()
    {
        angle = transform.rotation.y * Mathf.Rad2Deg;
        if (open & !opened)
        {
            transform.Rotate(0f, 30f * Time.deltaTime, 0f);
        }
        if (transform.rotation.y * Mathf.Rad2Deg >= 57)
        {
            open = false;
            opened = true;
        }
    }
}
