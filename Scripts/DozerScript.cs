using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DozerScript : MonoBehaviour
{
    #region 
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCol;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed;
    [SerializeField] private int maxHealth;
    [SerializeField] private GameObject[] powerups;
    [SerializeField] private float distanceThreshold;
    [SerializeField] private float drawbackTime;
    [SerializeField] private float touchDistance;

    private GameObject Wall;
    private float distWithWall;
    private int currentHealth;
    private float timer;
    private Material matWhite;
    private Material matDefault;  
    private UnityEngine.Object explosionRef;

    Coroutine rammingCoroutine = null;
    #endregion

        void Awake()
    {
        animator.SetInteger("state", 0);
        Wall = GameObject.FindGameObjectWithTag("Wall");
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = spriteRenderer.material;

        currentHealth = maxHealth;

        explosionRef = Resources.Load("ExplosionEffect");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(GameManager.WallFound != null)
        {
            distWithWall = Vector3.Distance(Wall.transform.position, rb.transform.position);
        }      
        

        if(distWithWall > distanceThreshold && timer > 1)
        {
            rb.velocity = new Vector2(speed,0);
            animator.SetInteger("state", 0);
        }

        if(distWithWall <= distanceThreshold && rammingCoroutine == null && timer > 1)
        {
            //StartCoroutine(Waiting());
            animator.SetInteger("state", 1);
            rb.velocity = new Vector2(speed*1.3f,0);
        }    

        if(distWithWall <= touchDistance && timer > 1)
        {
            rammingCoroutine = StartCoroutine(Drawback());
        }

    }

    public IEnumerator Drawback()
    {
        animator.SetInteger("state", 0);
        rb.velocity = new Vector2(-speed,0);
        GameManager.Wall.DozerDamage();
        yield return new WaitForSeconds(drawbackTime);
        rammingCoroutine = null;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Projectile"))
        {
            currentHealth--;
            StartCoroutine(FlashEffect());
            if(currentHealth <= 0)
            {
               // DropPowerup();
                KillSelf();
            }
        }
    }

    public IEnumerator FlashEffect()
    {
        spriteRenderer.material = matWhite;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.material = matDefault;
    }

    public void KillSelf()
    {
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Destroy(gameObject);
    }

     public void DropPowerup()
        {   
            int randomPowerup = Random.Range(0, powerups.Length);
            Instantiate(powerups[randomPowerup], transform.position, transform.rotation);
        }
    
}
