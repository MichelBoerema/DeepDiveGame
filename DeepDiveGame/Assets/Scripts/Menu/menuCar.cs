using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class menuCar : MonoBehaviour
{
    [SerializeField] private AudioClip hornSound;
    [SerializeField] private AudioClip hornSoundLoud;

    [SerializeField] private GameObject audioObject;
    private Rigidbody rb;
    private float cooldown;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        transform.Rotate(0, Time.deltaTime * 10, 0);
    }

    private void OnMouseDown()
    {
        if (transform.position.y <= 0.01f && cooldown <= 0)
        {
            cooldown = 0.2f;
            rb.AddForce(0, 200, 0);

            var newAudio = Instantiate(audioObject, transform);
            Destroy(newAudio, 4);

            float range = 0.25f;
            float pitch = Random.Range(1 - range, 1 + range);

            var newSource = newAudio.GetComponent<AudioSource>();
            newSource.pitch = pitch;
            newSource.volume = Settings.volume;

            float roll = Random.Range(0, 100);
            if (roll != 0)
            {
                newSource.PlayOneShot(hornSound);
            }
            else
            {
                newSource.PlayOneShot(hornSoundLoud);
            }
        }
    }
}
