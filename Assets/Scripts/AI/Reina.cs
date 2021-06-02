using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reina : MonoBehaviour
{
    public GameObject deathVfx;
    
    public void DeathVFx()
    {
        Instantiate(deathVfx,transform);
    }
}
