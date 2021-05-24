using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMachineGun : Creature
{
    [Header("Creature Specific")]
    [Space(30)]
    public Tank mainBody;
    
    [Header("Attack")]
    private int state;
    private bool hasAttacked;
    public float aimVariance;
    public GameObject projectile;
    public float shotCooldown;
    private float shotCooldownTimer;
    public float useCooldown;
    private float useCooldownTimer;
    public float restInterval;
    private float restIntervalTimer;

    [Header("Components")]
    public GameObject gunAxis;
    public Transform projectileOrigin;
    private float rotationZ;

    public void Rest()
    {
        state = 1;
        restIntervalTimer = Time.time + restInterval;

    }


    private void GunShot()
    {
        Vector2 shotTarget = target.transform.position + new Vector3(Random.Range(-aimVariance, aimVariance), Random.Range(-aimVariance, aimVariance), 0);
        shotTarget.y += 1;

        GameObject attack = Instantiate(projectile);
        attack.transform.position = projectileOrigin.transform.position;

        attack.GetComponent<Projectile>().rotationZ = Calculations.GetRotationZToTarget(gunAxis.transform.position, shotTarget);
        attack.GetComponent<Projectile>().direction = Calculations.GetDirectionToTarget(projectileOrigin.position, shotTarget);

        shotCooldownTimer = Time.time + shotCooldown;
    }

    protected override void Update()
    {
        anim.SetInteger("state", state);

        if (paused == false && dying == false)
        {
            if (TargetInsideDetection() && state == 0 && Time.time > useCooldownTimer)
            {
                Rest();
                hasAttacked = false;
            }

            else if (state == 1 && Time.time > restIntervalTimer)
            {
                if (hasAttacked)
                {
                    state = 0;
                    useCooldownTimer = Time.time + useCooldown;
                }
                else
                {
                    if (TargetInsideDetection())
                    {
                        state = 2;
                        hasAttacked = true;
                    }
                }

            }

            else if (state == 2)
            {
                rotationZ = Calculations.GetRotationZToTarget(projectileOrigin.position, target.transform.position);
                if (rotationZ > 90 || rotationZ < -90) gunAxis.transform.rotation = Quaternion.Euler(0, 180, -rotationZ + 180);
                else gunAxis.transform.rotation = Quaternion.Euler(0, 0, rotationZ);

                if (Time.time > shotCooldownTimer) GunShot();
            }
        }
    }
}
