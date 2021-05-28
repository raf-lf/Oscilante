using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveableObject : MonoBehaviour
{
    [Header("Save Data")]
    public int saveId;
    public bool instantSave;
    public bool saveOnNextCheckpoint;

    public void SaveData()
    {
        if (instantSave) SaveDataManager.SaveObject(GetComponent<SaveableObject>());
        else
        {
            Debug.Log(gameObject.name + " marked for Load.");
            saveOnNextCheckpoint = true;
        }

    }

    public virtual void LoadData()
    {
        if (GetComponent<SupplyCrate>())
        {
            GetComponent<Animator>().SetBool("open", true);
            GetComponent<SupplyCrate>().unusable = true;
        }

        if (GetComponent<Checkpoint>())
        {
            gameObject.SetActive(false);
        }

        if (GetComponent<CallCommentLog>())
        {
            GetComponent<CallCommentLog>().off = true;
        }
        if (GetComponent<Cutscene>())
        {
            GetComponent<Cutscene>().off = true;
        }

    }
}
