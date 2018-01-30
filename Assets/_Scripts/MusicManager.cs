using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusics;
	
	private AudioSource audioS;
	
	private AudioClip previousMusic;

	void Awake () {
		DontDestroyOnLoad(gameObject);
		}
		
	void Start () {
		audioS = GetComponent<AudioSource>();
		audioS.Play();
		audioS.volume = PlayerPrefsManager.GetMasterVolume();
	}
	
	void OnLevelWasLoaded(int level) {
		AudioClip thisLevelMusic = levelMusics[level];
		if (thisLevelMusic && thisLevelMusic != previousMusic) {
			previousMusic = thisLevelMusic;
			audioS.clip = thisLevelMusic;
			audioS.loop = true; 
			audioS.Play ();
			}
	}
	
	public void ChangeVolume(float volume) {
		audioS.volume = volume;
	}
}
