using UnityEngine;
using UnityEditor;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest {

	private ActionMaster actionMaster;
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;

	[SetUp]
	public void Setup() {
		actionMaster = new ActionMaster();
	}

	[Test]
	public void T00PassingTest() {
		Assert.AreEqual(1,1);
	}

	[Test]
	public void T01OneStrikeReturnsEndTurn() {
		Assert.AreEqual(endTurn, actionMaster.Bowl(10));
	}

	[Test]
	public void T02Bowl8ReturnsTidy() {
		Assert.AreEqual(tidy, actionMaster.Bowl(8));
	}

	[Test]
	public void T03Bowl28ReturnsEndTurn() {
		actionMaster.Bowl(2);
		Assert.AreEqual(endTurn, actionMaster.Bowl(8));
	}

	[Test]
	public void T05CheckResetAtStrikeInLastFrame() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach(int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual(reset, actionMaster.Bowl(10));
	}

	[Test]
	public void T06CheckResetAtStrikeInLastFrame() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach(int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		actionMaster.Bowl(1);
		Assert.AreEqual(reset, actionMaster.Bowl(9));
	}	

	[Test]
	public void T07DazzaBowl20Test() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach(int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		actionMaster.Bowl(10);
		Assert.AreEqual(tidy, actionMaster.Bowl(5));
	}

	[Test]
	public void T08bensBowl20Test() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach(int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		actionMaster.Bowl(10);
		Assert.AreEqual(tidy, actionMaster.Bowl(0));
	}

}
