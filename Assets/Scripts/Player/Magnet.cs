using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour
{

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

		RaycastHit2D[] raycastHit2D = Physics2D.RaycastAll (this.transform.position, Vector2.right, 100, Physics2D.AllLayers);

		foreach (RaycastHit2D hit in raycastHit2D) {
			if (hit.transform != null) {
				
				if (hit.transform.tag.Equals ("Magnet")) {
					Debug.Log (hit.transform.name);
					hit.transform.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * 2000);
				}
			}
		}
	}

	private void UseMagnetPush ()
	{
		Color color = new Color ();
		ColorUtility.TryParseHtmlString ("#71B2FDFF", out color);

		this.GetComponent<SpriteRenderer> ().color = color;

		RaycastHit2D[] raycastHit2D = Physics2D.RaycastAll (this.transform.position, Vector2.right, 100, Physics2D.AllLayers);

		foreach (RaycastHit2D hit in raycastHit2D) {
			if (hit.transform != null) {

				if (hit.transform.tag.Equals ("Magnet")) {
					Debug.Log (hit.transform.name);
					hit.transform.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 2000);
				}
			}
		}
	}
}
