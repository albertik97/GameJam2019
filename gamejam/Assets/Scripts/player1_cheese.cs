﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1_cheese : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "queso")
        {
            Debug.Log("Player 1 Wins");
            GameController c = GameObject.FindObjectOfType(typeof(GameController)) as GameController;
            c.addPlayer1Score();
            c.NextRound();
        }
    }
}
