using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class StarCountDisplay : MonoBehaviour {

	private Text text;
	public static int starCount = 100;
	
	void Start() { 
		text = this.GetComponent<Text>();
		text.text = "Stars: 100";
	}
	
	public void AddStars(int amount) {
		starCount += amount;
		UpdateDisplay();
	}
	public void UseStars(int amount) {
		starCount -= amount;
		UpdateDisplay();
	}
	
	void UpdateDisplay(){
		text.text = "Stars: " + starCount.ToString ();
	}
}
