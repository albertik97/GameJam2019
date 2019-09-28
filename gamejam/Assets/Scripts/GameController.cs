using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject   player1,
                        player2;




    void Awake()
    {
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
        

    }

    void createPlayers()
    {
        Instantiate(player1);
        Instantiate(player2);

        player1.transform.position = getRandomPos();

        do
        {
            player2.transform.position = getRandomPos();
        } while(player1.transform.position == player2.transform.position);
        

    }

    Vector3 getRandomPos()
    {
        return new Vector3(Random.value < 0.5f ? -19 : 19, Random.value < 0.5f ? -21 : 17, 0);
    }
}
