using UnityEngine;
using System.Collections;

public class GutterBall : MonoBehaviour {

	private PinSetter pinSetter;

	void Start() {
		pinSetter = GameObject.FindObjectOfType<PinSetter>();
	}

	
}
