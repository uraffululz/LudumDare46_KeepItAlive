using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour{

	[SerializeField] GameObject player;

	[SerializeField] float hSpeed;
	[SerializeField] float vSpeed;

	[SerializeField] GameObject nearHeatSource = null;
	[SerializeField] bool canGetWarm;
	[SerializeField] bool acquiringWarmth;

	[SerializeField] bool warmingCat;
	

    void Update()
    {
		//canGetWarm = false;
		//acquiringWarmth = false;
		//warmingCat = false;

		GiveWarmth();

		if (!warmingCat) {
			GetWarm();
		}

		if (!acquiringWarmth && !warmingCat) {
			Move();
		}
    }


	void OnTriggerStay (Collider collision) {
		if (collision.gameObject.tag == "HeatSource") {
			canGetWarm = true;
			nearHeatSource = collision.gameObject;
		}
	}


	void OnTriggerExit (Collider collision) {
		if (collision.gameObject.tag == "HeatSource") {
			canGetWarm = false;
			nearHeatSource = null;
		}
	}


	void Move() {
		if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0) {
			player.GetComponent<Animator>().SetBool("Running", false);
		}
		else {
			if (Input.GetAxisRaw("Horizontal") != 0) {
				player.GetComponent<Animator>().SetBool("Running", true);
				Vector3 newPos = new Vector3(player.transform.position.x + (Input.GetAxisRaw("Horizontal") * hSpeed), player.transform.position.y, player.transform.position.z);
				player.transform.LookAt(newPos);
				player.transform.position = newPos;
			}

			if (Input.GetAxisRaw("Vertical") != 0) {
				player.GetComponent<Animator>().SetBool("Running", true);
				Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + (Input.GetAxisRaw("Vertical") * vSpeed));
				player.transform.LookAt(newPos);
				player.transform.position = newPos;
			}
		}
	}


	void GetWarm() {
		if (canGetWarm) {
			if (Input.GetKey(KeyCode.Space)) {
				transform.LookAt(nearHeatSource.transform);
				acquiringWarmth = true;
				GetComponent<Animator>().SetBool("AcquiringWarmth", true);
				player.GetComponent<WarmthController>().playerWarmthBar.fillAmount += (0.25f * Time.deltaTime);
				player.GetComponent<WarmthController>().catWarmthBar.fillAmount += (0.25f * Time.deltaTime);
			}
			else if (Input.GetKeyUp(KeyCode.Space)) {
				acquiringWarmth = false;
				GetComponent<Animator>().SetBool("AcquiringWarmth", false);
			}
		}
		else {
			acquiringWarmth = false;
			GetComponent<Animator>().SetBool("AcquiringWarmth", false);
		}
	}


	void GiveWarmth() {
		if (Input.GetKeyUp(KeyCode.LeftShift)) {
			warmingCat = false;
			GetComponent<Animator>().SetBool("WarmingCat", false);
		}
		else if (Input.GetKey(KeyCode.LeftShift)) {
			warmingCat = true;

			GetComponent<Animator>().SetBool("WarmingCat", true);

			GetComponent<WarmthController>().playerWarmthBar.fillAmount -= (0.05f * Time.deltaTime);
			GetComponent<WarmthController>().catWarmthBar.fillAmount += (0.2f * Time.deltaTime);
		}
	}



}
