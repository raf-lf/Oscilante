using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAudio : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource source;
    public AudioClip[] sfxFire;
    public AudioClip[] sfxExplosion;

    public void SfxFire()
    {
        GetComponentInChildren<Creature>().playSFX(sfxFire, 1, new Vector2(.7f, 1.3f));
    }
    public void SfxExplosion()
    {
        GetComponentInChildren<Creature>().playSFX(sfxExplosion, 1, new Vector2(.7f, 1.3f));
    }
}
