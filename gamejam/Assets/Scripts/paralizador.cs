using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralizador : MonoBehaviour
{

    public float freezeTime = 2.0f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (gameObject.GetComponentInParent<PlayerMovement>().freezed)
            freezeTime -= Time.deltaTime;
        if(freezeTime < 0)
        {
            freezeTime = 20.0f;
            gameObject.GetComponentInParent<PlayerMovement>().freezed = false;
            //Debug.Log("ya me puedo mover");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "trampa")
        {
            //Debug.Log("Congelado");
            gameObject.GetComponentInParent<PlayerMovement>().freezed = true;
            
        }
    }
}
