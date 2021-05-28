using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchConnectedObject : MonoBehaviour
{
    public Switch[] switchesConnected;
    public int switchesNeeded;
    [SerializeField]
    private int switchesActive;
    public string activeAnimatorString = "active";
    public Animator animator;
    public bool forceActive;
    public bool forceInactive;

    void Activate()
    {
        if (animator.GetBool(activeAnimatorString) == false) animator.SetBool(activeAnimatorString, true);

    }
    void Deactivate()
    {
        if (animator.GetBool(activeAnimatorString)) animator.SetBool(activeAnimatorString, false);

    }

    void Update()
    {
        switchesActive = 0;

        if (forceActive) Activate();
        else if (forceInactive) Deactivate();
        else
        {
            for (int i = 0; i < switchesConnected.Length; i++)
            {
                if (switchesConnected[i].isActive) switchesActive++;
            }
            if (switchesActive >= switchesNeeded) Activate();
            else Deactivate();
        }
    }
}
