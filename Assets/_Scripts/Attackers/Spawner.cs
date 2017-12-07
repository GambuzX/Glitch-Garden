using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] spawnableAttackers;
	
	public float levelDifficulty;
	
	void Update() {
		foreach(GameObject myGameObject in spawnableAttackers) {
			if (timeToSpawn(myGameObject)) {
				Spawn (myGameObject);
			}	
		}
	}
	
	bool timeToSpawn(GameObject attackerGameObject) {
		Attacker attackComponent = attackerGameObject.GetComponent<Attacker>();
		
		float spawnDelay = attackComponent.seenEverySeconds / levelDifficulty;
		float spawnsPerSecond = 1 / spawnDelay;

		if (Time.deltaTime > spawnDelay) {
			Debug.LogWarning("Spawn rate capped by frame rate");
			}
				
		float threshold = spawnsPerSecond * Time.deltaTime / 5;
		
		return (Random.value < threshold);
	}
	
	void Spawn(GameObject leGameObject){
		GameObject attacker = Instantiate(leGameObject, this.transform.position , Quaternion.identity) as GameObject;
		attacker.transform.parent = this.transform;
	}
	
	public void StopSpawning(){	
		foreach(Transform child in transform) {
			child.GetComponent<Animator>().enabled = false;
			child.GetComponent<Attacker>().SetSpeed (0);
		}
		Destroy (this.GetComponent<Spawner>());	
	}
}
