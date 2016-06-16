using UnityEngine;
using System.Collections;

public class Climb : MonoBehaviour
{
	public Trigger2DTest LadderGrabTest { get; private set; }

	private Transform Linecast1 { get; set; }
	private Transform Linecast2 { get; set; }
	private bool climbing;

	void Awake ()
	{
		this.LadderGrabTest = this.transform.Find ("ClimbCheck").GetComponent<Trigger2DTest> ();

		this.Linecast1 = this.transform.Find ("ClimbLinecastTop");
		this.Linecast2 = this.transform.Find ("ClimbLinecastBottom");
	}

	void Update ()
	{
		
		EdgeCollider2D ladderGrabEdgeSpine = this.LadderGrabTest.GetTriggerCollider<EdgeCollider2D> ();
		if (ladderGrabEdgeSpine != null && ladderGrabEdgeSpine.name.Equals ("LadderSpine-EdgeColliders")) {
			this.GotoLadderState_FromSpine (ladderGrabEdgeSpine);
		}

		RaycastHit2D[] hits = Physics2D.RaycastAll (Linecast1.position, Vector2.zero);

		foreach (RaycastHit2D hit in hits) {
			if (hit.transform != null && hit.transform.gameObject != null && hit.transform.gameObject.layer == LayerMask.NameToLayer ("Ladder")) {
				this.climbing = true;
				break;
			} else {
				this.climbing = false;
			}
		}

		hits = Physics2D.RaycastAll (Linecast2.position, Vector2.zero);
		foreach (RaycastHit2D hit in hits) {
			if (hit.transform != null && hit.transform.gameObject != null && hit.transform.gameObject.layer == LayerMask.NameToLayer ("Ladder")) {
				this.climbing = true;
				break;
			} else {
				this.climbing = false;
			}
		}

		if (!climbing) {
			this.gameObject.GetComponent<BoxCollider2D> ().isTrigger = false;
		}
	}

	public void GotoLadderState_FromSpine (EdgeCollider2D ladderSpine)
	{
		// Snap to the ladder
		Vector3 pos = this.transform.position;
		float ladder_x = ladderSpine.points [0].x;
		this.transform.position = new Vector3 (ladder_x, pos.y, pos.z);
		this.gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
	}

}
