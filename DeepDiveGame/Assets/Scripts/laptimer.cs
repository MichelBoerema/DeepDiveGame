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
            Ltimelast.text = "Last: " + lasttime.ToString("f3");
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
            //Debug.Log(timelap);
            Ltime.text = "Time: " + timelap.ToString("f3");
        }
        if (lasttime < besttime && lapcount > 1)
        {
            besttime = lasttime;
            LtimeBest.text = "Best: " + besttime.ToString("f3");
        }

        laps.text = "lap: " + lapcount.ToString() + "/3 ";
    }
}
