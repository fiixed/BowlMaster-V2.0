using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public Text standingDisplay;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding().ToString();
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
}
