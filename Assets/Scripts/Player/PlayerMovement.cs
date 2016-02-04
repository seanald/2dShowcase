using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	private Animator animator;
	public float speed = 1.0f;

	void Start ()
	{
		this.animator = this.GetComponent<Animator> ();
	}

	void FixedUpdate ()
	{
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
		ManageMovement (h, v);
	}

	void ManageMovement (float horizontal, float vertical)
	{
		Rigidbody2D rigidbody = GetComponent<Rigidbody2D> ();

		if (horizontal != 0f || vertical != 0f) {
			if (horizontal > 0f) {
				this.animator.SetBool ("Up", false);
				this.animator.SetBool ("Down", false);
				this.animator.SetBool ("Right", true);
				this.animator.SetBool ("Left", false);
			} else if (horizontal < 0f) {
				this.animator.SetBool ("Up", false);
				this.animator.SetBool ("Down", false);
				this.animator.SetBool ("Right", false);
				this.animator.SetBool ("Left", true);
			} else if (vertical > 0f) {
				this.animator.SetBool ("Up", true);
				this.animator.SetBool ("Down", false);
				this.animator.SetBool ("Right", false);
				this.animator.SetBool ("Left", false);
			} else if (vertical < 0f) {
				this.animator.SetBool ("Up", false);
				this.animator.SetBool ("Down", true);
				this.animator.SetBool ("Right", false);
				this.animator.SetBool ("Left", false);
			}
			this.animator.SetBool ("Idle", false);
		} else {
			this.animator.SetBool ("Idle", true);
		}

		Vector2 movement = new Vector2 (horizontal, vertical);
		this.transform.Translate (movement * speed);
	}
}
