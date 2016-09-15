using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public float standingTheshold = 10.0f;
	public float distanceToRaise = 40f;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool IsStanding() {
		if (this) {
			Vector3 rotationInEuler = transform.rotation.eulerAngles;
			float tiltInX = Mathf.Abs(270 + rotationInEuler.x);
			float tiltInZ = Mathf.Abs(rotationInEuler.z);

			// print(name + " " + tiltInX + " " + tiltInZ);
			if (tiltInX > 350 || tiltInX < standingTheshold &&  tiltInZ > 350 || tiltInZ < standingTheshold) {
			return true;
			}
			return false;
		}
		return false;
	}

	public void Raise() {
			if(IsStanding()) {
				rb.useGravity = false;
				rb.isKinematic = true;
				transform.Translate(0, distanceToRaise, 0, Space.World);
			}
	}

	public void Lower() {
			if(IsStanding()) {
				transform.Translate(0, -distanceToRaise, 0, Space.World);
				rb.useGravity = true;
				rb.isKinematic = false;
				
			}
	}
}
