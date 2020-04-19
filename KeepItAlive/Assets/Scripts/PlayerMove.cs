using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour{

	[SerializeField] GameManager gameManager;
	[SerializeField] GameObject player;

	[SerializeField] float hSpeed;
	[SerializeField] float vSpeed;

	[SerializeField] GameObject nearHeatSource = null;
	[SerializeField] bool canGetWarm;
	public bool acquiringWarmth;

	public bool warmingCat;
	

    void Update()
    {
		if (!gameManager.gameStopped) {
			GiveWarmth();

			if (!warmingCat) {
				GetWarm();
			}

			if (!acquiringWarmth && !warmingCat) {
				Move();
			}
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
			GetComponent<AudioSource>().Stop();

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

			if (!GetComponent<AudioSource>().isPlaying) {
				GetComponent<AudioSource>().Play();
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
				GetComponent<AudioSource>().Stop();
				gameManager.recentHeatSource = nearHeatSource;
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
			GetComponent<AudioSource>().Stop();

			GetComponent<WarmthController>().playerWarmthBar.fillAmount -= (0.05f * Time.deltaTime);
			GetComponent<WarmthController>().catWarmthBar.fillAmount += (0.2f * Time.deltaTime);
		}
	}


	public void ResetPlayerAnimator() {
		GetComponent<Animator>().SetBool("AcquiringWarmth", false);
		GetComponent<Animator>().SetBool("Running", false);
		GetComponent<Animator>().SetBool("WarmingCat", false);
	}
}
