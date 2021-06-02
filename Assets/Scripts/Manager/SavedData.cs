using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SavedData
{
    [Header("Saved Resources")]
    public static bool pastInitialSetup;
    public static int savedHeals;
    public static int savedGrenades;
    public static int[] savedAmmoClips = { 0, 0, 0 };
    public static int[] savedAmmo = { 0, 0, 0 };

    [Header("Saved Lists")]
    
    public static List<int> chestsUsed = new List<int>();
    public static List<int> checkpointsUsed = new List<int>();
    public static List<int> cutscenesSeen = new List<int>();
    public static List<int> commentsSeen = new List<int>();
    public static List<int> bossesDefeated = new List<int>();

    public static void ClearSavedLists()
    {
        chestsUsed.Clear();
        checkpointsUsed.Clear();
        cutscenesSeen.Clear();
        commentsSeen.Clear();
        bossesDefeated.Clear();

    }

    public static bool IsIdInList(int listNumber, int sceneId, int saveId)
    {
        sceneId *= 1000;

        switch(listNumber)
        {
            case 0:
                if (chestsUsed.Contains(saveId + sceneId)) return true;
                else return false;
            case 1:
                if (checkpointsUsed.Contains(saveId + sceneId)) return true;
                else return false;
            case 2:
                if (cutscenesSeen.Contains(saveId + sceneId)) return true;
                else return false;
            case 3:
                if (commentsSeen.Contains(saveId + sceneId)) return true;
                else return false;
            case 4:
                if (bossesDefeated.Contains(saveId + sceneId)) return true;
                else return false;

            default: return false;
        }

    }
}
