using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSnowball : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject impactEffect;

    void Start()
    {
        Destroy(gameObject, 2.80f);
    }



    // Start is called before the first frame update
   void Update()
    {
        rb.velocity = transform.right * speed * Time.deltaTime * 75;
    }

    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Enemy"))
        {
            HitObject();
        }

        if(hitInfo.CompareTag("PowerupHealth"))
        {
            GameManager.Wall.IncreaseHP();
            HitObject();
        }

        if(hitInfo.CompareTag("Powerup3x"))
        {
            GameManager.shooting.RapidFireShooting();
            HitObject();
        }
        
    }


    public void HitObject()
    {
        Destroy(gameObject);
        Instantiate(impactEffect, transform.position, transform.rotation);
    }
}
        
