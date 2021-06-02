using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public abstract class TextBoxParent : MonoBehaviour
{
    public bool textActive;

    [Header("Typewritter")]
    public float characterIntervalTime;
    public AudioClip characterSFX;
    protected string textToWrite;
    protected bool canEnd;

    [Header("Text Boxes")]
    public Animator textBoxAnimator;
    public Text textBoxText;
    public Image textBoxPortrait;
    public Text textBoxName;

    private void SetPortrait()
    {
        if (textBoxPortrait != null) textBoxPortrait.sprite = LibraryDialogue.characterPortrait[LibraryDialogue.currentPortraitId];
        if (textBoxName != null) textBoxName.text = PortraitName(LibraryDialogue.currentPortraitId);
    }

    private string PortraitName(int portraitId)
    {
        switch (portraitId)
        {
            case 0: return "Quilla";
            case 1: return "Operador";
            case 2: return "Reina";
            case 3: return "Narus";
            case 4: return "Ermitão";
            case 5: return "Dra.P";
            case 6: return "???";
            default: return "???";
        }
    }

    public virtual void Interrupt()
    {
        StopAllCoroutines();
        CloseTextBox();
    }

    public virtual void Write (string text)
    {
        SetPortrait();

        textActive = true;
        if(textBoxAnimator.GetBool("active") == false) textBoxAnimator.SetBool("active", true);

        textToWrite = text;

        StopAllCoroutines();
        StartCoroutine(WriteCharacter());

    }

    public IEnumerator WriteCharacter()
    {
        if (textToWrite != null)
        {
            for (int i = 0; i <= textToWrite.Length; i++)
            {
                yield return new WaitForSeconds(characterIntervalTime);

                textBoxText.text = textToWrite.Substring(0, i);

                PlayCharacterSFX();

                if (i == textToWrite.Length) FinishedTypeWriting();

            }
        }

    }

    public virtual void FinishedTypeWriting()
    {
        canEnd = true;


    }

    public void CloseTextBox()
    {
        textBoxAnimator.SetBool("active", false);
        textActive = false;

    }

    public void PlayCharacterSFX()
    {

    }


}
