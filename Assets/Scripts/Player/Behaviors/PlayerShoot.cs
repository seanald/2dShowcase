using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
	private PlayerMovement playerMovement = null;

	public Transform shootZone;
	public Sprite bullet;

	// Use this for initialization
	void Awake ()
	{
		this.playerMovement = this.GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (this.playerMovement.Animator.GetBool ("Up")) {
				RaycastHit2D hit = Physics2D.Raycast (shootZone.position, Vector2.up);
				print ("Shoot Up" + hit.transform.ToString());
			} else if (this.playerMovement.Animator.GetBool ("Right")) {
				RaycastHit2D hit = Physics2D.Raycast (shootZone.position, Vector2.right);
				print ("Shoot Right");
			} else if (this.playerMovement.Animator.GetBool ("Down")) {
				RaycastHit2D hit = Physics2D.Raycast (shootZone.position, Vector2.down);
				print ("Shoot Down");
			} else if (this.playerMovement.Animator.GetBool ("Left")) {
				RaycastHit2D hit = Physics2D.Raycast (shootZone.position, Vector2.left);
				print ("Shoot Left");
			}
		}
	}
}
