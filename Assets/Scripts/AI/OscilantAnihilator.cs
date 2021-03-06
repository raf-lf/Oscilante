using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscilantAnihilator : Creature
{

    [Header("Specific")]
    public int phase;
    public Animator damageFeedbackAnimator;

    [Header("Behavior")]
    public bool active;
    private bool busy;

    [Header("Attack")]
    public float attackRadius = 2;
    public float attackCooldown = 4;
    private float attackCooldownTimer;
    public float attackAnimationDuration = 2;

    [Header("Special")]
    public float minionSpawnCooldown = 10;
    private float minionSpawnCooldownTimer;
    public int avaiableMinions = 5;

    [Header("Components")]
    public Animator eyeAnimator;
    public Animator bladeAnimator;
    public Rigidbody2D blades;
    public GameObject[] teleportVFX = new GameObject[2];
    public GameObject minion;
    private Vector3 minionSpawnPosition;
    public List<GameObject> minionList = new List<GameObject>();


    [Header("Audio")]
    public AudioClip[] attack = new AudioClip[1];
    public AudioClip[] activate = new AudioClip[1];
    public AudioClip[] stomp = new AudioClip[1];
    public AudioClip[] death = new AudioClip[1];

    [Header ("Boss Battle")]
    public bool bossBatle;
    public GameObject postDefeatCutscene;
    public SwitchMoveablePlatform[] elevatorSwitches = new SwitchMoveablePlatform[3];
    public AudioClip bossMusic;
    private AudioClip memoryMusic;
    public Animator cityGates;


    public override void LoadData()
    {

        cityGates.SetBool("active", true);
        postDefeatCutscene.SetActive(true);
        gameObject.SetActive(false);

    }

    public void SfxActivate()
    {
        playSFX(activate, 1, new Vector2(0.9f, 1.1f));
    }
    public void SfxAttack()
    {
        playSFX(attack, 1, new Vector2(0.9f, 1.1f));
    }
    public void SfxStomp()
    {
        playSFX(stomp, 0.3f, standartPitchVariance);
    }
    public void SfxDeath()
    {
        playSFX(death, 1, Vector2.one);
    }


    public override void Start()
    {
        base.Start();

    }

    private void BossBattleBegin()
    {
            for (int i = 0; i < elevatorSwitches.Length; i++)
            {
                elevatorSwitches[i].unusable = true;
            }

        memoryMusic = GameManager.scriptAudio.bgmAudioSource.clip;
        GameManager.scriptAudio.bgmAudioSource.clip = bossMusic;
        GameManager.scriptAudio.bgmAudioSource.Play();

    }
    IEnumerator BossBattleEnd()
    {
        GameManager.Cutscene(true);
        Player.PlayerControls = false;
        GameManager.scriptCamera.followTarget = gameObject.transform;
        GameManager.scriptAudio.MusicOff(0.5f);

        yield return new WaitForSeconds(8);
        Player.PlayerControls = true;
        GameManager.scriptCamera.followTarget = GameManager.PlayerCharacter.transform;
        GameManager.Cutscene(false);
        postDefeatCutscene.SetActive(true);

        for (int i = 0; i < elevatorSwitches.Length; i++)
        {
            elevatorSwitches[i].unusable = false;
        }
        GameManager.scriptAudio.bgmAudioSource.clip = memoryMusic;
        GameManager.scriptAudio.bgmAudioSource.Play();
        GameManager.scriptAudio.MusicOn(1);
    }


    public override void Death()
    {
        if (bossBatle && GetComponent<SaveableObject>()) GetComponent<SaveableObject>().SaveData();

        StopAllCoroutines();
        eyeAnimator.SetInteger("state", 3);
        busy = true;
        bladeAnimator.SetInteger("state",0);
        anim.Play("death");

        /*
         * minionList.Sort();
        foreach (GameObject existingMinion in minionList)
        {
            existingMinion.GetComponent<OscilantDud>().Death();
        }
        */

        if (bossBatle) StartCoroutine(BossBattleEnd());

    }

    public void bladeRotationBoost(float force)
    {
        blades.angularVelocity -= force;

    }
    public void eyeAnimationControl (int state)
    {
        eyeAnimator.SetInteger("state", state);

    }

    private bool targetInAttackRange()
    {
        if (Physics2D.CircleCast(transform.position, attackRadius, Vector2.zero, 0, detectionMask)) return true;
        else return false;

    }

    public void Attack()
    {
        busy = true;
        eyeAnimator.SetInteger("state", 3);
        anim.Play("attack");
        bladeAnimator.Play("blades_attack");
        attackCooldownTimer = Time.time + attackCooldown;
        StopAllCoroutines();
        StartCoroutine(AttackEnd());

    }

    IEnumerator AttackEnd()
    {
        yield return new WaitForSeconds(attackAnimationDuration);
        busy = false;
    }

    public void SpawnMinion()
    {
        avaiableMinions -= 1;
        eyeAnimationControl(4);
        minionSpawnCooldownTimer = Time.time + minionSpawnCooldown;
        minionSpawnPosition = new Vector3(transform.position.x + Random.Range(-3.2f, 3.2f), transform.position.y + Random.Range(0, 3.2f),0);

        GameObject teleportCast = Instantiate(teleportVFX[1], eyeAnimator.gameObject.transform);

        GameObject teleportTarget = Instantiate(teleportVFX[0]);
        teleportTarget.transform.position = minionSpawnPosition;

        Invoke("finishedSpawning", 1f);

    }

    private void finishedSpawning()
    {
        GameObject createdMinion = Instantiate(minion);
        createdMinion.GetComponent<OscilantShredder>().overlord = gameObject;
        minionList.Add(createdMinion);
        createdMinion.transform.position = minionSpawnPosition;
        eyeAnimator.SetInteger("state", 1);

    }

    private void finishedActivating()
    {
        active = true;
        bladeAnimator.SetInteger("state", 1);

    }

    private void UpdatePhase()
    {
        damageFeedbackAnimator.SetInteger("phase", phase);

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
        else phase = 0;

    }

    protected override void Update()
    {
        UpdatePhase();

        if (GameManager.CutscenePlaying == false)
        {
            if (active == false)
            {
                if (TargetInsideDetection() && anim.GetBool("active") == false)
                {
                    if(bossBatle) BossBattleBegin();
                    anim.SetBool("active", true);
                    eyeAnimator.SetInteger("state", 1);
                    Invoke("finishedActivating", 1);

                }

            }
            else if (busy == false)
            {
                if (Time.time > minionSpawnCooldownTimer && hp <= hpMax * 0.5f && hp > 0)
                {
                    if (avaiableMinions > 0) SpawnMinion();

                }

                if (targetInAttackRange() == false)
                {
                    if (transform.position.x > GameManager.PlayerCharacter.transform.position.x)
                    {
                        moveDirection = new Vector2(-1, 0);
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else
                    {
                        moveDirection = new Vector2(1, 0);
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    Move();
                    bladeAnimator.SetInteger("state", 1);
                    eyeAnimator.SetInteger("state", 1);

                }
                else
                {
                    StopMove();
                    bladeAnimator.SetInteger("state", 2);
                    eyeAnimator.SetInteger("state", 2);
                    if (Time.time > attackCooldownTimer) Attack();
                }
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,1,0,1f);

        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z), attackRadius);
       // Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
