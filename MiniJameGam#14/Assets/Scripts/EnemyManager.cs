using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] public int enemyNumber = 10;
    public List<Enemy> enemies = new List<Enemy>();
    // Start is called before the first frame update

    void Awake() {
        Instance = this;
    }
    void Start()
    {
        // _spawnedEnemy = Instantiate(_enemyPrefab);
       //spawnEnemies();
    }

    public void spawnEnemies(Bounds enemySpawnBounds) {
        Debug.Log(enemySpawnBounds.size);
        for (int i = 0; i < enemyNumber; i++) {
            Enemy enemy = Instantiate(_enemyPrefab);

            enemies.Add(enemy);

      //      enemy.Init(this);

            // set coordinate
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
