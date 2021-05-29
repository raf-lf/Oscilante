using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mito17Main : Creature
{
    public Mito17Charger[] shieldChargers = new Mito17Charger[4];
    public int phase;

    [Header("Phase 1")]
    public Mito17Arm[] gunArms = new Mito17Arm[2];
    public float[] gunUseInterval = { 8, 4, 2 };

    [Header("Phase 2")]
    public float[] mineInterval = { 0, 30, 15 };
    public float[] missileInterval = { 0, 10, 5 };

    [Header("Phase 3")]
    public GameObject wallToBreak;
    public GameObject[] gasLeaks; 

}
