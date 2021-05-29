using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mito17Charger : MonoBehaviour
{
    public bool active;
    public bool broken;

    public void Activate()
    {
        broken = false;
        active = true;

    }

    public void Break()
    {
        broken = true;
        active = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Breaker") && broken == false)
        {
            Break();
        }
    }

    private void Update()
    {
        GetComponent<Animator>().SetBool("active", active);
        GetComponent<Animator>().SetBool("broken", broken);
    }

}
