using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public SamplePlayer samplePlayer;
    private float originalSpeed;
    private float currentSpeed;
    public float powerupSpeed;
    public float duration;
    private bool isActivated = false;
    private float holdTime = 0f;
    private float newSpeed;
    private bool isPoweredUp = false;
    private void Start()
    {
        //samplePlayerScript = GetComponent<SamplePlayer>();
        originalSpeed = samplePlayer._speed;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && isActivated)
        {
            holdTime += Time.deltaTime;
            Debug.Log(holdTime);
            if (holdTime >= 2f && !isPoweredUp)
            {             
                  isPoweredUp= true;
                  ActivatePowerUp();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isActivated = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isActivated = false;
        }
    }

    private void ActivatePowerUp()
    {
        newSpeed = samplePlayer._speed + powerupSpeed;
        samplePlayer._speed = newSpeed;
        Invoke("DeactivatePowerUp", duration);
        Debug.Log("activated!");
        gameObject.SetActive(false);
    }

    private void DeactivatePowerUp()
    {
        isPoweredUp= false;
        samplePlayer._speed = newSpeed - powerupSpeed;
        holdTime = 0f;
    }
}
