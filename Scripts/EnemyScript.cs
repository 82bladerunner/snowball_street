using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update

    #region 
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCol;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed;
    [SerializeField] private float distanceThreshold;
    [SerializeField] private int maxHealth;
    [SerializeField] private GameObject[] powerups;


    private bool Dead;
    private GameObject Wall;
    private float distWithPlayer;
    private float varianceConstant;
    private float varianceConstant2;
    private Material matWhite;
    private Material matDefault;    
    private int currentHealth;
    private UnityEngine.Object explosionRef;


    #endregion

    

    void Start()
    {
       animator.SetInteger("state", 0);
       varianceConstant = Random.Range(0.7f, 1.2f);
       varianceConstant2 = Random.Range(0.8f, 1.1f);
       Wall = GameObject.FindGameObjectWithTag("Wall");

       currentHealth = maxHealth;

       matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
       matDefault = spriteRenderer.material;

       explosionRef = Resources.Load("ExplosionEffect");
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine();

        if(GameManager.WallFound != null)
        {
            distWithPlayer = Vector3.Distance(Wall.transform.position, rb.transform.position);
        }
    }

    private void StateMachine()
    {
        if(distWithPlayer < distanceThreshold*varianceConstant)  //Shoot state
        {
            animator.SetTrigger("Shoot"); 
            rb.velocity = new Vector2 (0,0);          
        }
        else if(animator.GetInteger("state") == 0) //Run state
        {
            rb.velocity = new Vector2 (speed*varianceConstant2, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Projectile"))
        {
            currentHealth--;    
            StartCoroutine(FlashEffect());

            if(currentHealth <= 0)
            {    
                DropPowerup();
                KillSelf();
            }
        }
    }

    public void KillSelf()
    {
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Destroy(gameObject);
    }

    public void DropPowerup()
    {   
        int dropChance = Random.Range(0,100);
        if(dropChance <= 10)
        {
            int randomPowerup = Random.Range(0, powerups.Length);
            Instantiate(powerups[randomPowerup], transform.position, transform.rotation);
        }
    }

    public IEnumerator FlashEffect()
    {
        spriteRenderer.material = matWhite;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.material = matDefault;
    }

}
