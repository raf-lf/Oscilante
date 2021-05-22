using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchEscavationPit : SwitchToggle
{
    public Turret turret;
    public Animator[] animatorsToAffect;
    public Cutscene cutscene;

    public override void Interact()
    {
        base.Interact();

        turret.animator.SetBool("inactive", !isActive);

        for(int i = 0; i < animatorsToAffect.Length; i++) animatorsToAffect[i].SetBool("active", isActive);

        if (isActive)
        {
            turret.attackCooldownFrames = turret.attackCooldown;
            turret.audioOn.playSFX();
        }
        else turret.audioOff.playSFX();

        if (cutscene.off == false) cutscene.CutsceneStartEnd(true);

    }

}
