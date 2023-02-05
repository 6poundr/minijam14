using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public SamplePlayer player;
    [SerializeField] public float smoothSpeed = 0.1f;
    [SerializeField] public Vector3 offset;
    // Update is called once per frame
    void LateUpdate()
    {
        if(player.isMoving)
        {
            Vector3 desiredPosition = player.transform.position + offset;
            //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            
            transform.position = desiredPosition;

            transform.LookAt(player.transform);
        }
    }
}
