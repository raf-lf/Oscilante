using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTagInArea : MonoBehaviour
{
    public string objectTag;
    public bool active;

    /*
     * private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(objectTag)) active = true;
        else active = false;
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(objectTag)) active = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(objectTag)) active = false;

    }
}
