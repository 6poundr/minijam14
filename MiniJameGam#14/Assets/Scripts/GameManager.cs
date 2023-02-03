using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private SamplePlayer _player;
    void Awake() {
        Instance = this;
        // Create and position the floor.
        updateGameState(GameState.Starting);
    }
    // Start is called before the first frame update
    void Start()
    {
        Camera camera = Helpers.Camera;

        Debug.Log(camera);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateGameState(GameState gameState) {
        switch(gameState) {
            case GameState.Starting:
                HandleGameStart();
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
        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floor.transform.position = new Vector3(0.0f, 0.0f, 0.0f);

        _player.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }
}

enum GameState {
    Starting,
    Victory,
    Defeat,
}
