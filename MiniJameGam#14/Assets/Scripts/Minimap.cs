using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Minimap : MonoBehaviour
{
    // will hold closest checkpoint
    private Resource Resource;
    private SamplePlayer Player;

    [SerializeField] public Quaternion MissionDirection;

    [SerializeField] public RectTransform MissionLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeResourceDirection();    
    }

    void ChangeResourceDirection()
    {
        if(Resource != null && Player != null)
        {
            Vector3 dir = Resource.transform.position - Player.transform.position;

            MissionDirection = Quaternion.LookRotation(dir);

            MissionDirection.z = -MissionDirection.y;
            MissionDirection.x = 0;
            MissionDirection.y = 0;

            MissionLayer.localRotation = MissionDirection;
        }
        
    }

    public void Init(SamplePlayer _player, Resource _resource)
    {
        Player = _player;

        Resource = _resource;
    }


    public void UpdateResource(Resource _resource)
    {
        Resource = _resource;
    }

}
