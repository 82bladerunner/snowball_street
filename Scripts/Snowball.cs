using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject impactEffect;


    // Start is called before the first frame update
    void Start()
    {
        
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Player") || hitInfo.CompareTag("Enemy"))
        {
        Destroy(gameObject);
        Instantiate(impactEffect, transform.position, transform.rotation);
        }
    }
}
        
