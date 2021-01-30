using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovManager : MonoBehaviour
{
    [SerializeField] Camera playerHead;
    GameObject obeisk;

    void Start()
    {
        
    }
    void Update()
    {
        DetectTarget();
    }

    void DetectTarget()
    {
        obeisk = GameObject.FindWithTag("Enemy");
        if (obeisk != null)
        {
            if (obeisk.transform.Find("obj_model").GetComponent<SkinnedMeshRenderer>().isVisible)
            {
                print("visible");
            } else
            {
                print("not visible");
            }
        }
    }
}
