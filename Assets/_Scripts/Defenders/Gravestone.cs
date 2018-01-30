using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Defender))]
public class Gravestone : MonoBehaviour {

	private Animator anim;

	void Start() {
		anim = GetComponent<Animator> ();
	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.GetComponent<Attacker> ()) {
			anim.SetTrigger ("underAttack");
		}
	}
}
