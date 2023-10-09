using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Tilemaps;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float Speed;
    public float JumpPower;

    Vector3 baseScale;
    Rigidbody2D rb2d;
    Animator animator;

    bool FaceRight;
    bool GroundCheck;

    public Transform Gun;
    public GameObject bullet;
    float firerate = 0.5f;
    float nextfire = 0;

    public AudioSource audioFire;
    public AudioSource audioJump;
    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        FaceRight = true;
    }

    
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        

        animator.SetFloat("speed", Mathf.Abs(move));

        rb2d.velocity = new Vector2(move * Speed, rb2d.velocity.y);

        if(move > 0 && !FaceRight)
        {
            Flip();
        }
        else if(move < 0 && FaceRight) 
        {
            Flip();
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if(GroundCheck)
            {
                GroundCheck= false;
                rb2d.velocity = new Vector2(rb2d.velocity.x, JumpPower);
                audioJump.Play();
            }
        }


        if (Input.GetAxisRaw("Fire1") > 0)
        {
            fireBullet();
            audioFire.Play();
        }
    }

    void Flip()
    {
        FaceRight = !FaceRight;
        baseScale = transform.localScale;
        baseScale.x *= -1;
        transform.localScale = baseScale;
    }
     void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            GroundCheck= true;
        }
    }

    void fireBullet()
    {
        if(Time.time> nextfire)
        {
            nextfire= Time.time + firerate;
            if (FaceRight)
            {
                Instantiate(bullet,Gun.position, Quaternion.Euler(new Vector3(0,0,0)));
            }
            else if(!FaceRight)
            {
                Instantiate(bullet, Gun.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }

    void AniDie()
    {
        animator.SetTrigger("Die");
    }
}
