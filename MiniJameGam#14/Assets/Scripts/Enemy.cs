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
    private bool doOnce = false;
    // Start is called before the first frame update
    private void Start()
    {
        gameObject.SetActive(true);
        snake.SetActive(false);   
    }
    private void OnTriggerEnter(Collider other)
    {  
            if (other.tag == "Player" && !isFollowing) { 
            
            snake.SetActive(true);

            SFXmanager.Instance.PlaySnakeSound();

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
        //Debug.Log("samplePlayer.isFrenzy" + samplePlayer.isFrenzy);
        if (isFollowing && samplePlayer != null && !samplePlayer.isFrenzy)
        {

            // Follow the player
            snake.transform.position = Vector3.MoveTowards(snake.transform.position, target.position, followSpeed * Time.deltaTime);

            snake.transform.LookAt(target.position);
            
           
        } else if(samplePlayer != null && samplePlayer.isFrenzy)
        {
            // Run away from the player
            snake.transform.position = Vector3.MoveTowards(snake.transform.position, -target.position, followSpeed * Time.deltaTime);
            snake.transform.LookAt(-target.position);

        }
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && samplePlayer.isFrenzy)
        {
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

    public void UpdateTransform(Transform transform)
    {
        target = transform;
    }



}


