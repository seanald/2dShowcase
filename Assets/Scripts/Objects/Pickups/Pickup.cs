using UnityEngine;
using System.Collections;

public interface Pickup
{
	void Awake ();

	void Use ();

	void OnPickup ();

	void OnTriggerEnter2D (Collider2D collider);

	bool IsEquipped ();
}
