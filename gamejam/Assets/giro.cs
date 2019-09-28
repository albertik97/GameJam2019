using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giro : MonoBehaviour
{
    private bool gira;

    // Start is called before the first frame update
    void Start()
    {
        gira = false;
    }

// Update is called once per frame
void Update()
{
        //Debug.Log(transform.rotation.z);
        
    if (transform.rotation.z > 0.1f)
        gira = true;

        if (transform.rotation.z > 0.1f)
            gira = true;

        if (transform.rotation.z < -0.1f)
            gira = false;

        if (gira)
            transform.Rotate(new Vector3(0, 0, -50) * Time.deltaTime);
        else
            transform.Rotate(new Vector3(0, 0, 50) * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
