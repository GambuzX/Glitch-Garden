using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;

	private Animator anim;
	private Spawner mySpawner;
	
	GameObject projectileParent;
	
	void Start() {
		projectileParent = GameObject.Find("Projectiles");
		anim = this.GetComponent<Animator> ();
		SetLaneSpawner ();
		
		if(!projectileParent) { 
			projectileParent = new GameObject("Projectiles");
			}		
		}

	void Update() {
		if (attackerOnLane ()) {
			anim.SetBool ("isAttacking", true);
		} else {
			anim.SetBool ("isAttacking", false);
		}
	} 
	
	private void Fire(){	
		
			GameObject newProjectile = Instantiate(projectile) as GameObject;
			newProjectile.transform.SetParent(projectileParent.transform);
			newProjectile.transform.position = gun.transform.position;
		}

	/*bool attackerOnLane() {
		Attacker[] attackers = FindObjectsOfType<Attacker>();
		float xPos = this.transform.position.x;
		float yPos = this.transform.position.y;

		foreach (Attacker myGameObject in attackers) {
			float xAtk = myGameObject.transform.position.x;
			float yAtk = myGameObject.transform.position.y;
			if (yAtk == yPos & xAtk > xPos) {
				return true;
			}
		}
		return false;

	} */

	void SetLaneSpawner(){
		Spawner[] spawners = GameObject.FindObjectsOfType<Spawner> ();
		foreach (Spawner spawner in spawners) {
			if (spawner.transform.position.y == this.transform.position.y) {
				mySpawner = spawner;
				return;
			}
		}
		Debug.LogError ("No spawners in lane");
	}
	bool attackerOnLane() {
		if (mySpawner.transform.childCount <= 0) {
			return false;
		}
		foreach (Transform child in mySpawner.transform) {
			if (child.transform.position.x > this.transform.position.x) {
				return true;
			}
		}
		return false;
	}
}
