using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Creature
{

    [Header("Turret")]
    public float aimVariance;
    public float attackCooldownSeconds;
    private float attackCooldownTimer;
    public GameObject projectile;


    [Header("Parts")]
    public Animator turretAnimator;
    public GameObject turretAxis;
    public Transform projectileOrigin;
    public TankMachineGun machineGun;
    private float rotationZ;
    public GameObject parent;


    private void TurretShot()
    {
        attackCooldownTimer = Time.time + attackCooldownSeconds;

        Vector2 shotTarget = target.transform.position + new Vector3(Random.Range(-aimVariance, aimVariance), Random.Range(-aimVariance, aimVariance), 0);
        shotTarget.y += 1;

        turretAnimator.Play("attack");

        GameObject attack = Instantiate(projectile);
        attack.transform.position = projectileOrigin.transform.position;

        attack.GetComponent<Projectile>().rotationZ = Calculations.GetRotationZToTarget(turretAxis.transform.position, shotTarget);
        attack.GetComponent<Projectile>().direction = Calculations.GetDirectionToTarget(projectileOrigin.position, shotTarget);

    }

    public override void Death()
    {
        base.Death();

        turretAnimator.Play("death");
        if (machineGun.hp>0) machineGun.Death();
        Destroy(parent, 3);
    }

    private void FixedUpdate()
    {
        //Physics2D.CircleCast(projectileOrigin.position, detectionRadius, Vector2.zero, 0, detectedTargets);

    }
    protected override void Update()
    {
        if (paused == false && dying == false)
        {
            if (TargetInsideDetection())
            {
                rotationZ = Calculations.GetRotationZToTarget(projectileOrigin.position, target.transform.position);
                if (rotationZ > 90 || rotationZ < -90) turretAxis.transform.rotation = Quaternion.Euler(0, 180, -rotationZ + 180);
                else turretAxis.transform.rotation = Quaternion.Euler(0, 0, rotationZ);

                if (Time.time > attackCooldownTimer) TurretShot();
            }
        }
    }
}

