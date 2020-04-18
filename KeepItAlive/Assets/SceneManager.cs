using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {

	bool gameSet = false;
	[SerializeField] Text timer;
	float totalLevelTime = 120;


	void Start() {
        
    }


	void Update() {
        Countdown();
    }


	void Countdown() {
		int seconds = (int)((totalLevelTime - Time.time) % totalLevelTime);
		timer.text = seconds.ToString();

		if (gameSet && timer.text == "0") {
			TimeOutGameOver();
		}
		else {
			gameSet = true;
		}
	}

	
	public static void Win() {
		print("You win");
	}


	public static void PlayerGameOver() {
		print("The Player has died");
	}


	public static void CatGameOver() {
		print("The Cat has died");
	}


	public static void TimeOutGameOver() {
		print("You have run out of time. The Cat has died");
	}
}
