using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public int standingCount = -1;
	public Text standingDisplay;
	
	private Ball ball;
	private float lastChangeTime;
	private bool ballEnteredBox = false;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding().ToString();

		if (ballEnteredBox) {
			CheckStandingCount();
		}
	}

	int CountStanding() {
		int count = 0;
		Pin[] pins = GameObject.FindObjectsOfType<Pin>();
		foreach(Pin pin in pins) {
			if(pin.IsStanding()) {
				count++;
			}
		}
		return count;
	}

	void OnTriggerEnter(Collider col) {
		if (col.GetComponent<Ball>()) {
			ballEnteredBox = true;
			standingDisplay.color = Color.red;
		}	
	}

	void OnTriggerExit(Collider col) {
		if (col.GetComponent<Pin>()) {
			Destroy(col.gameObject);
		}	
	}

	void CheckStandingCount() {
		int currentStanding = CountStanding();
		
		if (currentStanding != standingCount) {
			lastChangeTime = Time.time;
			standingCount = currentStanding;
			return;
		}

		float settleTime = 3f;  // how long to wait to consider pins settled
		if ((Time.time - lastChangeTime) > settleTime) { // if last change > 3s ago
			PinshaveSettled();
		}
	

		// call PinshaveSettled when they have
	}

	void PinshaveSettled() {
		ball.Reset();
		standingCount = -1;
		ballEnteredBox = false;
		standingDisplay.color = Color.green;
	}
}
