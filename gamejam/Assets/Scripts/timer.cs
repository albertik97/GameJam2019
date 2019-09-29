using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text counter;
    public float seconds, minutes, last_seconds, changer, swtch;
    bool active;
    public GameObject goc;
    // Start is called before the first frame update
    void Start(/*float mins*/)
    {
        seconds = 30;
        last_seconds = 0;
        minutes = 0f;
        changer = 0f;
        active = false;
        swtch = 0f;
        counter = GetComponent<Text>() as Text;
        counter.text = "03:00";
    }

    // Update is called once per frame
    void Update()
    {

        if (active)
        {
            if(swtch >= 1)
            {
                active = false;
                swtch = 0f;

                GameObject a = GameObject.FindGameObjectWithTag("gamecanvas");
                GameObject ch0 = a.transform.GetChild(7).gameObject;
                ch0.SetActive(false);
                GameObject ch1 = a.transform.GetChild(8).gameObject;
                ch1.SetActive(false);
            }
        }

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
                if (active)
                {
                    swtch++;
                }
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

        if(changer >= 5)
        {
            changer = 0;
            goc.swap();
            c.setControls();

            //Show switch images
            if (active == false) {
                active = true;
                swtch = 0f;

                GameObject m = GameObject.FindGameObjectWithTag("swtch");
                AudioSource au = m.GetComponent<AudioSource>();
                au.Play();

                GameObject a = GameObject.FindGameObjectWithTag("gamecanvas");
                GameObject ch0 = a.transform.GetChild(7).gameObject;
                ch0.SetActive(true);
                GameObject ch1 = a.transform.GetChild(8).gameObject;
                ch1.SetActive(true);
            }
        }
    }

    public void ResetTimer()
    {
        seconds = 30;
        minutes = 0;
    }
}
