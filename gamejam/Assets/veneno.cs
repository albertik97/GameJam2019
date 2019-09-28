using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class veneno : MonoBehaviour
{
    public GameObject venenos;
    public GameObject queso;
    public GameObject agujero;
    public float step;
    // Start is called before the first frame update
    void Start()
    {
        int Npotions = Random.Range(1, 3);
        Instantiate(queso, new Vector3(0, 0.1f, 0), Quaternion.identity);
        for (int i = 0; i < Npotions; i++)
        {
            int ran = Random.Range(-5, 6);
            int ran2 = Random.Range(-5, 6);
            if (ran != 0 && ran2 != 0)
                Instantiate(venenos, new Vector3(step * ran, step*ran2, 0), Quaternion.identity);
        }

        int Npotions2 = Random.Range(1, 3);
        for (int i = 0; i < Npotions2; i++)
        {
            int ran = Random.Range(-5, 6);
            int ran2 = Random.Range(-5, 6);
            if(ran!=0 && ran2!=0)
                Instantiate(agujero, new Vector3(step * ran, step * ran2, 0), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
