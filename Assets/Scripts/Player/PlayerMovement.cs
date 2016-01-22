using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 1.0f;

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
			//moving true
		} else {
			//moving false
		}

		Vector2 movement = new Vector2 (horizontal, vertical);
		this.transform.Translate (movement * speed);
	}
}
