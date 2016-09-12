using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public float standingTheshold = 10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool IsStanding() {
		Vector3 rotationInEuler = transform.rotation.eulerAngles;
		float tiltInX = Mathf.Abs(270 + rotationInEuler.x);
		float tiltInZ = Mathf.Abs(rotationInEuler.z);

		// print(name + " " + tiltInX + " " + tiltInZ);
		if (tiltInX > 350 || tiltInX < standingTheshold &&  tiltInZ > 350 || tiltInZ < standingTheshold) {
			return true;
		}
		return false;
	}
}
