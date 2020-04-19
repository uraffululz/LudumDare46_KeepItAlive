using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	[SerializeField] GameObject player;

	[SerializeField] Image introScreen;
	[SerializeField] Image winScreen;
	[SerializeField] Image gameOverScreen;
	[SerializeField] Button checkpointButton;

	public bool gameStopped;

	bool gameSet = false;
	[SerializeField] Text timer;
	float totalLevelTime = 120;
	int seconds;

	public GameObject recentHeatSource;


	void Start() {
		gameStopped = true;
        recentHeatSource = null;

		Time.timeScale = 0;
    }


	void Update() {
        Countdown();
    }

	public void StartGame() {
		gameStopped = false;
		Time.timeScale = 1;
		GetComponent<AudioSource>().Play();
		introScreen.gameObject.SetActive(false);
	}


	void Countdown() {
		seconds = (int)((totalLevelTime - Time.time) % totalLevelTime);
		//timer.text = seconds.ToString();

		if (gameSet) {
			if (seconds > 100) {
				timer.text = "Hang in there, kitty";
			}
			else if (seconds > 90) {
				timer.text = "Good thing I found you";
			}
			else if (seconds > 80) {
				timer.text = "Gotta keep going";
			}
			else if (seconds > 70) {
				timer.text = "How did this happen?";
			}
			else if (seconds > 60) {
				timer.text = "S-s-so c-c-c-cold";
			}
			else if (seconds > 50) {
				timer.text = "Hope it's not infected";
			}
			else if (seconds > 40) {
				timer.text = "Almost there";
			}
			else if (seconds > 30) {
				timer.text = "Have to get there before they close";
			}
			else if (seconds > 20) {
				timer.text = "You're gonna make it, little guy";
			}
			else if (seconds < 0) {
				seconds = (int)totalLevelTime;
			}
		}
		else {
			gameSet = true;
		}
	}

	
	public void Win() {
		print("You win");
		winScreen.gameObject.SetActive(true);
		GetComponent<AudioSource>().Stop();
		player.GetComponent<AudioSource>().Stop();
		gameStopped = true;
		Time.timeScale = 0;
	}


	public void GameOver() {
		if (recentHeatSource != null) {
			checkpointButton.gameObject.SetActive(true);
		}
		else {
			checkpointButton.gameObject.SetActive(false);
		}

		gameOverScreen.gameObject.SetActive(true);
		PauseSound();
		player.GetComponent<AudioSource>().Stop();

		gameStopped = true;
		Time.timeScale = 0;
	}


	public void RestartLevel() {
		SceneManager.LoadScene(0);
	}


	public void ReturnToCheckpoint() {
		player.transform.position = recentHeatSource.transform.position + (Vector3.back * 2);
		player.GetComponent<WarmthController>().playerWarmthBar.fillAmount = 1f;
		player.GetComponent<WarmthController>().catWarmthBar.fillAmount = 1f;

		seconds = (int)totalLevelTime;

		gameOverScreen.gameObject.SetActive(false);
		Time.timeScale = 1;
		GetComponent<AudioSource>().UnPause();
		gameStopped = false;

		player.GetComponent<PlayerMove>().acquiringWarmth = false;
		player.GetComponent<PlayerMove>().warmingCat = false;
		player.GetComponent<PlayerMove>().ResetPlayerAnimator();
		player.GetComponent<WarmthController>().playerFroze = false;
		player.GetComponent<WarmthController>().catFroze = false;

	}

	void PauseSound() {
		GetComponent<AudioSource>().Pause();
	}


	public void QuitGame() {
		Application.Quit();
	}
}
