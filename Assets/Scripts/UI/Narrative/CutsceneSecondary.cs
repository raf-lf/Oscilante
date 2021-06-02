using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CutsceneSecondary : Cutscene
{
    [Header ("Specific")]
    public Cutscene replacedCutscene;

    private void Start()
    {
        //Enables this cutscene only if the cutscene to be replaced is already in the cutscenes seen list

        if (SavedData.IsIdInList(2, SceneManager.GetActiveScene().buildIndex ,replacedCutscene.GetComponent<SaveableObject>().saveId))
        {
            gameObject.SetActive(true);
        }
        else gameObject.SetActive(false);
    }

}
