using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public GameObject Boom;
    public Transform shootFrom;
    public float shootTime;

    float nextShoot;
   // Animator animator;

    private void Awake()
    {
        //animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag=="Player" && Time.time > nextShoot)
        {
            nextShoot = Time.time+shootTime;
            Instantiate(Boom,shootFrom.position,Quaternion.identity) ;
           // animator.SetTrigger("enemyAttack");
        } 
    }
}
