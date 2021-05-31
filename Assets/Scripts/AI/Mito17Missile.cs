using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mito17Missile : Creature
{

    [Header("Specific")]
    public float turnSpeed;
    public Transform front;

    public override void Death()
    {
        dying = true;
        GetComponent<Projectile>().Impact();

        if (deathVFX != null) Instantiate(deathVFX, transform);
    }

    private void HomeIn()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,Calculations.GetRotationZToTarget(transform.position, target.transform.position + new Vector3(0,0.8f))), turnSpeed);
        rb.velocity = speedIncrement * Calculations.GetDirectionToTarget(transform.position, front.position);
    }

    protected override void Update()
    {
        base.Update();

        if(!dying && !paused)
        {
            HomeIn();
            
        }
    }
}
