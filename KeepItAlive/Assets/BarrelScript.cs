using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour {

	[SerializeField] GameObject player;


    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update() {
        
    }


	void OnTriggerStay (Collider collision) {
		if (collision.gameObject == player) {
			player.GetComponent<WarmthController>().playerWarmthBar.fillAmount += (0.25f * Time.deltaTime);
		}
	}
}
