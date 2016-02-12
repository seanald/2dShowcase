using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{

	private List<Pickup> items;

	void Start ()
	{
		items = new List<Pickup> ();
	}

	void Update ()
	{
		if (this.items.Count > 0) {
			print (this.items [0].ToString ());
		}
	}

	public List<Pickup> Items {
		get {
			return items;
		}
		set {
			items = value;
		}
	}
}
