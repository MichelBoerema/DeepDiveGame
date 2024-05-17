using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartTimer : MonoBehaviour
{
    public GameObject carInputController;
    public GameObject aiInputController;

    public float startTimer = 10f;
    public TextMeshProUGUI startTimer_TEXT;
    void Update()
    {
        startTimer -= Time.deltaTime;
        startTimer_TEXT.text = startTimer.ToString("00");
        if (startTimer <= 0f)
        {
            Destroy(startTimer_TEXT);
            CarInputController ci = carInputController.GetComponent<CarInputController>();
            ci.car.motorTorque = 480f;

            AIInputController AIci = aiInputController.GetComponent<AIInputController>();
            AIci.car.motorTorque = 3600f;
        }
    }
}
