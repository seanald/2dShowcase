using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActionDialogue : MonoBehaviour, IAction
{
	public string text;
	public Text output;

	private bool finished;

	public void Activate ()
	{
		if (this.finished) {
			this.Finished ();
		} else {
			output.text = text;
			this.finished = true;
		}
	}

	public void Finished ()
	{
		output.text = null;
		this.finished = false;
	}
}
