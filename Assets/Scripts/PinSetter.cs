using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {
	
	public GameObject pinSet;

	private Animator animator;
	private PinCounter pinCounter;

	ActionMaster actionMaster = new ActionMaster(); // We need it here as we want only 1 instance

	// Use this for initialization
	void Start () {
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
		animator = GetComponent<Animator> ();
	}
	
	void OnTriggerExit(Collider col) {
		if (col.gameObject.GetComponent<Pin>()) {
			Destroy(col.gameObject);
		}
	}

	public void RaisePins () {
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.Raise();
		}
	}

	public void LowerPins () {
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.Lower();
		}
	}

	public void RenewPins () {
		GameObject newPins = Instantiate (pinSet);
		newPins.transform.position += new Vector3 (0, 20, 0);

	}
	public void PerformaAction(ActionMaster.Action action) {
		if (action == ActionMaster.Action.Tidy) {
			animator.SetTrigger ("tidyTrigger");
		} else if (action == ActionMaster.Action.EndTurn) {
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset();
		} else if (action == ActionMaster.Action.Reset) {
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset();
		} else if (action == ActionMaster.Action.EndGame) {
			throw new UnityException ("Don't know how to handle end game yet");
		}
	}
	
}