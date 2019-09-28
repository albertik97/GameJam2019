using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text counter;
    public float seconds, minutes, last_seconds, changer;
    public GameObject goc;
    // Start is called before the first frame update
    void Start(/*float mins*/)
    {
        seconds = 30;
        last_seconds = 0;
        minutes = 0f;
        changer = 0f;
        counter = GetComponent<Text>() as Text;
        counter.text = "03:00";
    }

    // Update is called once per frame
    void Update()
    {

        if(seconds < 0 && minutes > 0){
            seconds = 59;
            minutes--;
        }
        else{

            float actual_seconds = (int)(Time.time % 60f);

            if (actual_seconds - last_seconds != 0)
            {
                seconds--;
                last_seconds = (int)(Time.time % 60f);
                changer++;
            }
        }
        counter.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        GameController c = GameObject.FindObjectOfType(typeof(GameController)) as GameController;
        if (seconds == 0f && minutes == 0f)
        {
            seconds = 30;
            minutes = 0;
            c.NextRound();
        }

        if(changer >= 10)
        {
            changer = 0;
            goc.swap();
            c.setControls();
        }
    }

    public void ResetTimer()
    {
        seconds = 30;
        minutes = 0;
    }
}
