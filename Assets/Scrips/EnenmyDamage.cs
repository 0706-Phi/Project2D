using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyDamage : MonoBehaviour
{
    public float damage;
    public float pushForce;

    float damageRate=0.5f;
    float nextDamage;



    Rigidbody2D rb2;
    void Start()
    {
        nextDamage = 0f; 
    }

    
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && nextDamage < Time.time)
        {
            PlayerHealth  playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.AddDamage(damage);
            nextDamage =damageRate + Time.time;
            pushBack(collision.transform);
        }
    }
    void pushBack(Transform pushObject)
    {
        Vector2 push = new Vector2(0, (pushObject.position.y - transform.position.y)).normalized;
        push *= pushForce;
        rb2 =pushObject.gameObject.GetComponent<Rigidbody2D>();
        rb2.velocity = Vector2.zero;
        rb2.AddForce(push, ForceMode2D.Impulse);
    }
}
