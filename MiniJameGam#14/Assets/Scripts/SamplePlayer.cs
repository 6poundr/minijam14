using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlayer : MonoBehaviour
{

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    private Vector3 _input;
    public float turnRate = 200f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GatherInput();
        Look();
    }

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            Move();
        }

    }


    private void GatherInput() {
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

    private void Move() {

      _rb.MovePosition(transform.position + transform.forward * _speed);
    }
}
