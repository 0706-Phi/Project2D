using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    float currenthealth;

    public Slider Hp;

    public GameOver gameOver;

    void Start()
    {
        currenthealth = maxHealth;
        Hp.maxValue= maxHealth;
        Hp.value = maxHealth;
    }

    public void AddDamage(float damage)
    {
        if(damage <= 0) return;
        currenthealth -= damage;
        Hp.value = currenthealth;

        if(currenthealth <= 0)
        {
            
            Dead();
            gameOver.Over();
        }
    }

    void Dead()
    {
        Destroy(gameObject,1);
      
    }
}
