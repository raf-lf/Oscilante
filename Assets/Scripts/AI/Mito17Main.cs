using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mito17Main : Creature
{
    [Header("Specific")]
    [Space(20)]
    public bool active;
    public int phase;
    public int state;

    public GameObject mainBody;

    [Header("Shield Chargers")]
    public Mito17Charger[] shieldChargers = new Mito17Charger[4];
    public float chargerActivationDelay = 10;
    private float stateTimer;
    public float exposedInterval = 5;
    public int[] chargersToActivate = { 1, 2, 4 };

    [Header("Attacks")]
    public Mito17Arm[] gunArms = new Mito17Arm[2];
    public float[] gunUseInterval = { 8, 4, 2 };
    public Mito17Leg[] legs = new Mito17Leg[2];
    public float[] stompTime = { 4, 2, 0.5f };

    [Header("Missile Shooter")]
    public Mito17MissileLauncher missileShooter;
    public float[] missileInterval = { 0, 10, 5 };

    [Header("Mines")]
    public GameObject mine;
    public BoxCollider2D mineSpawner;
    public int[] minesQty = { 0, 3, 5 };
    public float[] mineInterval = { 0, 30, 15 };
    private float mineIntervalTimer;

    [Header("Explosion")]
    public GameObject explosionEffect;
    public float explosionDelay = 5;
    private bool alreadyExploded;
    public GameObject wallToBreak;
    public GameObject[] gasLeaks;

    public override void Start()
    {
        //DELETE MEEEEEE
        StartBattle();
    }

    public void StartBattle()
    {
        active = true;
        BeginShielded();
    }



    private void BeginShielded()
    {
        state = 1;

        for (int i = chargersToActivate[phase]; i > 0; i--)
        {
            if (chargersToActivate[phase] == shieldChargers.Length + 1) shieldChargers[i].Activate();
            else RollChargers();
        }

    }
    private void RollChargers()
    {
        int roll = (int)Random.Range(0, shieldChargers.Length);

        Debug.Log(roll);
        if (shieldChargers[roll].state==1) RollChargers();
        else shieldChargers[roll].Activate();
    }
    private void CheckShieldChargers()
    {
        int activeChargersCount = 0;

        for (int i = 0; i < shieldChargers.Length; i++)
        {
            if (shieldChargers[i].state == 1) activeChargersCount++;
        }

        if (activeChargersCount <= 0) BeginExposed();

    }
    private void BeginExposed()
    {
        state = 2;
        anim.SetBool("exposed", true);
        stateTimer = Time.time + exposedInterval;

    }
    private void Exposed()
    {
        if (Time.time > stateTimer)
        {
            state = 1;
            anim.SetBool("exposed", false);
            BeginShielded();
        }
    }


    private IEnumerator Explosion()
    {
        alreadyExploded = true;

        paused = true;
        mainBody.GetComponent<Animator>().Play("explosion");

        yield return new WaitForSeconds(explosionDelay);

        GameObject explosion = Instantiate(explosionEffect);
        explosion.transform.position = mainBody.transform.position;

        wallToBreak.SetActive(false);

        foreach (GameObject leak in gasLeaks)
        {
            leak.SetActive(true);
        }

        paused = false;
    }

    public override void Death()
    {
        dying = true;
        if (deathVFX != null) Instantiate(deathVFX, transform);

        for (int i = 0; i < gunArms.Length; i++)
        {
            gunArms[i].Death();
        }
        for (int i = 0; i < legs.Length; i++)
        {
            legs[i].Death();
        }

        missileShooter.Death();

        mainBody.GetComponent<Animator>().SetBool("dying", true);

        anim.SetBool("dying", true);
    }

    protected override void Update()
    {

        base.Update();

        UpdatePhase();

        if(active && paused == false && dying == false)
        {
            if (phase == 2 && !alreadyExploded)
            {
                StartCoroutine(Explosion());
            }

            if (phase >= 1)
            {
                missileShooter.active = true;
                MineSpawn();
            }
            else missileShooter.active = false;

            switch (state)
            {
                case 0:
                    break;
                case 1:
                    CheckShieldChargers();
                    break;
                case 2:
                    Exposed();
                    break;

            }

        }

    }

    private void MineSpawn()
    {
        if (Time.time > mineIntervalTimer)
        {
            mineIntervalTimer = Time.time + mineInterval[phase];

            for (int i = minesQty[phase]; i > 0; i--)
            {
                GameObject spawnedMine = Instantiate(mine);
                spawnedMine.transform.position = mineSpawner.transform.position + new Vector3(Random.Range(-mineSpawner.size.x / 2, mineSpawner.size.x / 2), 0);

            }
        }

    }


    private void UpdatePhase()
    {
        if (!dying)
        {
            if (hp < hpMax * .33f) phase = 2;
            else if (hp < hpMax * .66f) phase = 1;
            else phase = 0;
        }

    }
}
