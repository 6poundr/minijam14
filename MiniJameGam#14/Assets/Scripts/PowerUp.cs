using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private CharacterController characterControllerScript;
    private float originalSpeed;
    private float powerupSpeed = 10f;
    public float duration;
    private bool isActivated = false;
    private float holdTime = 0f;

    private void Start()
    {
        characterControllerScript = GetComponent<CharacterController>();
        originalSpeed = characterControllerScript.speed;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            holdTime += Time.deltaTime;
            if (holdTime >= 2f && !isActivated)
            {
                ActivatePowerUp();
            }
        }
        else
        {
            holdTime = 0f;
        }
    }

    private void ActivatePowerUp()
    {
        isActivated = true;
        characterControllerScript.speed = powerupSpeed;
        Invoke("DeactivatePowerUp", duration);
    }

    private void DeactivatePowerUp()
    {
        characterControllerScript.speed = originalSpeed;

        isActivated = false;
        holdTime = 0f;
    }
}
