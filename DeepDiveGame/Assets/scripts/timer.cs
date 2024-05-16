using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class timer : MonoBehaviour
{
    public float lapcount = 0;
    public float timelap = 0;
    private bool starttime = false;
    float besttime = 1000;
    float lasttime;
    float seconds;
    float minutes;
    float millisecs;
    public TMPro.TextMeshProUGUI Ltime;
    public TMPro.TextMeshProUGUI Ltimelast;
    public TMPro.TextMeshProUGUI LtimeBest;
    public TMPro.TextMeshProUGUI laps;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Start")
        {
            starttime = true;
            timelap = timelap - timelap;
        }
        if (other.gameObject.tag == "Finish")
        {
            lasttime = timelap;
            Ltimelast.text = string.Format("Last: " + "{0:00}:{1:00}:{2:000}", minutes, seconds, millisecs);
        }
        if (other.gameObject.tag == "Finish")
        {
            lapcount++;
        }
    }

    private void Update()
    {
        if (starttime)
        {
            timelap = timelap +Time.deltaTime;

            minutes = Mathf.FloorToInt(timelap / 60);
            seconds = Mathf.FloorToInt(timelap % 60);
            millisecs = (timelap % 1) * 1000;

            Ltime.text = string.Format("{0:00}:{1:00}:{2:000}",minutes,seconds,millisecs);
        }
        if (lasttime < besttime && lapcount > 1)
        {
            besttime = lasttime;
            LtimeBest.text = string.Format("Best: " + "{0:00}:{1:00}:{2:000}", minutes, seconds, millisecs);
        }

        laps.text = "lap: " + lapcount.ToString() + "/3 ";
    }
}
