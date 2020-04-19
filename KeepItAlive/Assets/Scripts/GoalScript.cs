using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {

	[SerializeField] GameManager gameManager;
	[SerializeField] GameObject player;
 
	void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update() {
        
    }


	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			gameManager.Win();
		}
	}
}
