using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    public float bomSpeesdHight;
    public float bomSpeesdLow;
    public float bomAngle;

    Rigidbody2D rb2d;
    public AudioSource audioBoom;

    private void Awake()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb2d.AddForce(new Vector2(Random.Range(-bomAngle, bomAngle), Random.Range(bomSpeesdLow, bomSpeesdHight)), ForceMode2D.Impulse);
        audioBoom.Play();
    }

  
}
