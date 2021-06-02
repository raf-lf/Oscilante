using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Creature
{

    [Header("Turret")]
    public float aimVariance;
    public float attackCooldownSeconds;
    [HideInInspector]
    public float attackCooldownTimer;
    public GameObject projectile;
    public bool inCooldown;


    [Header("Parts")]
    public Animator turretAnimator;
    public GameObject turretAxis;
    public Transform projectileOrigin;
    public TankMachineGun machineGun;
    private float rotationZ;
    public GameObject parent;

    [Header("Boss Battle")]
    public bool bossBatle;
    private bool battleBegun;
    public GameObject[] bossCameraZones;
    public SwitchConnectedObject arenaDoor;
    public Switch postDefeatSwitch;
    public AudioClip bossMusic;
    private AudioClip memoryMusic;

    public override void LoadData()
    {

        postDefeatSwitch.unusable = false;
        arenaDoor.forceInactive = false;

        foreach (GameObject zone in bossCameraZones)
        {
            zone.SetActive(false);
        }

        parent.SetActive(false);

    }

    private void BossBattleBegin()
    {
        battleBegun = true;
        postDefeatSwitch.unusable = true;

        arenaDoor.forceInactive = true;

        memoryMusic = GameManager.scriptAudio.bgmAudioSource.clip;
        GameManager.scriptAudio.MusicMax();
        GameManager.scriptAudio.bgmAudioSource.clip = bossMusic;
        GameManager.scriptAudio.bgmAudioSource.Play();

    }

    IEnumerator BossBattleEnd()
    {
        GameManager.Cutscene(true);

        GameManager.scriptCamera.ResetOffset();

        foreach (GameObject zone in bossCameraZones)
        {
            zone.SetActive(false);
        }

        GameManager.scriptCamera.followTarget = gameObject.transform;
        GameManager.scriptAudio.MusicOff(0.5f);

        yield return new WaitForSeconds(5);

        GameManager.Cutscene(false);

        GameManager.scriptCamera.followTarget = GameManager.PlayerCharacter.transform;

        postDefeatSwitch.unusable = false;
        arenaDoor.forceInactive = false;

        GameManager.scriptAudio.bgmAudioSource.clip = memoryMusic;
        GameManager.scriptAudio.bgmAudioSource.Play();
        GameManager.scriptAudio.MusicOn(1);
    }

    private void TurretShot()
    {
        if (Time.time > attackCooldownTimer && inCooldown == false)
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

    }

    public void TurretCooldown()
    {
        inCooldown = true;
        attackCooldownTimer = Time.time + 1;
        Invoke(nameof(ResetTurretCooldown), 7);

    }
    public void ResetTurretCooldown()
    {
        inCooldown = false;
        attackCooldownTimer = Time.time + 1;

    }


    public override void Death()
    {
        base.Death();

        if (bossBatle && GetComponent<SaveableObject>()) GetComponent<SaveableObject>().SaveData();

        if (bossBatle) StartCoroutine(BossBattleEnd());

        turretAnimator.Play("death");
        if (machineGun.hp>0) machineGun.Death();
        Destroy(parent, 10);
    }


    private void FixedUpdate()
    {
        //Physics2D.CircleCast(projectileOrigin.position, detectionRadius, Vector2.zero, 0, detectedTargets);

    }

    protected override void Update()
    {
        if (paused == false && dying == false)
        {
            turretAnimator.SetBool("cooldown", inCooldown);

            if (TargetInsideDetection() && inCooldown == false)
            {
                if (bossBatle && battleBegun == false) BossBattleBegin();

                rotationZ = Calculations.GetRotationZToTarget(projectileOrigin.position, target.transform.position);
                if (rotationZ > 90 || rotationZ < -90) turretAxis.transform.rotation = Quaternion.Euler(0, 180, -rotationZ + 180);
                else turretAxis.transform.rotation = Quaternion.Euler(0, 0, rotationZ);

                TurretShot();
            }
        }
    }
}

