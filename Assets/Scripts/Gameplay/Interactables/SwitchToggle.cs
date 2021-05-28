using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToggle : Switch
{
    public override void Interact()
    {
        base.Interact();

        isActive = !isActive;

    }

    protected override void Update()
    {
        base.Update();
        GetComponent<Animator>().SetBool("active", isActive);

    }


}
