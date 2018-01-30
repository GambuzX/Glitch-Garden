using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float levelTime = 60;
	private Slider slider;
	private levelComplete levelCompleteText;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;


	void Start(){
		slider = this.GetComponent<Slider> ();
		levelCompleteText = GameObject.FindObjectOfType<levelComplete> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void Update(){
		slider.value = Time.timeSinceLevelLoad / levelTime;

		if (Time.timeSinceLevelLoad >= levelTime && isEndOfLevel == false) {
			isEndOfLevel = true;
			levelCompleteText.GetComponent<Animator>().SetTrigger("levelComplete");
		}
	}

	void LoadNextLevel() {
		levelManager.LoadNextLevel();
	}
}
