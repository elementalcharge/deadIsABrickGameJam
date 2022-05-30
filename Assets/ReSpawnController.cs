using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawnController : MonoBehaviour
{
    [SerializeField] Transform SpawnPosition;
    [SerializeField] GameObject player;
    [SerializeField] GameObject brick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(brick, player.transform.TransformPoint(Vector3.zero), player.transform.rotation );
            player.transform.SetPositionAndRotation( SpawnPosition.position, transform.rotation);
        }
        
    }
}
