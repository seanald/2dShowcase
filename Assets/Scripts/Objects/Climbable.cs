using UnityEngine;
using System.Collections;

public class Climbable : MonoBehaviour
{
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
			//Keep player in center of climbable object
			collider.transform.position = new Vector3 (this.transform.position.x, collider.transform.position.y);
		}
	}
}
