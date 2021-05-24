using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_ContinueDialogue : CutsceneEvent
{
    public Event_ContinueDialogue thisEvent;

    public override void ExecuteEvent()
    {

        int level = GameManager.scriptDialogue.currentLevel;
        int chat = GameManager.scriptDialogue.currentChat;
        int section = GameManager.scriptDialogue.currentSection;

        if (thisEvent == null) GameManager.scriptDialogue.eventCaller = GetComponent<Event_ContinueDialogue>();
        else GameManager.scriptDialogue.eventCaller = thisEvent;

        GameManager.scriptDialogue.SetupWrite(level, chat, section +1, 1);


    }
    
}
