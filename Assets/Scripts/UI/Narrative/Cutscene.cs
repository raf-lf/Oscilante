using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Cutscene: MonoBehaviour
{
    public bool replayable;
    public bool off;
    public bool triggerColliderActivation = true;

    [Header("Events")]
    public int currentEvent = 0;
    public CutsceneEvent[] events = new CutsceneEvent[1];


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && off == false && triggerColliderActivation)
        {
            CutsceneStartEnd(true);

        }
        
    }

    public void CutsceneStartEnd(bool start)
    {
        if (start)
        {
            if (replayable == false)
            {
                if (GetComponent<SaveableObject>()) GetComponent<SaveableObject>().SaveData();
                off = true;
            }

            if (GameManager.scriptComment.textActive) GameManager.scriptComment.Interrupt();
            if (GameManager.scriptLog.textActive) GameManager.scriptLog.Interrupt();

            currentEvent = 0;
            GameManager.Cutscene(true);
            PlayEvent();
        }
        else GameManager.Cutscene(false);

    }

    public void PlayEvent()
    {
        if (currentEvent < events.Length)
        {
            Debug.Log("Played event "+ currentEvent);
            events[currentEvent].ExecuteEvent();
        }
        else
        {
            Debug.Log("Cutscene ended.");

            CutsceneStartEnd(false);


        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "icon_dialogue", true);
    }
}

