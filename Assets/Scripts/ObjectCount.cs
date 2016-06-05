using UnityEngine;
using System.Collections.Generic;

public class ObjectCount : MonoBehaviour
{
	public int Count {
		get {
			int count = 0;
			foreach (var item in inside) {
				if (item != null) {
					count++;
				}
			}
			return count;
		}
	}

	public List<GameObject> inside = new List<GameObject> ();

	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Piece") {
			inside.Add(collider.gameObject);
		}
	}

	void OnTriggerExit (Collider collider)
	{
		if (collider.tag == "Piece") {
			inside.Remove(collider.gameObject);
		}
	}
}
