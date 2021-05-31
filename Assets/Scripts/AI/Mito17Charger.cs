using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mito17Charger : MonoBehaviour
{
    public GameObject breakVfx;
    public Animator connectedCord;
    public bool isActive;
    public int state;

    public void Activate()
    {
        state = 1;

    }

    public void FinishedActivating()
    {
        isActive = true;

    }

    public void Break()
    {
        isActive = false;
        state = 0;
        GameObject blast = Instantiate(breakVfx);
        blast.transform.position = transform.position + new Vector3(0,0.4f,0);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Breaker"))
        {
            Break();
        }
    }

    private void Update()
    {
        GetComponent<Animator>().SetInteger("state", state);

        connectedCord.SetBool("active", isActive);
    }

}
