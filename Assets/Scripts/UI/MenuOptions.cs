using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{
    private bool setup;

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

        volumeSliderSfx.value = AudioManager.volumeSfx;
        volumeSliderAmbient.value = AudioManager.volumeAmbient;
        volumeSliderBgm.value = AudioManager.volumeBgm;

        toggleInvulnerability.isOn = Invulnerability;
        toggleInfiniteHeals.isOn = InfiniteHeals;
        toggleInfiniteGrenades.isOn = InfiniteGrenades;
        toggleInfiniteAmmo.isOn = InfiniteAmmo;

    }

    private void Update()
    {
        postProcessingEnabled = togglePostProcessing.isOn;
        pixelPerfectEnabled = togglePixelPerfect.isOn;

        Camera.main.GetComponent<CameraReferences>().postProcessing.enabled = postProcessingEnabled;
        Camera.main.GetComponent<CameraReferences>().pixelPerfect.enabled = pixelPerfectEnabled;

        AudioManager.volumeSfx = volumeSliderSfx.value;
        AudioManager.volumeAmbient = volumeSliderAmbient.value;
        AudioManager.volumeBgm = volumeSliderBgm.value;

        Invulnerability = toggleInvulnerability.isOn;
        InfiniteHeals = toggleInfiniteHeals.isOn;
        InfiniteGrenades = toggleInfiniteGrenades.isOn;
        InfiniteAmmo = toggleInfiniteAmmo.isOn;
    }
}
