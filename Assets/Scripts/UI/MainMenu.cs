using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject overlay;
    public Animator options;
    public Animator credits;

    public void ButtonStartGame()
    {
        FadeOut();
        Invoke(nameof(StartGame), 2);
        if (options.GetBool("active")) options.SetBool("active", false);
        if (credits.GetBool("active")) credits.SetBool("active", false);

    }

    public void ButtonOptions()
    {
        options.SetBool("active", !options.GetBool("active"));
       if (credits.GetBool("active")) credits.SetBool("active", false);

    }

    public void ButtonCredits()
    {
        credits.SetBool("active", !credits.GetBool("active"));
        if (options.GetBool("active")) options.SetBool("active", false);

    }

    public void ButtonExit()
    {
        FadeOut();
        Invoke(nameof(ExitGame),2);
        if (options.GetBool("active")) options.SetBool("active", false);
        if (credits.GetBool("active")) credits.SetBool("active", false);

    }

    private void StartGame()
    {
        SceneManager.LoadScene("Level 1",LoadSceneMode.Single);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    public void FadeOut()
    {
        overlay.GetComponent<Animator>().SetInteger("state", 1);
    }
}
