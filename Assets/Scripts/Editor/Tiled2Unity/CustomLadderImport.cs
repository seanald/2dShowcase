using UnityEngine;
using UnityEngine;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Tiled2Unity.CustomTiledImporter]
public class CustomLadderImport : Tiled2Unity.ICustomTiledImporter
{

	#region ICustomTiledImporter implementation

	public void HandleCustomProperties (GameObject gameObject, System.Collections.Generic.IDictionary<string, string> customProperties)
	{
		throw new System.NotImplementedException ();
	}

	public void CustomizePrefab (GameObject prefab)
	{
		Debug.Log ("Custom Ladders");
		// Find all the polygon colliders in the pefab
		var polygon2Ds = prefab.GetComponentsInChildren<PolygonCollider2D> ();
		if (polygon2Ds == null)
			return;

		Debug.Log ("Ladders Found");
		// Find all *ladder* polygon colliders
		int ladderMask = LayerMask.NameToLayer ("Ladder");
		var ladderPolygons = from polygon in polygon2Ds
		                     where polygon.gameObject.layer == ladderMask
		                     select polygon;


		// For each ladder path in a ladder polygon collider
		// add a top, spine, and bottom edge collider
		foreach (var poly in ladderPolygons) {
			GameObject ladderSpines = new GameObject ("LadderSpine-EdgeColliders");
			ladderSpines.layer = LayerMask.NameToLayer ("Ladder");

			// Create edge colliders for the ladder tops
			// We assume that every polygon path represents a ladder
			for (int p = 0; p < poly.pathCount; ++p) {
				Vector2[] points = poly.GetPath (p);

				float xmin = points.Min (pt => pt.x);
				float xmax = points.Max (pt => pt.x);
				float ymax = points.Max (pt => pt.y);
				float ymin = points.Min (pt => pt.y);
				float xcen = xmin + (xmax - xmin) * 0.5f;

				Debug.Log (xmin + xmax);
				// Add our edge collider points for the ladder spine
				EdgeCollider2D spineEdgeCollider2d =
					ladderSpines.AddComponent<EdgeCollider2D> ();
				spineEdgeCollider2d.points = new Vector2[] {
					new Vector2 (xcen, ymin),
					new Vector2 (xcen, ymax),
				};

			}

			// Parent the ladder components to our ladder object
			ladderSpines.transform.parent = poly.gameObject.transform;
		}
	}

	#endregion


}
