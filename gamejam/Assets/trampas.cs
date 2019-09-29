using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampas : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool caida1,caida2;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        caida1 = false;
        caida2 = false;
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
                    animator.Play("Caida");
                    StartCoroutine(Example());
                    caida1 = true;
      
            }

                if (GetComponentInParent<PlayerMovement>().playerId == 2)
                {
                    animator.Play("caida2");
                    StartCoroutine(Example());
                    caida2 = true;
                }
        }
    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(0.5f);
        print(Time.time);
        if (caida1)
        {
            StartCoroutine(Example());
            GetComponentInParent<PlayerMovement>().gameObject.transform.position = FindObjectOfType<GameController>().pos1;
            GetComponentInParent<PlayerMovement>().pos = FindObjectOfType<GameController>().pos1;
            caida1 = false;
        }

        if (caida2)
            {
                GetComponentInParent<PlayerMovement>().gameObject.transform.position = FindObjectOfType<GameController>().pos2;
                GetComponentInParent<PlayerMovement>().pos = FindObjectOfType<GameController>().pos2;
                caida2 = false;
         }
    }
}
