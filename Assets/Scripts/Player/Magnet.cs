using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		Debug.DrawRay (this.transform.position, new Vector2(20,0));

		RaycastHit2D raycastHit2D = Physics2D.Raycast (this.transform.position, Vector2.right, 20, Physics2D.AllLayers);
		if (raycastHit2D != null && raycastHit2D.transform != null) {
			Debug.Log(raycastHit2D.transform.name);
		}
	}
}
