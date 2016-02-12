using UnityEngine;
using System.Collections;

public class ActionPickup : MonoBehaviour, IAction {

	private Inventory playerInventory;
	private bool finished;

	public void Activate ()
	{
		if (this.finished) {
			this.Finished ();
		} else {
			this.finished = true;
		}
	}

	public void Finished ()
	{
		this.finished = false;
	}
}
