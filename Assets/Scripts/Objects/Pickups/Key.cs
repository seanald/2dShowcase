using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour, Pickup
{

	#region Pickup implementation

	public void Awake ()
	{
		
	}

	public void Use ()
	{
		
	}

	public void OnPickup ()
	{
		print (this.ToString () + " OnPickup()");
	}

	public void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.GetComponent<Inventory> () != null) {
			collider.GetComponent<Inventory> ().Items.Add (this);
			this.gameObject.transform.SetParent (collider.gameObject.transform);
			this.gameObject.transform.position = collider.gameObject.transform.position;
			this.OnPickup ();
		}
	}

	public bool IsEquipped ()
	{
		return false;
	}

	#endregion
	
}
