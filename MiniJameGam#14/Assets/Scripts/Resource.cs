using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    private bool isEated;
    public SamplePlayer samplePlayer;
    private float originalSpeed;
    private float currentSpeed;
    private bool isActivated = false;
    private float holdTime = 0f;
    private float newSpeed;
    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = samplePlayer._speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && isActivated)
        {
            holdTime += Time.deltaTime;
            if (holdTime >= 2f && !isEated)
            {   
                    isEated = true;
                    CollectResource();   
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isActivated = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isActivated = false;
        }
    }
    void CollectResource()
    {
        newSpeed = samplePlayer._speed + originalSpeed / 10f;
        currentSpeed = newSpeed;
        samplePlayer._speed = newSpeed;
        originalSpeed = newSpeed;
        samplePlayer.hunger -= 10f;
        Debug.Log("Speed is:" + originalSpeed.ToString());
        holdTime = 0f;
        gameObject.SetActive(false);
    }

    public void Init(Vector3 randomValidPosition)
    {
        transform.position = randomValidPosition;
    }

}