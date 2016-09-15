using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 launchVelocity;
	public bool inPlay = false;

	private Rigidbody rb;
	private AudioSource audioSource;
	private Vector3 ballPos;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false;
		ballPos = transform.position;
	}

	public void Launch(Vector3 velocity) {
		inPlay = true;
		rb.useGravity = true;
		rb.velocity = velocity;

		audioSource = GetComponent<AudioSource>();
		audioSource.Play();
	}

	public void Reset() {
		inPlay = false;
		transform.position = ballPos;
		transform.rotation = Quaternion.identity;
		rb.useGravity = false;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		
		
	}
}
