using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Creature
{
    [Header("Creature Specific")]
    [Space(30)]
    [SerializeField]
    private bool agressive;
    public int state;
    private bool covering;

    [Header("Attack")]
    public float aimVariance;
    public Vector2 shots;
    [SerializeField]
    private int shotsRemaining;
    public float shotInterval;
    private float shotIntervalTimer;
    public GameObject projectile;
    public Transform projectileOrigin;
    public GameObject weapon;

    [Header("Rest")]
    public float restTime;
    private float restEndTargetTime;

    [Header("Flee")]
    public float fleeDistance;
    public float fleeTime = 3;
    private float fleeTargetTime;
    public bool stayPut;

    [Header("Cover")]
    public Cover coverInContact;
    public Vector2 coverTime;
    private float coverLeaveTargetTime;


    public override void Start()
    {
        base.Start();
        target = GameManager.PlayerCharacter;

    }

    private void Shoot()
    {
        FaceTarget();

        if (Time.time >= shotIntervalTimer)
        {
            shotsRemaining--;
            shotIntervalTimer = Time.time + shotInterval;

            Vector2 shotTarget = target.transform.position + new Vector3(Random.Range(-aimVariance, aimVariance), Random.Range(-aimVariance, aimVariance), 0);
            shotTarget.y += 1;

            float rotationZ = Calculations.GetRotationZToTarget(transform.position, shotTarget);

            if (rotationZ > 90 || rotationZ < -90) weapon.transform.rotation = Quaternion.Euler(0, 180, -rotationZ + 180);
            else weapon.transform.rotation = Quaternion.Euler(0, 0, rotationZ);

            GameObject shot = Instantiate(projectile);
            shot.transform.position = projectileOrigin.position;
            shot.GetComponent<Projectile>().rotationZ = Calculations.GetRotationZToTarget(transform.position, shotTarget);
            shot.GetComponent<Projectile>().direction = Calculations.GetDirectionToTarget(transform.position, shotTarget);
        }

    }

    private void BeginIdle()
    {
        state = 0;
    }

    private void BeginAttack()
    {
        state = 1;
        covering = false;
        StopMove();
        shotsRemaining = (int)Random.Range(shots.x, shots.y+1);

    }

    private void EndAttack()
    {
        if (facingOpposite) weapon.transform.rotation = Quaternion.Euler(0,180,0);
        else weapon.transform.rotation = Quaternion.Euler(0, 0, 0);

        BeginRest();
    }


    private void BeginRest()
    {
        state = 2;
        restEndTargetTime = Time.time + restTime;

    }

    private void BeginFlee()
    {
        state = 3;
        fleeTargetTime = Time.time + fleeTime;

    }

    private void BeginCover()
    {
        state = 4;
        coverLeaveTargetTime = Time.time + Random.Range(coverTime.x, coverTime.y);

        StopMove();
        covering = true;
        coverInContact.beingUsed = true;

    }

    private void EndCover()
    {
        BeginIdle();

        covering = false;
        coverInContact.beingUsed = false;

    }

    public override void Death()
    {
        StopMove();

        if (covering) EndCover();

        base.Death();

    }

    public override void Damage(int hpLoss, float knockback, Transform sourcePosition)
    {
        base.Damage(hpLoss, knockback, sourcePosition);
        detectionRadius = 14;
    }

    public void StateIdle()
    {
        if (TargetInsideDetection()) BeginAttack();
    }

    public void StateAttack()
    {
        if (shotsRemaining > 0) Shoot();
        else EndAttack();

    }
    public void StateRest()
    {
        if (Time.time > restEndTargetTime) BeginFlee();
    }

    public void StateFleeing()
    {
        if(Time.time > fleeTargetTime)
        {
            BeginIdle();
        }
        else
        {
            if (coverInContact != null && coverInContact.beingUsed == false && Vector2.Distance(target.transform.position, transform.position) > fleeDistance)
            {
                BeginCover();
            }

            if (!stayPut)
            { 
                if (Vector2.Distance(target.transform.position, transform.position) < fleeDistance)
                {
                    if (target.transform.position.x > transform.position.x && facingOpposite == false) ChangeDirection(true);
                    else if (target.transform.position.x < transform.position.x && facingOpposite == true) ChangeDirection(false);

                    Move();
                }
                else StopMove();
            }

        }

    }

    public void StateCover()
    {
        if (Time.time > coverLeaveTargetTime) EndCover();

    }

    protected override void Update()
    {
        base.Update();

        if (!dying)
        {
            anim.SetBool("cover", covering);
            anim.SetInteger("state", state);
        }

        if (!paused && !dying)
        {
            if (!agressive)
            {
                if (TargetInsideDetection()) agressive = true;

            }
            else
            {
                switch (state)
                {
                    case 0:
                        StateIdle();
                        break;
                    case 1:
                        StateAttack();
                        break;
                    case 2:
                        StateRest();
                        break;
                    case 3:
                        StateFleeing();
                        break;
                    case 4:
                        StateCover();
                        break;
                }
            }
        }
    }
}
