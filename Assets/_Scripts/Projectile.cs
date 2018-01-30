using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public float speed, damage;

	void Start () {
	
	}
	
	
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);	
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.GetComponent<Attacker>()){
			Health hp = coll.GetComponent<Health>();
			hp.DealDamage(damage);
			Destroy (gameObject);
		}
	}
}
