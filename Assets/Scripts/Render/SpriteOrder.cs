using UnityEngine;
using System.Collections;

public class SpriteOrder : MonoBehaviour {

	private float xPosition;
	private float yPosition;
	private SpriteRenderer spriteRenderer;

	void Awake()
	{
		this.spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	void LateUpdate()
	{
		if (this.spriteRenderer != null) {
			this.spriteRenderer.sortingOrder = Mathf.RoundToInt (transform.position.y * 100f) * -1;
		}
	}

}
