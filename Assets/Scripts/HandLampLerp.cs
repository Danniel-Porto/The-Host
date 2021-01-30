using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLampLerp : MonoBehaviour
{
    [SerializeField] Transform lampOffset;

    private void Update()
    {
        transform.position = lampOffset.position;
    }
}
