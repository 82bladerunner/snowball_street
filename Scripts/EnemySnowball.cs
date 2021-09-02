using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnowball : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject impactEffect;

    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Wall") || hitInfo.CompareTag("Projectile"))
        {
        Destroy(gameObject);
        Instantiate(impactEffect, transform.position, transform.rotation);
        }
    }
}