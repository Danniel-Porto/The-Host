using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] string nameTag;
    public bool isTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(nameTag))
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(nameTag))
        {
            isTriggered = false;
        }
    }
}
