using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{
    [Header("Graphics")]
    public Toggle togglePostProcessing;
    public Toggle togglePixelPerfect;

    public static bool postProcessingEnabled = true;
    public static bool pixelPerfectEnabled = false;

    [Header("Audio")]
    public Slider volumeSliderSfx;
    public Slider volumeSliderAmbient;
    public Slider volumeSliderBgm;

    [Header("Cheats")]
    public Toggle toggleInvulnerability;
    public Toggle toggleInfiniteHeals;
    public Toggle toggleInfiniteGrenades;
    public Toggle toggleInfiniteAmmo;

    public static bool Invulnerability = false;
    public static bool InfiniteHeals = false;
    public static bool InfiniteGrenades = false;
    public static bool InfiniteAmmo = false;

    private void Start()
    {

        Camera.main.GetComponent<CameraReferences>().postProcessing.enabled = postProcessingEnabled;
        Camera.main.GetComponent<CameraReferences>().pixelPerfect.enabled = pixelPerfectEnabled;
        togglePostProcessing.isOn = postProcessingEnabled;
        togglePixelPerfect.isOn = pixelPerfectEnabled;

        volumeSliderSfx.value = GameManager.scriptAudio.volumeSfx;
        volumeSliderAmbient.value = GameManager.scriptAudio.volumeAmbient;
        volumeSliderBgm.value = GameManager.scriptAudio.volumeBgm;

        toggleInvulnerability.isOn = Invulnerability;
        toggleInfiniteHeals.isOn = InfiniteHeals;
        toggleInfiniteGrenades.isOn = InfiniteGrenades;
        toggleInfiniteAmmo.isOn = InfiniteAmmo;

    }

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
