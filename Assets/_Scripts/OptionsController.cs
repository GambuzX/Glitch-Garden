using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {
	
	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;
	
	private MusicManager musicManager;
	
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	public void SaveAndExit() {
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.ChangeDifficulty(difficultySlider.value);
		levelManager.LoadLevel ("Start");
	}
	
	public void Default() {		
		volumeSlider.value = 0.5f;
		difficultySlider.value = 2;
		}
		
	void Update () {
		musicManager.ChangeVolume(volumeSlider.value);
	}
}
