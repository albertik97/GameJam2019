using System.Collections;
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
            transform.position = new Vector3(19.0f, 19.0f, 0.0f);

        }
    }
}
