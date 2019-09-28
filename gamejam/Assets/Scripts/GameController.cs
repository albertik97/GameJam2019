﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{

    public int numObjects = 5;

    public GameObject   player1,
                        player2,
                        trap;
    public GameObject[] traps;

    public GameObject p1Instance,
                      p2Instance;





    void Awake()
    {
        traps = new GameObject[numObjects];
        initMap();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initMap()
    {
        createPlayers();
        createObjects();

    }

    void createPlayers()
    {
        p1Instance = Instantiate(player1);
        p2Instance = Instantiate(player2);

        p1Instance.transform.position = getRandomPosPlayer();

        do
        {
            p2Instance.transform.position = getRandomPosPlayer();
        } while(p1Instance.transform.position == p2Instance.transform.position);
    }

    Vector3 getRandomPosPlayer()
    {
        return new Vector3(Random.value < 0.5f ? -19 : 19, Random.value < 0.5f ? -21 : 17, 0);
    }

    Vector3 getRandomPos()
    {
        float step = 3.8f,
            randomPosX = Random.Range(-19, 19),
            randomPosY = Random.Range(-17.2f, 13.2f);

        float numStepsX = Mathf.Floor(randomPosX / step),
              numStepsY = Mathf.Floor(randomPosY / step);

        return new Vector3(numStepsX * step, (numStepsY * step) - 2, 0);
    }

    void createObjects()
    {
        for (int i = 0; i < traps.Length; i++)
        {
            
            traps[i] = Instantiate(trap);
            do
            {
                traps[i].transform.position = getRandomPos();
            } while (traps[i].transform.position == new Vector3(0, -2, 0));
           
        }
    }
}
