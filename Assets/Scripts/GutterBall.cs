using UnityEngine;
using System.Collections;

public class GutterBall : MonoBehaviour {

	private PinSetter pinSetter;

	void Start() {
		pinSetter = GameObject.FindObjectOfType<PinSetter>();
	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.name == "Ball") {
			pinSetter.SetBallOutOfPlay();
		}
		
	}
}
