using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform bulletPoint;
    [SerializeField] private GameObject Snowball;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer; 
    [SerializeField] public float fireRate;
    [SerializeField] public float burstFirerate;
    private float timeUntilNextShot;
    private float rapidFireTime;
    private float tripleShotDelay = 0.3f;
    public bool RapidFire = false;

    Color lerpedColor;
    Color defaultColor;
    void Start()
    {
        burstFirerate = fireRate + 0.3f;
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {   

         lerpedColor = Color.Lerp(defaultColor, Color.blue, Mathf.PingPong(Time.time, 0.3f));

        if(RapidFire)
        {

            spriteRenderer.color = lerpedColor;

            if(burstFirerate < Time.time && Input.GetButtonDown("Fire1") && (rapidFireTime < Time.time))
            {    
                    StartCoroutine(RapidFireShot());
                    rapidFireTime = Time.time + burstFirerate;   
            }
            StartCoroutine(RapidFireOff());
        }
        else if(Input.GetButtonDown("Fire1") && (timeUntilNextShot < Time.time))
        {   
            animator.SetTrigger("Shoot");
            Shoot();
            timeUntilNextShot = Time.time + fireRate;
        }
    }

    public void Shoot()
    {
        Instantiate(Snowball, bulletPoint.position, bulletPoint.rotation);
    }

    public void RapidFireShooting()
    {
        RapidFire = true;
    }

    public IEnumerator RapidFireOff()
    {
        yield return new WaitForSeconds(5);
        RapidFire = false;
        spriteRenderer.color = defaultColor;
    }

    public IEnumerator RapidFireShot()
    {   
        Shoot();
        yield return new WaitForSeconds(tripleShotDelay);
        Shoot();
        yield return new WaitForSeconds(tripleShotDelay);
        Shoot();
    }
}
