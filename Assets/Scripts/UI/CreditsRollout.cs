using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CreditsRollout : MonoBehaviour
{
    public float normalSpeed = 0.25f;
    public float fastSpeed = 1f;

    public Animator overlay;

    void Update()
    {
        GetComponent<Animator>().StartRecording(50);
        if (Input.GetMouseButton(0)) GetComponent<Animator>().speed = fastSpeed;
        else  GetComponent<Animator>().speed = normalSpeed;

        if (Input.GetKeyDown(KeyCode.Escape)) StartCoroutine(GoToMenu());
    }

    public IEnumerator GoToMenu()
    {
        SavedData.ClearSavedLists();

        GameManager.scriptAudio.MusicOff(1);
        overlay.SetInteger("state", 1);
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(0, LoadSceneMode.Single);

    }
}
