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

    [Header("Components")]
    public GameObject mainBody;
    public Animator damageFeeback;

    [Header("Shield Chargers")]
    public Mito17Charger[] shieldChargers = new Mito17Charger[4];
    public float chargerActivationDelay = 10;
    private float stateTimer;
    public float exposedInterval = 5;
    public int[] chargersToActivate;

    [Header("Attacks")]
    public Mito17Arm[] gunArms = new Mito17Arm[2];
    public float[] gunUseInterval;
    public Mito17Leg[] legs = new Mito17Leg[2];
    public float[] stompTime;

    [Header("Missile Shooter")]
    public Mito17MissileLauncher missileShooter;
    public float[] missileInterval;

    [Header("Mines")]
    public GameObject mine;
    public BoxCollider2D mineSpawner;
    public int[] minesQty;
    public float[] mineInterval;
    private float mineIntervalTimer;

    [Header("Explosion")]
    public GameObject explosionEffect;
    public float explosionDelay = 5;
    private bool alreadyExploded;
    public GameObject wallToBreak;
    public GameObject[] gasLeaks;

    [Header("Narrative")]
    public CallCommentLog[] battleComments = new CallCommentLog[4];
    public Cutscene postBattleCutscene;

    [Header("Audio")]
    public AudioClip[] faceShield;


    [Header("Boss Battle")]
    public AudioClip bossMusic;
    private AudioClip memoryMusic;
    public SwitchConnectedObject[] arenaDoors = new SwitchConnectedObject[2];


    public override void LoadData()
    {
        arenaDoors[0].forceInactive = false;
        arenaDoors[1].forceInactive = false;

        wallToBreak.SetActive(false);

        foreach (GameObject leak in gasLeaks)
        {
            leak.SetActive(true);
            leak.GetComponent<Animator>().SetBool("disabled", true);
        }

        mainBody.SetActive(false);

    }

    public void SfxFaceShield()
    {
        playSFX(faceShield, 1, new Vector2(.9f,1.1f));
    }

    public void StartBattleSignal()
    {
        StartCoroutine(StartBattle());
    }

    public IEnumerator StartBattle()
    {
        arenaDoors[0].forceInactive = true;
        arenaDoors[1].forceInactive = true;

        memoryMusic = GameManager.scriptAudio.bgmAudioSource.clip;
        GameManager.scriptAudio.bgmAudioSource.clip = bossMusic;
        GameManager.scriptAudio.bgmAudioSource.Play();

        mainBody.GetComponent<Animator>().Play("activation");
        yield return new WaitForSeconds(3);


        active = true;
        BeginShielded();

    }

    public void BattleEnd()
    {
        GameManager.scriptAudio.MusicOff(0.5f);

        arenaDoors[0].forceInactive = false;
        arenaDoors[1].forceInactive = false;

        if (memoryMusic != null)
        {
            GameManager.scriptAudio.bgmAudioSource.clip = memoryMusic;
            GameManager.scriptAudio.bgmAudioSource.Play();
            GameManager.scriptAudio.MusicOn(1);
        }

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

       // Debug.Log(roll);
        if (shieldChargers[roll].state == 1) RollChargers();
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
        if (GetComponent<SaveableObject>()) GetComponent<SaveableObject>().SaveData();

        state = 3;
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

        postBattleCutscene.CutsceneStartEnd(true);
    }
    public void DeathSequenceEnd()
    {
        BattleEnd();
        mainBody.GetComponent<Animator>().Play("death");

    }

    protected override void Update()
    {
        base.Update();

        UpdatePhase();

        if (!dying) damageFeeback.SetInteger("phase", phase);
        else damageFeeback.SetInteger("phase", 0);

        if (active) PlayComment();

        if (active && paused == false && dying == false)
        {
            PhaseActions();

            if (phase == 3 && !alreadyExploded)
            {
                StartCoroutine(Explosion());
            }

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

    private void PhaseActions()
    {
            switch (phase)
            {
                case 0:
                    missileShooter.active = false;
                    break;
                case 1:
                    missileShooter.active = true;
                    break;
                case 2:
                    missileShooter.active = true;
                    MineSpawn();
                    break;
                case 3:
                    missileShooter.active = true;
                    MineSpawn();
                    break;
            }
    }
    private void UpdatePhase()
    {
        if (!dying)
        {
            if (hp > 0)
            {
                if (hp < hpMax * .25f)
                {
                    phase = 3;
                }
                else if (hp < hpMax * .50f) 
                {
                    phase = 2;
                }
                else if (hp < hpMax * .75f) 
                {
                    phase = 1;

                }
                else phase = 0;
            }
        }

    }
    
    private void PlayComment()
    {
        if (!battleComments[phase].off)
        {
            battleComments[phase].off = true;
            battleComments[phase].Comment();
        }

    }

}
