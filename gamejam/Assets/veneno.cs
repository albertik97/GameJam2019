using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class veneno : MonoBehaviour
{
    public GameObject venenos;
    public GameObject queso;
    private float step = 3.8f;
    // Start is called before the first frame update
    void Start()
    {
        int Npotions = Random.Range(1, 3);
        Instantiate(queso, new Vector3(0, 0.1f, 0), Quaternion.identity);
        for (int i = 0; i < Npotions; i++)
        {
            int ran = Random.Range(-5, 6);
            int ran2 = Random.Range(-5, 6);
            Instantiate(venenos, new Vector3(step * ran, step*ran2, 0), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
