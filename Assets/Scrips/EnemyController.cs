using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed;

    Rigidbody2D rb2d;
    Animator animator;
    Vector3 basecale;

    public GameObject enemy;
    bool faceRight = true;
    float faceTime = 5f;
    float nextFlip = 0f;
    bool canFlip = true;


    void Awake()
    {
        rb2d= GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        if(Time.time > nextFlip)
        {
            nextFlip= Time.time + faceTime;
            Flip();
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(faceRight && collision.transform.position.x < transform.position.x)
            {
                Flip();
            }
            else if(!faceRight && collision.transform.position.x > transform.position.x)
            {
                Flip();
            }
            canFlip= false;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!faceRight)
            {
                rb2d.AddForce(new Vector2(-1, 0) * enemySpeed);
            }
            else
            {
                rb2d.AddForce(new Vector2(1, 0) * enemySpeed);
               
            }
            animator.SetBool("New Bool", true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canFlip= true;
            rb2d.velocity = new Vector2(0, 0);
            animator.SetBool("New Bool", false);
           
        }


    }

    void Flip()
    {
        if(!canFlip) { return; }
        faceRight = ! faceRight;
        basecale = enemy.transform.localScale;
        basecale.x *= -1f;
        enemy.transform.localScale = basecale;
        
    }

    
}
