using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    WorldStateEvents wse;

    [Header("Which tags activate trigger?")]
    [SerializeField] string[] tags;

    [Header("What should happen?")]
    [SerializeField] string[] methodName;

    private void Start()
    {
        wse = GameObject.FindGameObjectWithTag("GameManager").GetComponent<WorldStateEvents>();
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (string nameTag in tags)
        {
            if (other.gameObject.tag == nameTag)
            {
                foreach (string method in methodName)
                    wse.Invoke(method, 0f);
            }
        }
    }
}
