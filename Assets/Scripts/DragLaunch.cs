using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	private Ball ball;
	private float startTime;
	private Vector3 startPos, endPos;
	

	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball>();
	}
	
	public void DragStart() {
		// Capture time & position of mouse click
		startPos = Input.mousePosition;
		startTime = Time.time;
	}

	public void DragEnd() {
		// Launch the ball
		float timeElapsed = Time.time - startTime;
		endPos = Input.mousePosition;

		float launchSpeedX = (endPos.x - startPos.x) / timeElapsed;
		float launchSpeedZ = (endPos.y - startPos.y) / timeElapsed;
	
		Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
		ball.Launch(launchVelocity);
	}
}
