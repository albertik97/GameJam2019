using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{

    public int numObjects = 5;

    public GameObject   player1,
                        player2,
                        trap,
                        queso;

    public GameObject[] traps;

    public GameObject p1Instance,
                      p2Instance;

    public int  pl1_score,
                pl2_score,
                round;

    bool to_reset;

    void Awake()
    {
        traps = new GameObject[numObjects];
        round = 0;
        initMap();
        to_reset = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (to_reset)
        {
            initMap();
            to_reset = false;
        }
    }

    void WinRound(int pl)
    {
        if(pl == 1)
        {
            Debug.Log("player 1 wins");
        }
        else
        {
            Debug.Log("player 2 wins");
        }
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
        Destroy(queso);
    }

    public void NextRound()
    {

        Debug.Log("Reinicio juego " + round);

        round++;

        DestroyObjects();

        if (round < 6) {
            //Now re-create them
            to_reset = true;
        }
        else
        {
            //Game Ends
            ExitToMenu();
        }
    }

    void ExitToMenu()
    {
        round = 0;
    }

    void createPlayers()
    {
        p1Instance = Instantiate(player1);
        p2Instance = Instantiate(player2);

        pl1_score = 0;
        pl2_score = 0;
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

    void createCheese()
    {
        Instantiate(queso);
        queso.transform.position = new Vector3(0, 0.5f, 0);
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
