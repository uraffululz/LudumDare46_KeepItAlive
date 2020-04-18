using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarmthController : MonoBehaviour {
	
	public Image playerWarmthBar;
	bool playerFroze;

	public Image catWarmthBar;
	bool catFroze;
	
	
	void Start() {
        
    }


    void Update() {
        DecreasePlayerWarmthOverTime();
		DecreaseCatWarmthOverTime();

		//if (playerFroze) {
		//}

		//if (catFroze) {
		//}
    }


	void DecreasePlayerWarmthOverTime() {
		if (playerWarmthBar.fillAmount > 0) {
			playerWarmthBar.fillAmount -= (0.05f * Time.deltaTime);
		}
		else {
			if (!playerFroze) {
				playerWarmthBar.fillAmount = 0;
				//GAME OVER
				SceneManager.PlayerGameOver();
				playerFroze = true;
			}
		}
	}


	void DecreaseCatWarmthOverTime () {
		if (catWarmthBar.fillAmount > 0) {
			catWarmthBar.fillAmount -= (0.1f * Time.deltaTime);
		}
		else {
			if (!catFroze) {
				catWarmthBar.fillAmount = 0;
				//GAME OVER
				SceneManager.CatGameOver();
				catFroze = true;
			}
		}
	}
}
