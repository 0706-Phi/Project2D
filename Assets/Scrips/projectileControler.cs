using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileControler : MonoBehaviour
{
    public float BulletSpeed;
    public float bulletTime;
    Rigidbody2D rb2;

    private void Awake()
    {
        rb2= GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0) 
        {
            rb2.AddForce(new Vector2(-1, 0) * BulletSpeed, ForceMode2D.Impulse);
        }
        else if(transform.localRotation.z <= 0)
        {
            rb2.AddForce(new Vector2(1, 0) * BulletSpeed, ForceMode2D.Impulse);
        }
        
    }
    void Start()
    {
        Destroy(gameObject, bulletTime);
    }

    void Update()
    {
        
    }
    public void removeForce()
    {
        rb2.velocity = new Vector2(0, 0);
    }
}
