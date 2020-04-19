using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarmthController : MonoBehaviour {

	[SerializeField] GameManager gameManager;
	
	public Image playerWarmthBar;
	public bool playerFroze;

	public Image catWarmthBar;
	public bool catFroze;
	
	
	void Start() {
        
    }


    void Update() {
        DecreasePlayerWarmthOverTime();
		DecreaseCatWarmthOverTime();
    }


	void DecreasePlayerWarmthOverTime() {
		if (playerWarmthBar.fillAmount > 0) {
			playerWarmthBar.fillAmount -= (0.04f * Time.deltaTime);
		}
		else {
			if (!playerFroze) {
				playerWarmthBar.fillAmount = 0;
				//GAME OVER
				gameManager.GameOver();
				playerFroze = true;
			}
		}
	}


	void DecreaseCatWarmthOverTime () {
		if (catWarmthBar.fillAmount > 0) {
			catWarmthBar.fillAmount -= (0.055f * Time.deltaTime);
		}
		else {
			if (!catFroze) {
				catWarmthBar.fillAmount = 0;
				//GAME OVER
				gameManager.GameOver();
				catFroze = true;
			}
		}
	}
}
