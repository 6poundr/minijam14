using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UnitManager Instance;
    [SerializeField] Resource _resourcePrefab;
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] List<Resource> Resources = new List<Resource>();
    [SerializeField] List<Enemy> Enemies = new List<Enemy>();
    [SerializeField] SamplePlayer CurrentPlayer;
    [SerializeField] GameObject CurrentGround;

    Bounds GroundBounds;

    public int resourceNumber = 5;
    public int enemyNumber = 5;

    void Awake()
    {
        Instance = this;

        Mesh mesh = CurrentGround.GetComponent<MeshFilter>().mesh;

        GroundBounds = mesh.bounds;
    }
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnResources()
    {
        for(var i = 0; i < resourceNumber; i++)
        {
            Resource resource = Instantiate(_resourcePrefab);
            Resources.Add(resource);

            // generate valid coordinate

            Vector3 randomValidPosition = GenerateValidCoordinate();

            //Debug.Log(randomValidPosition.ToString());
            resource.Init(randomValidPosition);

            resource.UpdatePlayer(CurrentPlayer);
        }
    }

    public void DeleteResource(Resource resource)
    {
        Resources.Remove(resource);
    }

    public Vector3 GenerateValidCoordinate()
    {
        Vector3 randomCoordinate = new Vector3(
              Random.Range(GroundBounds.min.x * CurrentGround.transform.localScale.x, GroundBounds.max.x * CurrentGround.transform.localScale.x)
            , Random.Range(GroundBounds.min.y * CurrentGround.transform.localScale.y, GroundBounds.max.y * CurrentGround.transform.localScale.y)
            , Random.Range(GroundBounds.min.z * CurrentGround.transform.localScale.z, GroundBounds.max.z * CurrentGround.transform.localScale.z));

        return randomCoordinate;
    }

    public Resource GetClosestResource()
    {
        // will continously check closest resource to player
        Resource closestResource = null;
        if (CurrentPlayer != null)
        {
            float closestDistanceSqr = Mathf.Infinity;
            Vector3 currentPosition = CurrentPlayer.transform.position;
            foreach (Resource resource in Resources)
            {
                Transform resourceTransform = resource.transform;
                Vector3 directionToTarget = resourceTransform.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    closestResource = resource;
                }
            }
        }
      

        return closestResource;
    }

    public void SpawnEnemies()
    {
            for (var i = 0; i < enemyNumber; i++)
            {
                Enemy enemy = Instantiate(_enemyPrefab);
                Enemies.Add(enemy);

                // generate valid coordinate
                Vector3 randomValidPosition = GenerateValidCoordinate();

                randomValidPosition.y = 0.61f;

               // Debug.Log(randomValidPosition.ToString());
                enemy.Init(randomValidPosition);

                enemy.UpdatePlayer(CurrentPlayer);

                enemy.UpdateTransform(CurrentPlayer.transform);
            }
        
    }
}
