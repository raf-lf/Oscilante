using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mito17Leg : MonoBehaviour
{
    public bool paused;
    public Mito17Main main;
    private int state;
    [SerializeField]
    private int framesInArea;
    [SerializeField]
    private int targetFrames;
    public BoxCollider2D stompChargeArea;
    public LayerMask playerDetection;

    private void StompBegin()
    {
        framesInArea = 0;
        state = 1;
        GetComponent<Animator>().Play("stomp");
    }

    public void StompEnd()
    {
        state = 0;
    }

    private void StompBuildUp()
    {
        if (!main.paused)
        {
            if (framesInArea < targetFrames)
            {
                if (PlayerInStompArea()) framesInArea++;
                else if (framesInArea > 0) framesInArea--;
            }
            else StompBegin();
        }

    }

    public void Death()
    {
        GetComponent<Animator>().Play("death");
    }

    private void Update()
    {

        targetFrames = (int)(main.stompTime[main.phase] * 60);

        if (!paused && !main.paused && !main.dying)
        {
            switch (state)
            {
                case 0:
                    StompBuildUp();
                    break;
            }
        }
    }


    private bool PlayerInStompArea()
    {
        if (Physics2D.BoxCast(stompChargeArea.transform.position, stompChargeArea.size, 0, Vector2.zero, 0, playerDetection)) return true;
        else return false;
    }
}
