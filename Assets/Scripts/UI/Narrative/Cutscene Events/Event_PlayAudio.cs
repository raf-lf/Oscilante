using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_PlayAudio : CutsceneEvent
{

    public AudioSource source;
    public float volume = 1;
    public Vector2 pitchVariance = new Vector2(1,1);
    public AudioClip audioClip;

    public override void ExecuteEvent()
    {
        playSFX();

        base.ExecuteEvent();

    }

    public void playSFX()
    {
        if (source == null) source = GameManager.scriptAudio.genericSfxAudioSource;

        source.volume = volume * AudioManager.volumeSfx;
        source.pitch = Random.Range(pitchVariance.x, pitchVariance.y);
        source.PlayOneShot(audioClip);

    }


}
