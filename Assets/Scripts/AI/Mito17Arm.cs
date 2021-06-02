using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mito17Arm : Creature
{
    public Mito17Main main;
    public int state;

    [Header("Attack")]
    public GameObject projectile;
    public Transform projectileOrigin;
    public float aimVariance;
    private float shotInterval = 0.15f;
    private float timer;

    public void AttackBegin()
    {
        if (Time.time > timer) state = 1;

    }

    public void AttackEnd()
    {
        state = 0;
        timer = Time.time + main.gunUseInterval[main.phase];

    }

    public void Shot()
    {
        if(Time.time > timer)
        {
            timer = Time.time + shotInterval;

            Projectile.ShootProjectile(projectile, projectileOrigin.position, target.transform.position, aimVariance);

        }

    }
    /*
    public GameObject TargetDetection()
    {
        if (Physics2D.OverlapCircle(transform.position, detectionRange, detectionMask))
        {
            return Physics2D.OverlapCircle(transform.position, detectionRange, detectionMask).gameObject;
        }
        else return null;
    }
    */

    protected override void Update()
    {
        GetComponent<Animator>().SetInteger("state", state);


        if (main.active && !main.paused && !paused && !dying)
        {
            switch (state)
            {
                case 0:
                    if (TargetInsideDetection()) AttackBegin();
                    break;
                case 1:
                    Shot();
                    break;
            }
        }
    }
}
