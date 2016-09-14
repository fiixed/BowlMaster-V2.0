using UnityEngine;
using System.Collections;

public class ActionMaster {

	public enum Action {Tidy, Reset, EndTurn, EndGame};

	private int[] bowls = new int[21];
	private int bowl = 1;

	public Action Bowl(int pins) {
		if (pins < 0 || pins > 10) {throw new UnityException("Invalid number of pins");}
		bowls[bowl - 1] = pins;

		if (bowl == 21) {
			return Action.EndGame;
		}
	
		if (bowl >= 19 && pins == 10) {
			bowl++;
			return Action.Reset;
		} else if (bowl == 20) {
			bowl++;
			if (AreAllPinsKnockedDown()) {
				return Action.Reset;
			} else if (Bowl21HasBeenAwarded()) {
				return Action.Tidy;
			} else {
				return Action.EndGame;
			}
		}

		if (pins == 10) {
			bowl += 2;
			return Action.EndTurn;	
		} 


		// if first bowl of frame
		// return Action.Tidy;
		if (bowl % 2 != 0) { // Mid frame or last frame
			bowl++;
			return Action.Tidy;
		}  else {	// End of frame
			bowl++;
			return Action.EndTurn;
		}

		// Other behaviour here
		throw new UnityException("Not sure what action to return");
	}

	private bool AreAllPinsKnockedDown() {
		return ((bowls[19-1] + bowls[20-1]) % 10 == 0);
	}

	private bool Bowl21HasBeenAwarded() {
		return (bowls[19-1] + bowls[20-1] >= 10);
	} 
}
