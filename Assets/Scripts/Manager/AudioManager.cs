using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio")]

    public AudioSource bgmAudioSource;
    public AudioSource genericSfxAudioSource;
    public AudioSource genericAmbientAudioSource;

    public static float volumeSfx = .5f;
    public static float volumeBgm = .75f;
    public static float volumeAmbient = .5f;
    public float volumeBgmModifier = 1;

    private void Start()
    {
        GameManager.scriptAudio = GetComponent<AudioManager>();
    }

    private void Update()
    {
        genericSfxAudioSource.volume = volumeSfx;
        genericAmbientAudioSource.volume = volumeAmbient;
        bgmAudioSource.volume = volumeBgm * volumeBgmModifier;

    }

    public static void PlaySfx(AudioClip clip, float volume, Vector2 pitchVariance)
    {
        GameManager.scriptAudio.genericSfxAudioSource.volume = volume * AudioManager.volumeSfx;
        GameManager.scriptAudio.genericSfxAudioSource.pitch = Random.Range(pitchVariance.x, pitchVariance.y);
        GameManager.scriptAudio.genericSfxAudioSource.PlayOneShot(clip);

    }

    public void MusicOff(float speed)
    {
        GetComponent<Animator>().speed = speed;
        GetComponent<Animator>().SetBool("musicOff", true);
        GetComponent<Animator>().SetBool("max", false);

    }
    public void MusicOn(float speed)
    {
        GetComponent<Animator>().speed = speed;
        GetComponent<Animator>().SetBool("musicOff", false);
        GetComponent<Animator>().SetBool("max", false);

    }
    public void MusicMax()
    {
        GetComponent<Animator>().SetBool("max", true);
    }
}
