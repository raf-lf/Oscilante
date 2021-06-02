using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Move : CutsceneEvent
{
    public enum type
    {
        targetObject, player
    }
    public type movedObject;

    public GameObject targetObject;
    public Transform movePoint;

    public float speed;
    public float distanceTolerance;
    private bool moving;

    public override void ExecuteEvent()
    {
        switch (movedObject)
        {
            case type.player:
                targetObject = GameManager.PlayerCharacter;
                break;
            case type.targetObject:
                break;
        }
        moving = true;

    }

    private void Update()
    {
        if(moving)
        {
            if (Vector2.Distance(targetObject.transform.position, movePoint.position) > distanceTolerance)
            {
                targetObject.GetComponent<Animator>().SetBool("move", true);
                Vector2 moveDirection = Calculations.GetDirectionToTarget(targetObject.transform.position, movePoint.position);
                targetObject.GetComponent<Rigidbody2D>().velocity = speed * moveDirection;

            }
            else
            {
                targetObject.GetComponent<Animator>().SetBool("move", false);
                moving = false;

                Continue();
            }
        }
        
    }

    public void Continue()
    {
        base.ExecuteEvent();
    }

}
