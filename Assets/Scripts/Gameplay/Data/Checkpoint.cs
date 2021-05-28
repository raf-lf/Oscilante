using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointId;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GetComponent<SaveableObject>()) GetComponent<SaveableObject>().SaveData();

            // GameManager.scriptLog.Write("Checkpoint salvo!");
            Debug.Log("Checkpoint saved.");
            SaveDataManager.SetCheckpoint(checkpointId, transform.position);

            gameObject.SetActive(false);
        }
    }
}
