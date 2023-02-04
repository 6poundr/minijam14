using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public Transform target;
    private bool isFollowing = false;
    public float followSpeed;
    public GameObject snake;
    // Start is called before the first frame update
    private void Start()
    {
        gameObject.SetActive(true);
        snake.SetActive(false);   
    }
    private void OnTriggerEnter(Collider other)
    {  
            if (other.tag == "Player") { 
            
            Debug.Log("Player entered snake collider");
            snake.SetActive(true);
            
            isFollowing = true;
            target = other.transform;
            }
        
    }
    private void Update()
    {
        if (isFollowing)
        {
            snake.transform.position = Vector3.MoveTowards(snake.transform.position, target.position, followSpeed * Time.deltaTime);
        }
    }

}
