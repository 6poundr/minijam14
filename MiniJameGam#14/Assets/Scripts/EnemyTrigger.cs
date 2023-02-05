using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public SamplePlayer samplePlayer;
    public Transform target;
    private bool isFollowing = false;
    public float followSpeed;
    public GameObject snake;
    List<GameObject> EatedEnemies = new ();
    private int enemiesDestroyed = 0;
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
            if (samplePlayer.isFrenzy)
            {
                // Run away from the player
                snake.transform.position = Vector3.MoveTowards(snake.transform.position, -target.position, followSpeed * Time.deltaTime);
            }
            else
            {
                // Follow the player
                snake.transform.position = Vector3.MoveTowards(snake.transform.position, target.position, followSpeed * Time.deltaTime);
            }
        }
    }
    private void CountEnemiesDestroyed()
    {
        enemiesDestroyed = EatedEnemies.Count;
        Debug.Log("Number of enemies destroyed: " + enemiesDestroyed);
    }
    private void AddEnemyToList(GameObject enemy)
    {
        EatedEnemies.Add(enemy);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && samplePlayer.isFrenzy)
        {
            AddEnemyToList(snake);
            CountEnemiesDestroyed();
            snake.SetActive(false);
        }
    }

}