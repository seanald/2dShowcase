using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour
{
	private PlayerMovement playerMovement;

	void Start()
	{
		this.playerMovement = this.GetComponent<PlayerMovement> ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.LeftShift)) {
			this.UseMagnetAttract ();
		}
		if (Input.GetKey (KeyCode.RightShift)) {
			this.UseMagnetPush ();
		}else if (Input.GetKeyUp (KeyCode.LeftShift) || Input.GetKeyUp (KeyCode.RightShift)) {
			Color color = new Color ();
			ColorUtility.TryParseHtmlString ("#FFF", out color);

			this.GetComponent<SpriteRenderer> ().color = color;
		}
	}

	private void UseMagnetAttract ()
	{
		Color color = new Color ();
		ColorUtility.TryParseHtmlString ("#F56666FF", out color);

		this.GetComponent<SpriteRenderer> ().color = color;

		RaycastHit2D[] raycastHit2D = Physics2D.RaycastAll (this.transform.position, this.playerMovement.PlayerDirection, 100, Physics2D.AllLayers);

		foreach (RaycastHit2D hit in raycastHit2D) {
			if (hit.transform != null) {
				
				if (hit.transform.tag.Equals ("Magnet")) {
					Debug.Log (hit.transform.name);
					Rigidbody2D rigid2d = hit.transform.GetComponent<Rigidbody2D> ();
					if (rigid2d.isKinematic)
					{
						this.playerMovement.Rigidbody.AddForce (this.playerMovement.PlayerDirection * 2000);
					}
					else
					{
						rigid2d.AddForce (this.playerMovement.PlayerDirection * -2000);
					}
				}
			}
		}
	}

	private void UseMagnetPush ()
	{
		Color color = new Color ();
		ColorUtility.TryParseHtmlString ("#71B2FDFF", out color);

		this.GetComponent<SpriteRenderer> ().color = color;

		RaycastHit2D[] raycastHit2D = Physics2D.RaycastAll (this.transform.position, this.playerMovement.PlayerDirection, 100, Physics2D.AllLayers);

		foreach (RaycastHit2D hit in raycastHit2D) {
			if (hit.transform != null) {

				if (hit.transform.tag.Equals ("Magnet")) {
					Debug.Log (hit.transform.name);
					Rigidbody2D rigid2d = hit.transform.GetComponent<Rigidbody2D> ();
					if (rigid2d.isKinematic)
					{
						this.playerMovement.Rigidbody.AddForce (this.playerMovement.PlayerDirection * -2000);
					}
					else
					{
						rigid2d.AddForce (this.playerMovement.PlayerDirection * 2000);
					}
				}
			}
		}
	}
}
