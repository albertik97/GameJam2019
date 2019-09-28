using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text counter;
    public float seconds, minutes, last_seconds;

    // Start is called before the first frame update
    void Start(/*float mins*/)
    {
        seconds = -1;
        minutes = 3f;
        counter = GetComponent<Text>() as Text;
        counter.text = "03:00";
    }

    // Update is called once per frame
    void Update()
    {
        if(seconds < 0){
            seconds = 59;
            minutes--;
        }
        else{

            float actual_seconds = (int)(Time.time % 60f);

            if (actual_seconds - last_seconds != 0)
            {
                seconds--;
                last_seconds = (int)(Time.time % 60f);
            }
        }
        counter.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
