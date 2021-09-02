using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : MonoBehaviour
{   

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PolygonCollider2D boxCol;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Animator animator;

    [SerializeField] private float moveSpeed;

    private float timer = 0;
    private bool isMoving;

    private enum state {running, shooting, dead}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //time
        timer += Time.deltaTime;
        Movement();
        StateMachine();

    }

    public void Movement()
    {   
        float y =  Input.GetAxisRaw("Vertical");
        float moveBy = y*moveSpeed;
        rb.velocity = new Vector2 (0, moveBy);
    }

     public void StateMachine()
    {
        if((Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.1f))
        {
            animator.SetBool("Moving", true);
        }
        else animator.SetBool("Moving", false);
    }

   

}
