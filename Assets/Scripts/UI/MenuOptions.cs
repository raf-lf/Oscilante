using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{
    [Header("Graphics")]
    public Toggle togglePostProcessing;
    public Toggle togglePixelPerfect;

    [Header("Audio")]
    public Slider volumeSliderSfx;
    public Slider volumeSliderAmbient;
    public Slider volumeSliderBgm;

    [Header("Cheats")]
    public Toggle toggleInvulnerability;
    public Toggle toggleInfiniteHeals;
    public Toggle toggleInfiniteGrenades;
    public Toggle toggleInfiniteAmmo;

    public static bool Invulnerability;
    public static bool InfiniteHeals;
    public static bool InfiniteGrenades;
    public static bool InfiniteAmmo;


    private void Update()
    {
        Camera.main.GetComponent<CameraReferences>().postProcessing.enabled = togglePostProcessing.isOn;
        Camera.main.GetComponent<CameraReferences>().pixelPerfect.enabled = togglePixelPerfect.isOn;

        GameManager.scriptAudio.volumeSfx = volumeSliderSfx.value;
        GameManager.scriptAudio.volumeAmbient = volumeSliderAmbient.value;
        GameManager.scriptAudio.volumeBgm = volumeSliderBgm.value;

        Invulnerability = toggleInvulnerability.isOn;
        InfiniteHeals = toggleInfiniteHeals.isOn;
        InfiniteGrenades = toggleInfiniteGrenades.isOn;
        InfiniteAmmo = toggleInfiniteAmmo.isOn;
    }
}
