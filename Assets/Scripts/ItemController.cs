using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {

	public int numerator = 1;
	public int denominator = 1;

	public void StartLevel (Transform xform) {
		StartCoroutine (MoveTo (xform));
		this.tag = "Piece";
	}

	IEnumerator MoveTo (Transform xform)
	{
		var travelTime = 1f;
		var start = this.gameObject.transform.position;
		var dest = xform.position;
		var time = 0f;

		while (time < travelTime) {
			time += Time.deltaTime;
			var newPos = Vector3.Lerp (start, dest, time / travelTime);
			this.gameObject.transform.position = newPos;
			yield return new WaitForEndOfFrame ();
		}
		this.gameObject.transform.position = dest;
	}

	public void EndLevel ()
	{
		var pieces = GameObject.FindGameObjectsWithTag ("Piece");
		foreach (var piece in pieces) {
			GameObject.Destroy (piece);
		}
	}
}
