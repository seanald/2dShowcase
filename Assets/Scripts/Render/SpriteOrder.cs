using UnityEngine;
using System.Collections;

public class SpriteOrder : MonoBehaviour {

	private float xPosition;
	private float yPosition;

	void LateUpdate()
	{
		this.xPosition = transform.position.x;
		this.yPosition = transform.position.y;

		transform.position = new Vector3 (this.xPosition, this.yPosition, this.yPosition);
	}

}
