using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_PlayerSwapWeapon : CutsceneEvent
{
    public enum swap
    {
        equip, unequip
    }
    public swap swapType;

    public int weaponId;

    public override void ExecuteEvent()
    {
        switch (swapType)
        {
            case swap.equip:
                GameManager.scriptWeapons.SwapWeapon(weaponId);
                break;
            case swap.unequip:
                GameManager.scriptWeapons.SwapWeapon(PlayerWeapons.equipedWeapon);
                break;

        }       

        base.ExecuteEvent();

    }

}
