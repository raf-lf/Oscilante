using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_SetActiveState : CutsceneEvent
{
    public enum state
    {
        active, inactive
    }
    public state activeState;
    public GameObject targetObject;

    public override void ExecuteEvent()
    {
        if (activeState == state.active) targetObject.SetActive(true);
        else targetObject.SetActive(false);

        base.ExecuteEvent();

    }

}
