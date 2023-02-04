using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    public InputAction playerControls;
    Vector2 movedirection = Vector2.zero;
    public float speed = 5f;
    public float powerupSpeed = 10f;


    
    void Update()
    {
        movedirection = playerControls.ReadValue<Vector2>();

        transform.position += transform.forward * movedirection.y * speed * Time.deltaTime;

        transform.position += transform.right * movedirection.x * speed * Time.deltaTime;

        Debug.Log(movedirection);
    }

    private void OnEnable()
    {
        playerControls.Enable();
       
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
    


