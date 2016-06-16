using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

public class Trigger2DTest : MonoBehaviour
{

	private List<Collider2D> triggerColliders = new List<Collider2D> ();

	public T GetTriggerCollider<T> () where T : Collider2D
	{
		var colliders = this.triggerColliders.OfType<T> ();
		if (colliders.Count () > 0) {
			return colliders.First ();
		}
		return null;
	}

	public bool IsInTrigger ()
	{
		return this.triggerColliders.Count () > 0;
	}

	private void OnTriggerEnter2D (Collider2D collider)
	{
		if (!this.triggerColliders.Contains (collider)) {
			this.triggerColliders.Add (collider);
		}
	}

	private void OnTriggerStay2D (Collider2D collider)
	{
		if (!this.triggerColliders.Contains (collider)) {
			this.triggerColliders.Add (collider);
		}
	}

	void LateUpdate ()
	{
		// Clear the triggers at the end of every frame
		// They will get picked up again in a OnTriggerStay2D call
		this.triggerColliders.Clear ();
	}
}
