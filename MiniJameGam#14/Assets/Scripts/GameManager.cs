using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private SamplePlayer _player;

    [SerializeField] private Minimap minimap;

    private GameState currentGameState;
    void Awake() {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Camera camera = Helpers.Camera;

        updateGameState(GameState.Starting);
    }

    // Update is called once per frame
    void Update()
    {
        Resource _resource = UnitManager.Instance.GetClosestResource();
        minimap.UpdateResource(_resource);

        if(currentGameState == GameState.Victory || (currentGameState == GameState.Defeat))
        {
            updateGameState(GameState.Playing);
        } else
        {
            updateGameState(GameState.Playing);
        }
        
    }

    void updateGameState(GameState gameState) {

        currentGameState = gameState;
        switch (gameState) {
            case GameState.Starting:
                HandleGameStart();
                break;

            case GameState.Playing:
                CheckGame();
                break;

            case GameState.Victory:
                break;

            case GameState.Defeat:
                break;

            default:
                break;
        }
    }


    private void HandleGameStart() {
        // create initial setup
        // maybe camera as well
<<<<<<< HEAD

        //GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
        //floor.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
=======
        /*        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
                floor.transform.position = new Vector3(0.0f, 0.0f, 0.0f);

                _player.transform.position = new Vector3(0.0f, 0.0f, 0.0f);

                Mesh mesh = floor.GetComponent<MeshFilter>().mesh;

                Debug.Log(mesh);*/
        // _enemyManager.spawnEnemies();

        //UnitManager.Instance.SpawnResources();

        UnitManager.Instance.SpawnResources();
        Resource _resource = UnitManager.Instance.GetClosestResource();
        minimap.Init(_player, _resource);


    }

    private void CheckGame()
    {
>>>>>>> jamegamdev3

    }
}

enum GameState {
    Starting,
    Playing,
    Victory,
    Defeat,
}
