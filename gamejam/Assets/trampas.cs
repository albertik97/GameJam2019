﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("Veneno"))
        {
            
            if (GetComponentInParent<PlayerMovement>().playerId == 1) {
                GetComponentInParent<PlayerMovement>().gameObject.transform.position = FindObjectOfType<GameController>().pos1;
                GetComponentInParent<PlayerMovement>().pos = FindObjectOfType<GameController>().pos1;
            }

            if (GetComponentInParent<PlayerMovement>().playerId == 2)
            {
                GetComponentInParent<PlayerMovement>().gameObject.transform.position = FindObjectOfType<GameController>().pos2;
                GetComponentInParent<PlayerMovement>().pos = FindObjectOfType<GameController>().pos2;
            }

        }
    }
}
