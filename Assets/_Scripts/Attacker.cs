using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Range (-1.5f, 1.5f)] 
	public float velocity;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.left * velocity * Time.deltaTime);
	}
}
