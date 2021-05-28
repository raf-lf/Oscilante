using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public string sceneToGo;
    public Vector3 spawnPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartTransition();
        }
    }

    public void StartTransition()
    {
        SaveDataManager.SaveData();

        Player.PlayerControls = false;
        GameManager.overlay.GetComponent<Animator>().SetInteger("state", 1);
        Invoke(nameof(LoadScene), 2);
    }

    private void LoadScene()
    {
        GameManager.overlay.GetComponent<Animator>().SetInteger("state", 0);
        GameManager.ItemHeal = SaveDataManager.startHeals;
        Player.hp = Player.hpMax;
        Player.PlayerControls = true;

        SaveDataManager.playerSpawnPosition = spawnPosition;
        SaveDataManager.SaveData();

        SceneManager.LoadScene(sceneToGo,LoadSceneMode.Single);
    }
}
