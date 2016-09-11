using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 launchVelocity;

	private Rigidbody rb;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false;

		// Launch(launchVelocity);
	}

	public void Launch(Vector3 velocity) {
		rb.useGravity = true;
		rb.velocity = velocity;

		audioSource = GetComponent<AudioSource>();
		audioSource.Play();
	}
}
