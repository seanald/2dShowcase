using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExecuteAction : MonoBehaviour
{

	private List<IAction> actionsInRange;

	void Start ()
	{
		this.actionsInRange = new List<IAction> ();
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			foreach (IAction action in this.actionsInRange) {
				action.Activate ();
			}
		}
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (!this.actionsInRange.Contains (collider.GetComponentInChildren<IAction> ()) && collider.GetComponentInChildren<IAction> () != null) {
			this.actionsInRange.Add (collider.GetComponentInChildren<IAction> ());
		}
	}

	void OnTriggerExit2D (Collider2D collider)
	{
		if (this.actionsInRange.Contains (collider.GetComponentInChildren<IAction> ())) {
			collider.GetComponentInChildren<IAction> ().Finished ();
			this.actionsInRange.Remove (collider.GetComponentInChildren<IAction> ());
		}
	}
}
