using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    public float maxFuelInSeconds = 180f;
    public float fuelAmount;

    //public Transform centerOfMass;
    public float motorTorque = 500f;
    public float maxSteer = 20f;
    public float currentspeed;
    public float brakeForce = 10000f;
    public float steer { get; set; }
    public float throttle { get; set; }
    public Rigidbody _rigidbody;
    public Wheel[] wheels;

    [Header("Speedometer")]
    public Rigidbody target;

    [Header("UI")]
    public RectTransform arrow; // The arrow in the speedometer
    [SerializeField] GameObject Warning_lable;

    private float speed = 0.0f;

    void Start()
    {
        fuelAmount = maxFuelInSeconds;
        wheels = GetComponentsInChildren<Wheel>();
        _rigidbody = GetComponent<Rigidbody>();
        //_rigidbody.centerOfMass = centerOfMass.localPosition;
    }
    void Update()
    {
        StartCoroutine(CalculateSpeed());
        // 3.6f to convert in kilometers
        // ** The speed must be clamped by the car controller **
        //speed = target.velocity.magnitude * 3.6f;

        //if (speedLabel != null)
        //    speedLabel.text = ((int)speed) + " km/h";
        //if (speedSlider != null)
        //    speedSlider.value = currentspeed;
        //    //arrow.localEulerAngles =
        //    //    new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, speed / maxSpeed));
    }

    public void ChangeSpeed(float throttle, float input)
    {
        foreach (var wheel in wheels)
        {

            wheel.Torque = input * throttle;
        }
    }
    public void Turn(float steer)
    {
        foreach (var wheel in wheels)
        {
            wheel.Steerangle = steer * maxSteer;
        }
    }

    public void TurnWheel(float steerWheel)
    {

    }
    public void activatebrake(float brake)
    {
        foreach (var wheel in wheels)
        {
            wheel.brakeForce = brake;
        }
    }
    public void disablebrake(float brake)
    {
        foreach (var wheel in wheels)
        {
            wheel.brakeForce = 0f;
        }
    }

    IEnumerator CalculateSpeed()
    {
        Vector3 lastPosition = transform.position;
        yield return new WaitForFixedUpdate();
        currentspeed = (lastPosition - transform.position).magnitude / Time.deltaTime * 4f;
    }

    public void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);

        if (collision.gameObject.tag == "Grass")
        {
            Debug.Log("Je moeder");
            target.drag = 0.5F;
            Warning_lable.SetActive(true);
        }
        else
        {
            target.drag = 0.0F;
            Warning_lable.SetActive(false);
        }


    }

}
