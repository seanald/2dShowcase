using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour
{
	private bool switchOn = false;

	public Switchable[] switchTargets;

	private void ActivateSwitches ()
	{
		foreach (Switchable switchable in switchTargets) {
			switchable.TurnOn ();
		}
		this.switchOn = true;
	}

	private void DeactivateSwitches ()
	{
		foreach (Switchable switchable in switchTargets) {
			switchable.TurnOff ();
		}
		this.switchOn = false;
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (this.switchOn) {
			this.DeactivateSwitches ();
		} else {
			this.ActivateSwitches ();
		}
	}
}
