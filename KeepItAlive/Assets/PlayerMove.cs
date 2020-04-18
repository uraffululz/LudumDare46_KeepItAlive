using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour{

	[SerializeField] GameObject player;

	[SerializeField] float hSpeed;
	[SerializeField] float vSpeed;


    void Start()
    {
        
    }

    void Update()
    {
        Move();

		if (Input.GetKey(KeyCode.E)) {
			GetComponent<WarmthController>().playerWarmthBar. fillAmount -= (0.2f * Time.deltaTime);
			GetComponent<WarmthController>().catWarmthBar.fillAmount += (0.2f * Time.deltaTime);
		}
    }


	void Move() {
		if (Input.GetAxisRaw("Horizontal") != 0) {
			Vector3 newPos = new Vector3(player.transform.position.x + (Input.GetAxisRaw("Horizontal") * hSpeed), player.transform.position.y, player.transform.position.z);
			player.transform.position = newPos;
		}

		if (Input.GetAxisRaw("Vertical") != 0) {
			Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + (Input.GetAxisRaw("Vertical") * vSpeed));
			player.transform.position = newPos;
		}

	}
}
