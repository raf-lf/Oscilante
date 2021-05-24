using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextLog: TextBoxParent
{
    public float additionDelayTime = 2;
    private float endTimer;

    private void Start()
    {
        GameManager.scriptLog = GetComponent<TextLog>();

    }
    public override void Write(string text)
    {
        textBoxAnimator.SetBool("active", true);
        textBoxText.text = text;

        textActive = true;
        endTimer = Time.time + additionDelayTime;
        canEnd = true;

    }

    private void Update()
    {
        if (Time.time > endTimer && canEnd && textActive)
        {
            canEnd = false; 
            CloseTextBox();
        }
        
    }

}
