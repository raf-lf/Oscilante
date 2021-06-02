using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioLoop : MonoBehaviour
{
    public bool playOnAwake;
    public AudioSource source;

    public enum audioType
    {
        sfx, ambient, bgm
    }
    public audioType type;

    private void Update()
    {
        switch (type)
        {
            case audioType.sfx:
                source.volume = source.volume * AudioManager.volumeSfx;
                break;

            case audioType.ambient:
                source.volume = source.volume * AudioManager.volumeAmbient;
                break;

            case audioType.bgm:
                source.volume = source.volume * AudioManager.volumeBgm;
                break;
        }

    }

}
