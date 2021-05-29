using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CutsceneEvent : MonoBehaviour
{
    public float nextEventInterval;
    public virtual void ExecuteEvent()
    {
        StartCoroutine(DelayEvent());
    }

    IEnumerator DelayEvent()
    {
        yield return new WaitForSeconds(nextEventInterval);

        if (GetComponent<Cutscene>())
        {
            GetComponent<Cutscene>().currentEvent += 1;
            GetComponent<Cutscene>().PlayEvent();
        }
        else
        {
            //Directs events in children objects to search for the cutscene in a parent object. It's better this way.
            GetComponentInParent<Cutscene>().currentEvent += 1;
            GetComponentInParent<Cutscene>().PlayEvent();
        }

    }


    //This is only for Call Dialogue and Continue Dialogue events
    public void ContinueEvent()
    {
        StartCoroutine(DelayEvent());
    }
}
