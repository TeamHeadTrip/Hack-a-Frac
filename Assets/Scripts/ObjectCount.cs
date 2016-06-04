using UnityEngine;
using System.Collections.Generic;

public class ObjectCount : MonoBehaviour
{
	public int Count {
		get { return inside.Count; }
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
