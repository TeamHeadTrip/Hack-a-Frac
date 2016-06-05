using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {

	public int numerator = 1;
	public int denominator = 1;

	public ObjectPath path;

	public void StartLevel (Transform xform) {
		path.GoTo(this.gameObject);
		this.tag = "Piece";
	}

	public void EndLevel ()
	{
		var pieces = GameObject.FindGameObjectsWithTag ("Piece");
		foreach (var piece in pieces) {
			GameObject.Destroy (piece);
		}
	}
}
