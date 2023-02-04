using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    public InputAction playerControls;
    public InputAction playerInteract;
    public float interactWith;
    Vector2 movedirection = Vector2.zero;
    public float speed = 5f;

     void Update()
    {
        movedirection = playerControls.ReadValue<Vector2>();

        transform.position += transform.forward * movedirection.y * speed * Time.deltaTime;

        transform.position += transform.right * movedirection.x * speed * Time.deltaTime;

        interactWith = playerInteract.ReadValue<float>();
        Debug.Log("Interact value: " + interactWith);
    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerInteract.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
        playerInteract.Disable();
    }
}
    


