using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform bulletRight;
    [SerializeField] private GameObject Snowball;
    private float fireRate = 0.7f;
    [SerializeField] private Animator animator;
    private float timeUntilNextShot = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("Shoot") && (timeUntilNextShot < Time.time))
        {
            Shoot();
            timeUntilNextShot = Time.time + fireRate;
        }
    }

    public void Shoot()
    {   
                Instantiate(Snowball, bulletRight.position, bulletRight.rotation);     
    }
}
