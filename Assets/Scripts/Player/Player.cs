using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int hp = 10;
    public static int hpMax = 10;

    public static bool PlayerControls = true;
    public static bool CantAct = false;

    public GameObject damageVFX;
    public int iFramesSeconds = 1;
    private bool inIFrames;
    public SpriteRenderer[] spriteGroup;

    public bool inCover;
    public Collider2D DamageCollider;
    public Collider2D CoverCollider;

    public Animator shaderAnimator;
    public bool dead;


    void Start()
    {
        GameManager.PlayerCharacter = this.gameObject;
        GameManager.scriptPlayer = GetComponent<Player>();
        GameManager.scriptWeapons = GetComponent<PlayerWeapons>();
        GameManager.scriptMovement = GetComponent<PlayerMovement>();
        GameManager.scriptActions = GetComponent<PlayerActions>();
        GameManager.scriptPlayerAudio = GetComponent<PlayerAudio>();
    }

    public void Damage(int hpLoss, float knockback, Transform sourcePosition)
    {
        if (inIFrames == false && PlayerControls && MenuOptions.Invulnerability == false)
        {
            ChangeHp(hpLoss * -1);

            if (hpLoss > 0)
            {
                if (damageVFX != null)
                {
                    GameObject vfx = Instantiate(damageVFX, transform);
                    vfx.transform.position += new Vector3(0, .8f,0);
                }

                ToggleIFrames(true);
            }

            if (knockback != 0 && sourcePosition != null)
            {
                GetComponent<PlayerMovement>().Knockback(knockback, sourcePosition);
            }
        }
    }

    public void Heal(int hpGain)
    {
            ChangeHp(hpGain);
    }

    public void ChangeHp(int change)
    {
        if (hp + change < 0) hp = 0;
        else if (hp + change > hpMax) hp = hpMax;
        else hp += change;

        if (hp == 0) Death();
    }
    
    public void Death()
    {
        dead = true;
        CoverCollider.enabled = false;
        DamageCollider.enabled = false;

        Animator anim = GetComponent<Animator>();
        anim.Play("death");
        GameManager.scriptWeapons.SwapWeapon(PlayerWeapons.equipedWeapon);
        PlayerControls = false;
        shaderAnimator.SetBool("dead", true);

        if(GameManager.scriptActions.remainingPulses > 0)
        {
            GameManager.scriptActions.remainingPulses = 0;
            GameManager.scriptActions.HealActivate(false);

        }
        GameManager.scriptLog.Interrupt();
        GameManager.scriptComment.Interrupt();
        GameManager.scriptCamera.ChangeOffset(new Vector3 (0,1,-5));
        GameManager.scriptAudio.MusicOff(0.5f);
        StopCoroutine(PostDeath());
        StartCoroutine(PostDeath());
    }

    IEnumerator PostDeath()
    {
        Invoke(nameof(DeathFadeOut),3);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        hp = hpMax;
        PlayerControls = true;
        GameManager.scriptAudio.MusicOn(1);


    }

    private void DeathFadeOut()
    {
        GameManager.overlay.GetComponent<Animator>().SetInteger("state", 1);
    }

    public void ToggleIFrames(bool toggleOn)
    {
        inIFrames = toggleOn;
        shaderAnimator.SetBool("damaged", toggleOn);

        if (toggleOn)
        {
            DamageCollider.enabled = false;
            if (inCover) Cover(false);
            StopCoroutine(IFramesCount());
            StartCoroutine(IFramesCount());
        }
        else
        {
            if (inCover == false) DamageCollider.enabled = true;
        }

    }

    public void Cover (bool covering)
    {
        if (GameManager.GamePaused == false)
        {
            inCover = covering;

            CoverCollider.enabled = covering;
            DamageCollider.enabled = !covering;
            
            GameManager.scriptMovement.HaltMovement(covering);

            Animator anim = GetComponent<Animator>();
            anim.SetBool("cover", covering);
            shaderAnimator.SetBool("cover", covering);

            /*
            spriteGroup = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer sprite in spriteGroup)
            {
                if (covering) sprite.sortingLayerName = "Cover";
                else sprite.sortingLayerName = "Default";
            }
            */
        }

    }

    public IEnumerator IFramesCount()
    {
        yield return new WaitForSeconds(iFramesSeconds);
        if (dead == false) ToggleIFrames(false);
    }


}


