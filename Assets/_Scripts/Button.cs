using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	SpriteRenderer sprite;
	private Button[] buttons;
	public GameObject defenderPrefab;
	
	public static GameObject selectedDefender;
	private Text costText;
	
	void Start(){
		sprite = this.gameObject.GetComponent<SpriteRenderer>();
		buttons = GameObject.FindObjectsOfType<Button>();
		costText = this.transform.GetChild(0).gameObject.GetComponent<Text>();
		
		if(!costText) {Debug.LogWarning (name + "has no cost text assigned!");}
		costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString ();
	}
	

	void OnMouseDown () {		
		foreach (Button thisButton in buttons) {
			thisButton.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
		}
		selectedDefender = defenderPrefab;	
		sprite.color = Color.white;
	}
	
}
