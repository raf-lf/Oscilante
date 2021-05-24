using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public int knockback;
    public float speed;

    public GameObject impactEffect;

    public float autoDestroyTimer;
    private float autoDestroyTargetTime;


    [HideInInspector]
    public float rotationZ;
    [HideInInspector]
    public Vector2 direction;

    private AudioSource audioSource;


    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        GetComponent<Rigidbody2D>().velocity = direction * speed;

        if (autoDestroyTimer != 0) autoDestroyTargetTime = Time.time + autoDestroyTimer;


        if (GetComponent<AudioSource>())
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.transform.parent = null;
            Destroy(audioSource, 10);
        }
    }

    private void Impact()
    {
        GetComponent<Animator>().SetInteger("state", 1);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

        if (impactEffect != null)
        {
            GameObject impact =  Instantiate(impactEffect);
            impact.transform.position = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponentInParent<Player>())
        {
            Impact();
            collision.gameObject.GetComponentInParent<Player>().Damage(damage, knockback, transform);

        }
        else if (collision.gameObject.GetComponentInParent<Creature>())
        {
            Impact();
            collision.gameObject.GetComponentInParent<Creature>().Damage(damage, knockback, transform);

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Impact();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (Time.time >= autoDestroyTargetTime && autoDestroyTimer != 0) GetComponent<Animator>().SetInteger("state", 2);
    }
}
