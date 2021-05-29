using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_AnimatePlayer : CutsceneEvent
{
    public enum animationType
    {
        comCall, commReceive, commTurnoff, setBoolean, setInteger, setFloat, playAnimation
    }
    public animationType type;

    [Header("Custom")]
    public string parameter;
    public bool setBool;
    public int setInt;
    public int setFloat;


    public override void ExecuteEvent()
    {
        switch (type)
        {
            case animationType.comCall:
                GameManager.scriptActions.CommsAnimation(3);
                break;
            case animationType.commReceive:
                GameManager.scriptActions.CommsAnimation(1);
                break;
            case animationType.commTurnoff:
                GameManager.scriptActions.CommsAnimation(2);
                break;
            case animationType.setBoolean:
                GameManager.PlayerCharacter.GetComponent<Animator>().SetBool(parameter, setBool);
                break;
            case animationType.setInteger:
                GameManager.PlayerCharacter.GetComponent<Animator>().SetInteger(parameter, setInt);
                break;
            case animationType.setFloat:
                GameManager.PlayerCharacter.GetComponent<Animator>().SetFloat(parameter, setFloat);
                break;
            case animationType.playAnimation:
                GameManager.PlayerCharacter.GetComponent<Animator>().Play(parameter);
                break;

        }

        base.ExecuteEvent();
    }

}
