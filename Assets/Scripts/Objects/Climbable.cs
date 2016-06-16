using UnityEngine;
using System.Collections;

public class Climbable : MonoBehaviour
{
	public Trigger2DTest LadderGrabTest { get; private set; }

	void Awake ()
	{
		RaycastHit2D[] hits = Physics2D.RaycastAll (this.transform.position, Vector2.zero);

		foreach (RaycastHit2D hit in hits) {
			if (hit.collider != null) {
				//Disables Colliders underneath climbable object on startup
				hit.collider.GetComponent<BoxCollider2D> ().isTrigger = true;
			}
		}

	}

	void OnTriggerStay2D (Collider2D collider)
	{
		if (collider.tag.Equals ("Player")) {
			collider.isTrigger = true;
		}
	}
}
