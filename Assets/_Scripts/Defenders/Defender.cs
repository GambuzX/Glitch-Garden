using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour { 
	
	private StarCountDisplay starDisplay;
	
	public int starCost;
	
	void Start() {
		starDisplay = GameObject.FindObjectOfType<StarCountDisplay>();
		}
	
	public void AddStars(int number) {
		starDisplay.AddStars(number);
	}

}
