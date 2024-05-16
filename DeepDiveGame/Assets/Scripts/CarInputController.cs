using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public enum GearState
{
    Neutral,
    Running,
    CheckingChange,
    Changing
};
public class CarInputController : MonoBehaviour
{
    private WheelControl controls;
    public PlayerInput playerInput;
    private LogitechGSDK.LogiControllerPropertiesData properties;
    [SerializeField] private Vector2 steerVector2;
    public float xAxis, gasInput, brakeInput, clutchInput;
    public int currentGear;

    Car car;

    public float Forwards;
    public float Steering;
    public float braking;
    public float handBrake;

    public GameObject[] cameras;

    public float RPM;
    public float redLine;
    public float idleRPM;
    public TMP_Text rpmText;
    public TMP_Text gearText;
    public Slider rpmSlider;

    public float[] gearRatios;
    public float differentialRatio;
    private float currentTorque;
    public float clutch;
    public int isEngineRunning;
    private float wheelRPM;
    public AnimationCurve hpToRPMCurve;
    private GearState gearState;
    public float increaseGearRPM;
    public float decreaseGearRPM;
    public float changeGearTime = 0.5f;

    [SerializeField] private bool usingKeyBoard = true;
    [SerializeField] private bool usingController = false;
    [SerializeField] private bool usingWheel = false;

    public Material brakeLight;

    void Awake()
    {
        car = GetComponent<Car>();
        controls = new WheelControl();
        controls.Controller.ShiftUp.performed += ctx => StartCoroutine(ChangeGear(1));
        controls.Controller.ShiftDown.performed += ctx => StartCoroutine(ChangeGear(-1));

        controls.Controller.Steer.performed += ctx => steerVector2 = ctx.ReadValue<Vector2>();
        controls.Controller.Steer.canceled += ctx => steerVector2 = Vector2.zero;

        controls.Controller.Accelerate.performed += ctx => Forwards = ctx.ReadValue<float>();

        LogitechGSDK.LogiSteeringInitialize(false);
    }

    float GetForward() => playerInput.actions["Accelerate"].ReadValue<float>();
    float GetBrake() => playerInput.actions["Brake"].ReadValue<float>();
    float GetShiftUp() => playerInput.actions["ShiftUp"].ReadValue<float>();
    float GetShiftDown() => playerInput.actions["ShiftDown"].ReadValue<float>();

    float GetClutch()
    {
        //return playerInput.actions["Clutch"].ReadValue<float>();
        if (playerInput.actions["Clutch"].ReadValue<float>() == 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    

    public void HandleInputData(int val)
    {
        if (val == 0)
        {
            usingKeyBoard = true;
            usingController = false;
            usingWheel = false;
        }
        if (val == 1)
        {
            usingController = true;
            usingWheel = false;
            usingKeyBoard = false;
        }
        if (val == 2)
        {
            usingWheel = true;
            usingKeyBoard = false;
            usingController = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (usingKeyBoard)
        {
            Forwards = Input.GetAxis("Vertical");
            Steering = Input.GetAxis("Horizontal");

            if (Input.GetKey(KeyCode.S))
            {
                brakeInput = 1;
            }
            else
            {
                brakeInput = 0f;
            }

            if (gearState != GearState.Changing)
            {
                if (gearState == GearState.Neutral)
                {
                    clutch = 0f;
                    if (Mathf.Abs(Forwards) > 0) gearState = GearState.Running;
                }
                else
                {
                    clutch = Input.GetKey(KeyCode.LeftShift) ? 0 : Mathf.Lerp(clutch, 1, Time.deltaTime);
                }
            }
            else
            {
                clutch = 0;
            }
        }

        if (usingController)
        {
            Steering = Input.GetAxis("Horizontal");
            Forwards = GetForward();

            brakeInput = GetBrake();

            if (gearState != GearState.Changing)
            {
                if (gearState == GearState.Neutral)
                {
                    clutch = 0f;
                    if (Mathf.Abs(Forwards) > 0) gearState = GearState.Running;
                }
                else
                {
                    clutch = GetClutch();
                }
            }
            else
            {
                clutch = 0;
            }
        }

        if (usingWheel)
        {
            if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(0))
            {
                LogitechGSDK.DIJOYSTATE2ENGINES rec;
                rec = LogitechGSDK.LogiGetStateCSharp(0);

                Steering = rec.lX / 32767f;

                if (rec.lY > 0)
                {
                    Forwards = 0;
                }
                else if (rec.lY < 0)
                {
                    Forwards = rec.lY / -32768f;
                }

                if (rec.lRz > 0)
                {
                    brakeInput = 0;
                }
                else if (rec.lRz < 0)
                {
                    brakeInput = rec.lRz / -32768f;
                }

                if (gearState != GearState.Changing)
                {
                    if (gearState == GearState.Neutral)
                    {
                        clutch = 0f;
                        if (Mathf.Abs(Forwards) > 0) gearState = GearState.Running;
                    }
                }
                else
                {
                    if (rec.rglSlider[0] > 0)
                    {
                        clutch = 1;
                    }
                    else if (rec.rglSlider[0] < 0)
                    {
                        clutch = rec.rglSlider[0] / -32768f - 1;
                    }
                }
            }
        }

        rpmSlider.value = RPM;
        rpmText.text = RPM.ToString("0,000") + "rpm";
        gearText.text = (gearState == GearState.Neutral) ? "N" : (currentGear + 1).ToString();

        currentTorque = CalculateTorque();
        car.ChangeSpeed(currentTorque, Forwards);
        car.Turn(Steering);

        if (brakeInput > 0f)
        {
            brakeLight.SetColor("_Color", Color.red * 10);
            car.activatebrake(braking);
        }
        else
        {
            brakeLight.SetColor("_Color", Color.red);
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
            if (usingKeyBoard)
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

            if (usingController)
            {
                float inputR1 = GetShiftUp();
                float inputL1 = GetShiftDown();
                if (inputR1 > 0)
                {
                    StartCoroutine(ChangeGear(1));
                }
                if (inputL1 > 0)
                {
                    StartCoroutine(ChangeGear(-1));
                }
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
                    wheelRPM = Mathf.Abs((wheel.Torque) / 4f) * gearRatios[currentGear] * differentialRatio;
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
