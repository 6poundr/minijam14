using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SamplePlayer samplePlayer;
    public Transform target;
    private bool isFollowing = false;
    public float followSpeed;
    public GameObject snake;
    List<GameObject> EatedEnemies = new List<GameObject>();
    private int enemiesDestroyed = 0;
    public float rotateSpeed;
    // Start is called before the first frame update
    private void Start()
    {
        gameObject.SetActive(true);
        snake.SetActive(false);   
    }
    private void OnTriggerEnter(Collider other)
    {  
            if (other.tag == "Player" && !isFollowing) { 
            
            //Debug.Log("Player entered snake trigger");
            snake.SetActive(true);
            
            isFollowing = true;

            if(samplePlayer ==  null)
            {
                samplePlayer = other.gameObject.GetComponent<SamplePlayer>();
            }
            
            target = other.transform;
            }
        
    }
    private void Update()
    {
        if (isFollowing && samplePlayer != null)
        {
           
                if (samplePlayer.isFrenzy)
                {
                    // Run away from the player
                    snake.transform.position = Vector3.MoveTowards(snake.transform.position, -target.position, followSpeed * Time.deltaTime);
                    snake.transform.LookAt(-target.position);
                }
                else
                {
                    // Follow the player
                    snake.transform.position = Vector3.MoveTowards(snake.transform.position, target.position, followSpeed * Time.deltaTime);

                    snake.transform.LookAt(target.position);
                }
            
           
        }
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(samplePlayer.isFrenzy);
        if (collision.gameObject.tag == "Player" && samplePlayer.isFrenzy)
        {

            Debug.Log("Player entered snake collision");

            gameObject.SetActive(false);
            snake.SetActive(false);
            isFollowing = false;
        }
    }
    public void Init(Vector3 randomValidPosition)
    {
        transform.position = randomValidPosition;
    }

    public void UpdatePlayer(SamplePlayer player)
    {
        samplePlayer = player;
    }



}


