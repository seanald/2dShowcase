using UnityEngine;
using System.Collections;

public class Switchable : MonoBehaviour
{
	public bool turnedOn;

	void Awake ()
	{
		if (turnedOn) {
			this.TurnOn ();
		} else {
			this.TurnOff ();
		}
	}

	public void TurnOn ()
	{
		this.transform.gameObject.SetActive (true);
		this.turnedOn = true;
	}

	public void TurnOff ()
	{
		this.transform.gameObject.SetActive (false);
		this.turnedOn = false;
	}
}
