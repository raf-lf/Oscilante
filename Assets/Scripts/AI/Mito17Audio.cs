using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mito17Audio : MonoBehaviour
{
    [Header("Audio")]
    public Creature main;
    public AudioClip[] sfxActivation;
    public AudioClip[] sfxExplosionCharge;
    public AudioClip[] sfxDeath;

    public void SfxActivation()
    {
        main.playSFX(sfxActivation, 1, Vector2.one);
    }
    public void SfxExplosionCharge()
    {
        main.playSFX(sfxExplosionCharge, 1, Vector2.one);
    }
    public void SfxDeath()
    {
        main.playSFX(sfxDeath, 1, Vector2.one);
    }
}
