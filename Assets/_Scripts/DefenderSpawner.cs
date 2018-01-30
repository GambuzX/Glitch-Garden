using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private Camera cam;
	private GameObject parentObject;
	private StarCountDisplay starDisplay;
	
	void Start() {
		cam = GameObject.FindObjectOfType<Camera>();
		starDisplay = GameObject.FindObjectOfType<StarCountDisplay> ();
		
		if (!GameObject.Find("Defenders")) {
			GameObject defendersParent = new GameObject("Defenders");
		}
		parentObject = GameObject.Find("Defenders");
	}
	
	void OnMouseDown() {
		int starCost = Button.selectedDefender.GetComponent<Defender> ().starCost;
		if(Button.selectedDefender & StarCountDisplay.starCount >= Button.selectedDefender.GetComponent<Defender>().starCost) {
			SpawnDefender ();
			starDisplay.UseStars(starCost);
		}		
	}

	void SpawnDefender ()
	{
		GameObject defender = Instantiate (Button.selectedDefender, SnapToGrid (CalculateWorldPointOfMouseClick ()), Quaternion.identity) as GameObject;
		defender.transform.SetParent (parentObject.transform);
	}
	
	Vector2 CalculateWorldPointOfMouseClick() {
		Vector2 pixelsPos = Input.mousePosition;	
		
		return new Vector2 (cam.ScreenToWorldPoint(pixelsPos).x, cam.ScreenToWorldPoint(pixelsPos).y );
	}
	
	Vector2 SnapToGrid(Vector2 position) {
		float snappedX = Mathf.RoundToInt(position.x);
		float snappedY = Mathf.RoundToInt(position.y);		
		Vector2 SnappedPosition = new Vector2 (snappedX, snappedY);
		
		return SnappedPosition;
	}
}
