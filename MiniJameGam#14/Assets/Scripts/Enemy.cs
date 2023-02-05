using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // [SerializeField] private AnimationCurve _curve;
    private EnemyManager _enemyManager;
    [SerializeField] private Collider enemyCollider;


    // Start is called before the first frame update
    public int Health = 10;
    void Start()
    {
        Debug.Log("Hello World");
        Debug.DrawLine(Vector3.zero, new Vector3(5, 0, 0), Color.white, 2.5f);
    }

    public void Init(EnemyManager enemyManager){
        _enemyManager = enemyManager;
    }

    private void OnCollisionEnter(Collision collision) {

    }

    // Update is called once per frame
    void Update()
    {
        // _current = Mathf.MoveTowards(_current, _target, _speed * Time.deltaTime);
        // transform.position = Vector3.Lerp(Vector3.zero, goalPosition, _curve.Evaluate(_current));
    }

    
    private void MoveTowardsPlayer() {

    }
}
