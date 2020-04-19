using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	[SerializeField] GameObject player;


    void Start()
    {
        
    }

    void Update()
    {
		Vector3 newCameraPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        transform.position = newCameraPos;
    }
}
