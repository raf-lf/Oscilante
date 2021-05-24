using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_CameraOffset : CutsceneEvent
{

    public float lerpSpeed = 0.05f;
    public Vector3 offsetChange;
    public bool overrideCurentOffset;

    public override void ExecuteEvent()
    {
        GameManager.scriptCamera.followSpeed = lerpSpeed;

        if (overrideCurentOffset == false) offsetChange += GameManager.scriptCamera.offset;

        GameManager.scriptCamera.ChangeOffset(offsetChange);

        base.ExecuteEvent();

    }

}
