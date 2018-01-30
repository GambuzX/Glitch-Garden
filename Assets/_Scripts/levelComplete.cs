using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class levelComplete : MonoBehaviour {

	public AudioClip levelCompleteSound;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	public void PlayClip(){
		AudioSource.PlayClipAtPoint(levelCompleteSound, this.transform.position, 0.5f);
	}

	public void NextLevel() {
		levelManager.LoadNextLevel ();
	}

	public void StopAttackers(){
		Spawner[] spawners = GameObject.FindObjectsOfType<Spawner> ();
		
		if (spawners != null) {
			foreach (Spawner spawner in spawners) {
				spawner.StopSpawning();
			}
		}
	}
}
