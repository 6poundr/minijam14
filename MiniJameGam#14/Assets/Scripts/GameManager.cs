using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        UpdateGameState(GameState.Starting);
    }

    // Update is called once per frame
    void Update()
    {
        Resource _resource = UnitManager.Instance.GetClosestResource();
        if(_resource != null)
        {
            minimap.UpdateResource(_resource);
        }
      

        if(currentGameState == GameState.Victory || (currentGameState == GameState.Defeat))
        {
            UpdateGameState(GameState.Playing);
        } else
        {
            UpdateGameState(GameState.Playing);
        }
        
    }

    public void UpdateGameState(GameState gameState) {

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
                HandleGameDefeat();
                break;

            default:
                break;
        }
    }


    private void HandleGameStart() {
        // create initial setup
        // maybe camera as well

        //GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
        //floor.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
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
        UnitManager.Instance.SpawnEnemies();

    }

    private void HandleGameDefeat()
    {
        Destroy(_player);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //SceneManager.LoadScene("GameMap");
    }

    private void CheckGame()
    {
        
    }
}

public enum GameState {
    Starting,
    Playing,
    Victory,
    Defeat,
}
