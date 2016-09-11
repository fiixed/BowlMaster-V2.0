using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	private Ball ball;
	private float startTime, ballPosX;
	private Vector3 startPos, endPos;

	

	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball>();
	}

	public void MoveStart(float xNudge) {
		if (!ball.inPlay) {
			if(ballPosX > -45 && ballPosX < 45) {
				ballPosX += xNudge;
				ball.transform.Translate(new Vector3(xNudge, 0, 0));
				
			}
		}
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
