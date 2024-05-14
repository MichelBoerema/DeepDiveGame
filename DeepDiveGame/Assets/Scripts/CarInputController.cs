using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum GearState
{
    Neutral,
    Running,
    CheckingChange,
    Changing
};
public class CarInputController : MonoBehaviour
{
    Car car;

    public float Forwards;
    public float Steering;
    public float braking;

    public GameObject[] cameras;

    public float RPM;
    public float redLine;
    public float idleRPM;
    public TMP_Text rpmText;
    public TMP_Text gearText;
    public Slider rpmSlider;
    public int currentGear;

    public float[] gearRatios;
    public float differentialRatio;
    private float currentTorque;
    private float clutch;
    public int isEngineRunning;
    private float wheelRPM;
    public AnimationCurve hpToRPMCurve;
    private GearState gearState;
    public float increaseGearRPM;
    public float decreaseGearRPM;
    public float changeGearTime = 0.5f;

    public AudioSource Audio;
    public AudioSource Audio2;
    void Awake()
    {
        car = GetComponent<Car>();
    }

    // Update is called once per frame
    void Update()
    {
        rpmSlider.value = RPM;
        rpmText.text = RPM.ToString("0,000") + "rpm";
        gearText.text = (gearState == GearState.Neutral) ? "N" : (currentGear + 1).ToString();

        Forwards = Input.GetAxis("Vertical");
        Steering = Input.GetAxis("Horizontal");
        if (gearState != GearState.Changing)
        {
            if (gearState == GearState.Neutral)
            {
                clutch = 0;
                Audio.volume = 0.3f;
                if (Mathf.Abs(Forwards) > 0) gearState = GearState.Running;
                
            }
            else
            {
                Audio.volume = 1f;
                clutch = Input.GetKey(KeyCode.LeftShift) ? 0 : Mathf.Lerp(clutch, 1, Time.deltaTime);
                
            }
        }
        else
        {
            clutch = 0;
        }

        currentTorque = CalculateTorque();
        car.ChangeSpeed(currentTorque, Forwards);
        car.Turn(Steering);
        if (Input.GetKey(KeyCode.S))
        {
            car.activatebrake(braking);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            car.activatebrake(braking);
        }
        else
        {
            car.disablebrake(braking);
        }


        if (Input.GetKey(KeyCode.Alpha1))
            {
                foreach (GameObject cam in cameras)
                {
                    cam.SetActive(false);
                }
                cameras[0].SetActive(true);
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                foreach (GameObject cam in cameras)
                {
                    cam.SetActive(false);
                }
                cameras[1].SetActive(true);
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                foreach (GameObject cam in cameras)
                {
                    cam.SetActive(false);
                }
                cameras[2].SetActive(true);
            }
            if (Input.GetKey(KeyCode.Alpha4))
            {
                foreach (GameObject cam in cameras)
                {
                    cam.SetActive(false);
                }
                cameras[3].SetActive(true);
            }

        if(Steering != 0 && car.currentspeed >= 80)
        {
            Audio2.mute = false;
        }
        else
        {
            Audio2.mute = true;
        }
    }

    float CalculateTorque()
    {
        float torque = 0;
        if (RPM < idleRPM + 200 && Forwards == 0 && currentGear == 0)
        {
            gearState = GearState.Neutral;
        }
        if (gearState == GearState.Running && clutch > 0)
        {
            if (Input.GetKeyDown(KeyCode.E)/*RPM > increaseGearRPM*/)
            {
                StartCoroutine(ChangeGear(1));
            }
            else if (Input.GetKeyDown(KeyCode.Q)/*RPM < decreaseGearRPM*/)
            {
                StartCoroutine(ChangeGear(-1));
            }
        }
        if (isEngineRunning > 0)
        {
            if (clutch < 0.1f)
            {
                RPM = Mathf.Lerp(RPM, Mathf.Max(idleRPM, redLine * Forwards) + Random.Range(-50, 50), Time.deltaTime);
            }
            else
            {
                foreach (var wheel in car.wheels)
                {
                    wheelRPM = Mathf.Abs((wheel.Torque) / 2f) * gearRatios[currentGear] * differentialRatio;
                }
                
                RPM = Mathf.Lerp(RPM, Mathf.Max(idleRPM - 100, wheelRPM), Time.deltaTime * 3f);
                torque = (hpToRPMCurve.Evaluate(RPM / redLine) * car.motorTorque / RPM) * gearRatios[currentGear] * differentialRatio * 5252f * clutch;
            }
        }

        return torque;
    }
    IEnumerator ChangeGear(int gearChange)
    {
        gearState = GearState.CheckingChange;
        if (currentGear + gearChange >= 0)
        {
            if (gearChange > 0)
            {
                //increase the gear
                gearState = GearState.Running;
            }
            if (gearChange < 0)
            {
                //decrease the gear
                gearState = GearState.Running;
            }
            gearState = GearState.Changing;
            yield return new WaitForSeconds(changeGearTime);
            currentGear += gearChange;
        }

        if (gearState != GearState.Neutral)
            gearState = GearState.Running;
    }
}
