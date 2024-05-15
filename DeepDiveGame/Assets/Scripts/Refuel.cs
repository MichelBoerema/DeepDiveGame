using UnityEngine;

public class Refuel : MonoBehaviour
{
    private Car car;
    public float secondsToRefuel;

    private void Start()
    {
        car = FindObjectOfType<Car>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (car._rigidbody.velocity.magnitude <= 1f)
        {
            car.fuelAmount = Mathf.MoveTowards(car.fuelAmount, car.maxFuelInSeconds, Time.deltaTime * car.maxFuelInSeconds * (1 / secondsToRefuel));
        }
    }
}
