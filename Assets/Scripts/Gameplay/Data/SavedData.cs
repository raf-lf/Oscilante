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

}
