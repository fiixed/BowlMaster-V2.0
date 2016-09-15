using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class ActionMasterTest {

	private List<int> pinFalls;
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;

	[SetUp]
	public void Setup() {
		pinFalls = new List<int>();
	}

	[Test]
	public void T00PassingTest() {
		Assert.AreEqual(1,1);
	}

	[Test]
	public void T01OneStrikeReturnsEndTurn() {
		pinFalls.Add(10);
		Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T02Bowl8ReturnsTidy() {
		pinFalls.Add(8);
		Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T03Bowl28ReturnsEndTurn() {
		int[] rolls = {2, 8};
		Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T05CheckResetAtStrikeInLastFrame() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
		
		Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T06CheckResetAtStrikeInLastFrame() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1, 9};
	
		Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
	}	

	[Test]
	public void T07DazzaBowl20Test() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10, 5};
	
		Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T08bensBowl20Test() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10, 0};
		Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
	}

}
