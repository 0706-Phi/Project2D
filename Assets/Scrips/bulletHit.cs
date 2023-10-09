using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour
{
    projectileControler projectileControler;

    public float bulletDamage;

    private void Awake()
    {
        projectileControler= GetComponent<projectileControler>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shootable")
        {
            projectileControler.removeForce();
            Destroy(gameObject);
            if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
               EnemyHealth hurtEnemy = collision.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.Damage(bulletDamage);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shootable")
        {
            projectileControler.removeForce();
            Destroy(gameObject);
            if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                EnemyHealth hurtEnemy = collision.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.Damage(bulletDamage);
            }
        }

    }
}
