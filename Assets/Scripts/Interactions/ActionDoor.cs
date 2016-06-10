using UnityEngine;
using System.Collections;

public class ActionDoor : MonoBehaviour
{
	public bool locked;
	public Transform travelPoint;


	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag.Equals ("Player")) {
			collider.transform.position = this.travelPoint.transform.position;
			Camera.main.transform.position = new Vector3 (this.travelPoint.transform.position.x, this.travelPoint.transform.position.y, Camera.main.transform.position.z);
		}
	}
}
