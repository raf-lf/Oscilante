using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTimed : Switch
{
    [Header("Timer")]
    public TextMesh sTimer;
    public TextMesh msTimer;
    public int seconds;
    private int timeFrames;


    public override void Interact()
    {
        base.Interact();

        timeFrames = seconds * 60;

    }

    private void UpdateTimer()
    {
        int additionalTime;
        if (timeFrames/60 >= 0 && timeFrames % 60 > 0) additionalTime = 1;
        else additionalTime = 0;

        sTimer.text = ((timeFrames / 60) + additionalTime).ToString();
        //sTimer.text = FormatValue(timeFrames / 60);
        msTimer.text = FormatValue(timeFrames % 60);

    }

    private string FormatValue(int value)
    {
        if (value < 9) return "0" + value;
        return value.ToString();
    }

    private void FixedUpdate()
    {
        if (timeFrames > 0) timeFrames--;

        if (timeFrames > 0) isActive = true;
        else isActive = false;

        GetComponent<Animator>().SetBool("active", isActive);

        UpdateTimer();
        
    }

}
