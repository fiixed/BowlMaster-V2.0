using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private List<int> pins = new List<int>();
	private PinSetter pinSetter;
	private Ball ball;

	// Use this for initialization
	void Start () {
		pinSetter = GameObject.FindObjectOfType<PinSetter>();
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Bowl(int pinFall) {
		pins.Add(pinFall);
		ActionMaster.Action nextAction = ActionMaster.NextAction(pins);
		pinSetter.PerformaAction(nextAction);
		ball.Reset();
	}
}
