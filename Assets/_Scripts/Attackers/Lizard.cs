using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Lizard : MonoBehaviour {

	private Attacker attacker;	
	private Animator animator;
	
	// Use this for initialization
	void Start () {
		attacker = this.gameObject.GetComponent<Attacker>();		
		animator = this.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D trigger) {
		GameObject obj = trigger.gameObject;
		
		//if not a defender, return
		if(!obj.gameObject.GetComponent<Defender>()) {
			return;
		}
		animator.SetBool("isAttacking", true);
		attacker.Attack (obj);
	}
}
