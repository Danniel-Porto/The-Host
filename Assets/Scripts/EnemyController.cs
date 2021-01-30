using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject Player;
    Rigidbody rb;
    Animator animator;

    [Header("Hitboxes Scripts")]
    [SerializeField] CollisionDetector PlayerChaseArea;
    [SerializeField] CollisionDetector PlayerDetectionArea;
    [SerializeField] float movementSpeed;

    #region AnimState

    int animState = 0, idle = 0, walking = 1, attacking = 2;

    #endregion

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        UpdateAnimation();
        LookAtPlayer();
        ChasePlayer();
    }

    private void UpdateAnimation()
    {
        animator.SetInteger("obeiskState", animState);
    }

    private void ChasePlayer()
    {
        if (PlayerChaseArea.isTriggered)
        {
            WalkForward();
        } else
        {
            animState = idle;
        }
    }

    private void AttackPlayer()
    {
    
    }

    private void WalkForward()
    {
        transform.position += transform.forward * movementSpeed;
        animState = walking;
    }

    void LookAtPlayer()
    {
        Vector3 dir = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, -angle, 0f);
    }
}
