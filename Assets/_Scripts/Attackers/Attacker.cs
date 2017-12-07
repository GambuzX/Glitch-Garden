using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	
	[Tooltip("Average numbers of seconds between appearances")]
	public float seenEverySeconds;
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator anim;
	private GameObject spawner;
	
	// Use this for initialization
	void Start () {	
		anim = this.GetComponent<Animator>();
		spawner = GameObject.Find("Spawner");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) { 
			anim.SetBool("isAttacking", false);
		}
		
		
	}
	
	public void SetSpeed(float speed) { 
		currentSpeed = speed;
	}
	
	//Called from the animator at time of actual attack
	public void StrikeCurrentTarget(float damage) {
		if(currentTarget) {
			Health health = currentTarget.GetComponent<Health>();
			if (health) {
				health.DealDamage(damage);
			 }
		}
	}
	
	public void Attack (GameObject obj){
		currentTarget = obj;
	}
}
