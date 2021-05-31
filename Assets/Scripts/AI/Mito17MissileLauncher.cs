using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mito17MissileLauncher : Creature
{
    [Header("Specific")]
    [Space(30)]
    public bool active;

    [Header("Attack")]
    private float attackCooldownTimer;
    public GameObject projectile;

    [Header("Components")]
    public Mito17Main main;
    public Transform projectileOrigin;

    private void Fire()
    {
        if (Time.time > attackCooldownTimer)
        {
            attackCooldownTimer = Time.time + main.missileInterval[main.phase];

            anim.Play("attack");

            Projectile.ShootProjectile(projectile, projectileOrigin.position, target.transform.position, 0);

        }
    }

    protected override void Update()
    {
        base.Update();

        anim.SetBool("active", active);

        if (!main.paused && !paused && !dying && active)
        {
            if (TargetInsideDetection())
            {
                Fire();
            }
        }
    }
}
