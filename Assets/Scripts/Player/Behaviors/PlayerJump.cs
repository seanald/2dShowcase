using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour
{

	public float jumpForce;

	private bool isJumping;
	private Rigidbody2D rigidbody2D;
	private Vector2 jumpVector;

	// Use this for initialization
	void Start ()
	{
		this.rigidbody2D = this.GetComponent<Rigidbody2D> ();
		this.jumpVector = new Vector2 (0, this.jumpForce);
	}

	void Update ()
	{
		if (Input.GetKey (KeyCode.Space)) {
			this.rigidbody2D.AddForce (this.jumpVector, ForceMode2D.Impulse);
		}
	}
}
