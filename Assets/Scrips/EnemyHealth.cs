using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    public Slider HP;

    void Start()
    {
        currentHealth = maxHealth;
        HP.maxValue= maxHealth;
        HP.value= maxHealth;
    }

    
    void Update()
    {
        
    }
    public void Damage(float damage)
    {
        currentHealth -= damage;
        HP.value = currentHealth;
        if(currentHealth <= 0 ) 
        {
            Dead();
            gameObject.SetActive(false);
        }
    }
    void Dead()
    {
        Destroy(gameObject,10);
    }
}
