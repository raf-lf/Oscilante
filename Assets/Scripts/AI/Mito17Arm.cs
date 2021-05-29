using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mito17Arm : MonoBehaviour
{
    public bool paused;
    public Mito17Main main;

    [Header("Detection")]
    public float detectionRange;
    public LayerMask detectionMask;
    public GameObject target;

    [Header("Attack")]
    public bool attacking;
    public GameObject projectile;
    private float attackIntervalTimer;
    private float shotInterval = 0.15f;
    private float shotTimer;

    public void AttackBegin()
    {
        if(Time.time > attackIntervalTimer)
        {
            attackIntervalTimer = Time.time + main.gunUseInterval[main.phase];

        }

    }
    public void Shot()
    {
        if(Time.time > shotTimer)
        {
            shotTimer = Time.time + shotInterval;

        }

    }

    public GameObject TargetDetection()
    {
        if (Physics2D.OverlapCircle(transform.position, detectionRange, detectionMask))
        {
            return Physics2D.OverlapCircle(transform.position, detectionRange, detectionMask).gameObject;
        }
        else return null;
    }

    private void Update()
    {
        if (paused == false)
        {
            target = TargetDetection();

            if (target != null)
            {
                AttackBegin();
            }
        }
    }
}
