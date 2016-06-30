using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	private Animator animator;
	private Rigidbody2D rigidbody;
	private float speed = 1.0f;
	private Vector2 playerDirection;
	private bool lockDirection;

	public float runMultiplier;
	public float baseSpeed;

	void Start ()
	{
		this.animator = this.GetComponent<Animator> ();
		this.rigidbody = this.GetComponent<Rigidbody2D> ();
		this.speed = this.baseSpeed;
	}

	void FixedUpdate ()
	{
		this.CalculateBaseSpeed ();
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
		ManageMovement (h, v);
	}

	void ManageMovement (float horizontal, float vertical)
	{
		if (horizontal != 0f || vertical != 0f) {
			if (horizontal > 0f) {
				this.animator.SetBool ("Up", false);
				this.animator.SetBool ("Down", false);
				this.animator.SetBool ("Right", true);
				this.animator.SetBool ("Left", false);

				this.playerDirection = Vector2.right;
			} else if (horizontal < 0f) {
				this.animator.SetBool ("Up", false);
				this.animator.SetBool ("Down", false);
				this.animator.SetBool ("Right", false);
				this.animator.SetBool ("Left", true);

				this.playerDirection = Vector2.left;
			} else if (vertical > 0f) {
				this.animator.SetBool ("Up", true);
				this.animator.SetBool ("Down", false);
				this.animator.SetBool ("Right", false);
				this.animator.SetBool ("Left", false);

				this.playerDirection = Vector2.up;
			} else if (vertical < 0f) {
				this.animator.SetBool ("Up", false);
				this.animator.SetBool ("Down", true);
				this.animator.SetBool ("Right", false);
				this.animator.SetBool ("Left", false);

				this.playerDirection = Vector2.down;
			}
			this.animator.SetBool ("Idle", false);
		} else {
			this.animator.SetBool ("Idle", true);
		}

		Vector2 movement = new Vector2 (horizontal, vertical);
		this.rigidbody.velocity = (movement * speed);
		//this.transform.Translate (movement * speed);
	}

	private void CalculateBaseSpeed()
	{
		if (Input.GetKey (KeyCode.LeftShift)) {
			this.Run ();
		} else {
			this.speed = this.baseSpeed;
		}
	}

	private void Run()
	{
		this.speed = this.baseSpeed * this.runMultiplier;
	}

	public Animator Animator {
		get {
			return animator;
		}
	}

	public Vector2 PlayerDirection {
		get {
			return playerDirection;
		}
		set {
			playerDirection = value;
		}
	}

	public bool LockDirection {
		get {
			return lockDirection;
		}
		set {
			lockDirection = value;
		}
	}
}
