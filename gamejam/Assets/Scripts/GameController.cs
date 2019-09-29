﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public int numObjects = 5;

    public GameObject   player1,
                        player2,
                        trap,
                        cheese;

    public KeyCode[]    p1Controls,
                        p2Controls;

    public GameObject[] traps;

    public GameObject p1Instance,
                      p2Instance,
                      cheeseInstance;

    public int  pl1_score,
                pl2_score,
                round;

    public static int pl_winner;
    public Vector3 pos1, pos2;
    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            traps = new GameObject[numObjects];
            setControls();
            round = 0;
            pl1_score = 0;
            pl2_score = 0;
            pl_winner = 0;
            initMap();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addPlayer1Score()
    {
        pl1_score += 1;
        GameObject scr = GameObject.FindWithTag("pl1_score");
        TextMeshProUGUI asd = scr.GetComponent<TextMeshProUGUI>();
        asd.text = pl1_score.ToString();
        Debug.Log(pl1_score);
    }

    public void addPlayer2Score()
    {
        pl2_score += 1;
        GameObject scr = GameObject.FindWithTag("pl2_score");
        TextMeshProUGUI asd = scr.GetComponent<TextMeshProUGUI>();
        asd.text = pl2_score.ToString();
    }

    public void setControls()
    {
        p1Controls = GameImputManager.keyMovsP1;
        p2Controls = GameImputManager.keyMovsP2;

        Transform[] controls1 = GameObject.FindGameObjectWithTag("Controls1").GetComponentsInChildren<Transform>();
        Transform[] controls2 = GameObject.FindGameObjectWithTag("Controls2").GetComponentsInChildren<Transform>();



        //for(int i = 1; i < controls1.Length; i++)
        //{
        //    Debug.Log(controls1[i].gameObject.name);
        //    if (controls1[i].gameObject.GetComponent<TextMeshProUGUI>().text == "W")
        //        controls1[i].gameObject.GetComponent<TextMeshProUGUI>().text = "asdasd";
        //}
        foreach (Transform item in controls1)
        {
            if (item.gameObject.GetInstanceID() != GetInstanceID())
            {
                if (item.name == "ControlUp")
                    item.gameObject.GetComponent<TextMeshProUGUI>().text = GameImputManager.keyMapping[KeyCode.W].ToString();
                if (item.name == "ControlDown")
                    item.gameObject.GetComponent<TextMeshProUGUI>().text = GameImputManager.keyMapping[KeyCode.S].ToString();
                if (item.name == "ControlLeft")
                    item.gameObject.GetComponent<TextMeshProUGUI>().text = GameImputManager.keyMapping[KeyCode.A].ToString();
                if (item.name == "ControlRight")
                    item.gameObject.GetComponent<TextMeshProUGUI>().text = GameImputManager.keyMapping[KeyCode.D].ToString();
            }
            Debug.Log(item.gameObject.name);
        }

        foreach (Transform item in controls2)
        {
            if (item.gameObject.GetInstanceID() != GetInstanceID())
            {
                if (item.name == "ControlUp")
                    item.gameObject.GetComponent<TextMeshProUGUI>().text = GameImputManager.keyMapping[KeyCode.UpArrow].ToString().Split('A')[0];
                if (item.name == "ControlDown")
                    item.gameObject.GetComponent<TextMeshProUGUI>().text = GameImputManager.keyMapping[KeyCode.DownArrow].ToString().Split('A')[0];
                if (item.name == "ControlLeft")
                    item.gameObject.GetComponent<TextMeshProUGUI>().text = GameImputManager.keyMapping[KeyCode.LeftArrow].ToString().Split('A')[0];
                if (item.name == "ControlRight")
                    item.gameObject.GetComponent<TextMeshProUGUI>().text = GameImputManager.keyMapping[KeyCode.RightArrow].ToString().Split('A')[0];
            }
            Debug.Log(item.gameObject.name);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void initMap()
    {
        createPlayers();
        createObjects();
        createCheese();
    }

    void DestroyObjects()
    {
        for (int i = 0; i < traps.Length; i++)
        {
            Destroy(traps[i]);
        }

        Destroy(p1Instance);
        Destroy(p2Instance);
        Destroy(cheeseInstance);
    }

    public void NextRound()
    {

        Debug.Log("Reinicio juego " + round);

        round++;

        DestroyObjects();

        if (round < 6) {
            //Now re-create them
            initMap();
            timer c = GameObject.FindObjectOfType(typeof(timer)) as timer;
            c.ResetTimer();
        }
        else
        {
            if (pl1_score == pl2_score)
            {
                initMap();
            }
            else
            {
                //Game Ends
                GoToWinScreen();
            }
        }
    }

    public void GoToWinScreen()
    {
        if(pl1_score > pl2_score)
        {
            pl_winner = 1;
        }
        else
        {
            pl_winner = 2;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public int GetWinner()
    {
        return pl_winner;
    }

    public void ExitToMenu()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
    }

    void createPlayers()
    {
        p1Instance = Instantiate(player1);
        p2Instance = Instantiate(player2);

        pos1 = getRandomPosPlayer();
        p1Instance.transform.position = pos1;

        do
        {
            pos2 = getRandomPosPlayer();
            p2Instance.transform.position = pos2;
        } while(p1Instance.transform.position == p2Instance.transform.position);
    }

    Vector3 getRandomPosPlayer()
    {
        return new Vector3(Random.value < 0.5f ? -19 : 19, Random.value < 0.5f ? -21 : 17, 0);
    }

    void createCheese()
    {
        cheeseInstance = Instantiate(cheese);
        cheese.transform.position = new Vector3(0, -0.8f, 0);
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
