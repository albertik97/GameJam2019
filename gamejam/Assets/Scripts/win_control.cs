using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class win_control : MonoBehaviour
{

    public GameObject plwinner;
    // Start is called before the first frame update
    void Start()
    {
        GameController c = GameObject.FindObjectOfType(typeof(GameController)) as GameController;
        int winner = c.GetWinner();

        if (winner == 1)
        {
            plwinner = GameObject.FindGameObjectWithTag("win_controller");
            GameObject ch0 = plwinner.transform.GetChild(0).gameObject;
            ch0.SetActive(true);
            GameObject ch1 = plwinner.transform.GetChild(1).gameObject;
            ch1.SetActive(false);
        }
        else
        {
            plwinner = GameObject.FindGameObjectWithTag("win_controller");
            GameObject ch0 = plwinner.transform.GetChild(0).gameObject;
            ch0.SetActive(false);
            GameObject ch1 = plwinner.transform.GetChild(1).gameObject;
            ch1.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
