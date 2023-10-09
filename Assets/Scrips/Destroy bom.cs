using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroybom : MonoBehaviour
{
    public float AliveBom;
    void Start()
    {
        Destroy(gameObject, AliveBom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
