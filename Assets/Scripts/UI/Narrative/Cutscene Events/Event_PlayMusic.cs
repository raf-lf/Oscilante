using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_PlayMusic : CutsceneEvent
{
    public AudioClip music;

    public override void ExecuteEvent()
    {
        GameManager.scriptAudio.bgmAudioSource.clip = music;
        if (music != null) GameManager.scriptAudio.bgmAudioSource.Play();
        else GameManager.scriptAudio.bgmAudioSource.Stop();

        base.ExecuteEvent();

    }



}
