using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float launchSpeed;

	private Rigidbody rb;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)) {
			Launch();
		}
	}

	void Launch() {
		rb.velocity = new Vector3(0, 0, launchSpeed);
			audioSource.Play();
	}
}
