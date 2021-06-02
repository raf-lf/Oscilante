using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    public static Vector3 playerSpawnPosition;
    public static int currentCheckpointId;

    [Header("Starting Resources")]
    public static int startHeals = 8;
    public static int startGrenades = 2;
    public static int[] startAmmoClips = { 0, 3, 0 };

    private void Start()
    {
        GameManager.scriptSaveData = GetComponent<SaveDataManager>();

        if (SavedData.pastInitialSetup == false)
        {
            SetStartingResources();
            SavedData.pastInitialSetup = true;
        }
        else
        {
            LoadData();
        }
    }

    public static void SetCheckpoint(int id, Vector3 checkpointPosition)
    {
        playerSpawnPosition = checkpointPosition;
        currentCheckpointId = id;
        SavedData.checkpointsUsed.Add(id + SceneManager.GetActiveScene().buildIndex*1000);
        SaveData();

    }

    public static void SaveData()
    {
        SaveResources();
        SaveAllSaveableObjects();

    }

    public static void LoadData()
    {
        //Teleport player to current checkpoint
        GameManager.PlayerCharacter.transform.position = playerSpawnPosition;
        Camera.main.gameObject.transform.position = playerSpawnPosition + GameManager.scriptCamera.offset;

        GameManager.scriptWeapons.SwapWeapon(PlayerWeapons.equipedWeapon);
        LoadResources();
        LoadSaveableObjects();
    }

    public void SetStartingResources()
    {
        if (SavedData.pastInitialSetup == false)
        {
            GameManager.ItemHeal = startHeals;
            GameManager.ItemGrenade = startGrenades;

            for (int i = 0; i < startAmmoClips.Length; i++)
            {
                GameManager.AmmoClips[i] = startAmmoClips[i];
            }
            SaveResources();
        }

    }
    private static void SaveResources()
    {
        SavedData.savedHeals = GameManager.ItemHeal;
        SavedData.savedGrenades = GameManager.ItemGrenade;

        for (int i = 0; i < GameManager.AmmoClips.Length; i++)
        {
            SavedData.savedAmmoClips[i] = GameManager.AmmoClips[i];
            SavedData.savedAmmo[i] = PlayerWeapons.ammo[i];
        }
    }
    private static void LoadResources()
    {
        GameManager.ItemHeal = SavedData.savedHeals;
        GameManager.ItemGrenade = SavedData.savedGrenades;

        for (int i = 0; i < GameManager.AmmoClips.Length; i++)
        {
            GameManager.AmmoClips[i] = SavedData.savedAmmoClips[i];
            PlayerWeapons.ammo[i] = SavedData.savedAmmo[i];

        }
    }

    private static void SaveAllSaveableObjects()
    {
        SaveableObject[] allObjects = Resources.FindObjectsOfTypeAll<SaveableObject>();
        foreach(SaveableObject saveableObject in allObjects)
        {            
            if (saveableObject.saveOnNextCheckpoint)
            {
                SaveObject(saveableObject);
            }
        }

    }

    //This can also be used for cutscenes and comments, in order for players to be unable to rewatch them
    public static void SaveObject(SaveableObject saveableObject)
    {
        int idToSave = saveableObject.saveId + SceneManager.GetActiveScene().buildIndex * 1000;

        if (saveableObject.GetComponent<SupplyCrate>()) SavedData.chestsUsed.Add(idToSave);
        if (saveableObject.GetComponent<Checkpoint>()) SavedData.checkpointsUsed.Add(idToSave);
        if (saveableObject.GetComponent<CallCommentLog>()) SavedData.commentsSeen.Add(idToSave);
        if (saveableObject.GetComponent<Cutscene>()) SavedData.cutscenesSeen.Add(idToSave);
        if (saveableObject.GetComponent<Creature>()) SavedData.bossesDefeated.Add(idToSave);

        Debug.Log(saveableObject.name + " was saved with Id " + idToSave);
    }

    private static void LoadSaveableObjects()
    {
        SaveableObject[] allObjects = Resources.FindObjectsOfTypeAll<SaveableObject>();
        foreach (SaveableObject saveableObject in allObjects)
        {
            int idToLoad = saveableObject.saveId + SceneManager.GetActiveScene().buildIndex * 1000;

            if (saveableObject.GetComponent<SupplyCrate>() && SavedData.chestsUsed.Contains(idToLoad)) ConfirmLoadObject(saveableObject, idToLoad);
            if (saveableObject.GetComponent<Checkpoint>() && SavedData.checkpointsUsed.Contains(idToLoad)) ConfirmLoadObject(saveableObject, idToLoad);
            if (saveableObject.GetComponent<CallCommentLog>() && SavedData.commentsSeen.Contains(idToLoad)) ConfirmLoadObject(saveableObject, idToLoad);
            if (saveableObject.GetComponent<Cutscene>() && SavedData.cutscenesSeen.Contains(idToLoad)) ConfirmLoadObject(saveableObject, idToLoad);
            if (saveableObject.GetComponent<Creature>() && SavedData.bossesDefeated.Contains(idToLoad)) ConfirmLoadObject(saveableObject, idToLoad);
        }
    }

    private static void ConfirmLoadObject(SaveableObject saveableObject, int id)
    {
        saveableObject.LoadData();
        //Debug.Log(saveableObject.name + " with Id " + id + " was loaded");

    }


}
