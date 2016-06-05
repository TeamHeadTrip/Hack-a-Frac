using UnityEngine;
using System.Collections;

public class Wand : MonoBehaviour {

	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Piece") {
			collider.GetComponent<ObjectPath> ().GoTo ();
		}
	}
}
