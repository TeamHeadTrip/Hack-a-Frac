using UnityEngine;
using System.Collections;

public class BurstApartWhenSliced : AbstractSliceHandler
{
	public float burstForce = 1;

	public override void handleSlice (GameObject[] results)
	{
		var centers = new Vector3[results.Length];

		for (int i = 0; i < results.Length; ++i) {
			centers[i] = results[i].GetComponent<Collider> ().bounds.center;
			Debug.Log(centers[i]);
		}

		var center = Vector3.zero;
		for (int i = 0; i < results.Length; ++i) {
			center += centers[i];
		}
		center /= (float)centers.Length;

		for (int i = 0; i < results.Length; ++i) {
			var go = results[i];
			var rb = go.GetComponent<Rigidbody> ();
			if (rb != null) {
				var v = centers[i] - center;
				v.Normalize ();
				v *= burstForce;
				rb.AddForce (v, ForceMode.Impulse);
			}
		}
	}
}
