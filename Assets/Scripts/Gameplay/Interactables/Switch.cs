using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactible
{
    [Header("Switch")]
    public bool isActive;

    public override void Interact()
    {
        base.Interact();

    }

    protected override void Update()
    {
        base.Update();

        GetComponent<Animator>().SetBool("unusable", unusable);
    }

}
