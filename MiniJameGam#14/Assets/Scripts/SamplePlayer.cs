using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlayer : MonoBehaviour
{

    [SerializeField] private Rigidbody _rb;
    [SerializeField] public float _speed;
    public float _speedSave = 0.02f;
    private Vector3 _input;
    public float turnRate = 200f;
    public bool isFrenzy = false;
    public float frenzySpeed = 1f;
    public float frenzyDuration = 15f;
    public int comboCounter = 0;
    public float comboTimer = 0f;
    List<Enemy> EatedEnemies = new List<Enemy>();
    public float hunger = 0f;
    public float hungerSave = 0f;
    public float hungerIncreaseSpeed = 10f; // increase hunger by 10 every 10 seconds
    public float hungerDeathThreshold = 100f;

    public bool isMoving = false;
  
    void Start()
    {
        _speedSave = _speed;
        hungerSave = hunger;
       StartCoroutine(IncreaseHunger());
    }

    void Update()
    {
        // GatherInput();
        // Look();
        if (hunger >= hungerDeathThreshold)
        {
            // Player has reached death threshold
            Debug.Log("Player is dead due to hunger");
            // Do death actions here
            GameManager.Instance.UpdateGameState(GameState.Defeat);
        }

        if (!isFrenzy)
        {
            comboTimer += Time.deltaTime;

            if (comboTimer >= 30f)
            {
                comboCounter = 0;
                comboTimer = 0f;
            }
        }

        if (hunger <= 0f)
        {
            hunger = 0f;
        }
            
 }

    // Update is called once per frame
    void FixedUpdate() {
        Debug.Log(isFrenzy);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S))
        {
            GatherInput();
            Look();
            Move();

            isMoving = true;
        } else
        {
            isMoving = false;
        }
    }
    void GatherInput() {
        _input = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
    }

    void Look() {
        if (_input != Vector3.zero) {
            var relative = _input;
            
            Quaternion rotation = Quaternion.Euler(0.0f, 45.0f, 0.0f);

            Matrix4x4 isoMatrix = Matrix4x4.Rotate(rotation);

            Vector3 result = isoMatrix.MultiplyPoint3x4(relative);

            Quaternion resultQuat = Quaternion.LookRotation(result, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, resultQuat, turnRate * Time.deltaTime);
        }
    }

    void Move() {
      _rb.MovePosition(transform.position + transform.forward * _speed);
      isMoving = true;
    }
    IEnumerator IncreaseHunger()
    {
        while (hunger < hungerDeathThreshold)
        {
            hunger += hungerIncreaseSpeed;
            _speed -= _speed / 10f;
            yield return new WaitForSeconds(10f);
            //Debug.Log("Hunger is" + hunger.ToString());
           // Debug.Log("Speed is:" + _speed.ToString());
        }

    }
    public void ActivateFrenzy()
    {
        isFrenzy = true;
        _speed = frenzySpeed;
        Invoke("DeactivateFrenzy", frenzyDuration);
    }

    public void DeactivateFrenzy()
    {
        isFrenzy = false;
        comboCounter = 0;
        _speed = _speedSave;
        hunger = hungerSave;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && isFrenzy)
        {
            Debug.Log("Player collided with enemy when  he  is frenzy");
            AddEnemyToList(collision.gameObject.GetComponent<Enemy>());
            CountEnemiesDestroyed();
        } else if(collision.gameObject.tag == "Enemy")
        {
            //Destroy(this);
            GameManager.Instance.UpdateGameState(GameState.Defeat);
        }
    }

    private void AddEnemyToList(Enemy enemy)
    {
        EatedEnemies.Add(enemy);
    }

    public int CountEnemiesDestroyed()
    {
        return EatedEnemies.Count;
    }
}
