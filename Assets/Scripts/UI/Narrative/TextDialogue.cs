using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextDialogue: TextBoxParent
{
    private bool dialogueOn;
    private bool canSkip;
    private bool onLastLine;

    public int currentLevel;
    public int currentChat;
    public int currentSection;
    public int currentLine;

    public CutsceneEvent eventCaller;

    private void Start()
    {
        GameManager.scriptDialogue = GetComponent<TextDialogue>();

    }

    public void SetupWrite(int level, int chat, int section, int line)
    {
        dialogueOn = true;

        currentLevel = level;
        currentChat = chat;
        currentSection = section;
        currentLine = line;

        canSkip = true;
        Write(LibraryDialogue.RetrieveDialogue(level, chat, section, line));

        if (LibraryDialogue.RetrieveDialogue(level, chat, section, line + 1) == null) onLastLine = true;
        else onLastLine = false;

    }

    public override void FinishedTypeWriting()
    {
        base.FinishedTypeWriting();
        canSkip = false;
    }

    private void Update()
    {
        if (dialogueOn == true)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                if (canSkip)
                {
                    StopAllCoroutines();
                    textBoxText.text = textToWrite;
                    FinishedTypeWriting();
                }
                else if (canEnd == true)
                {
                    if (onLastLine)
                    {
                        CloseTextBox();
                        dialogueOn = false;

                        if (GameManager.CutscenePlaying)
                        {
                            eventCaller.ContinueEvent();
                        }
                        else GameManager.Cutscene(false);
                    }
                    else SetupWrite(currentLevel, currentChat, currentSection, currentLine + 1);

                }
            }
        }
        
    }

}
