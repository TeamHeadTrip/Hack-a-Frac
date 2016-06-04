﻿using UnityEngine;
using System.Collections;

public class ObjectPath : MonoBehaviour
{
	public float travelTime = 2.0f;
	public Transform[] path;

	IEnumerator Go ()
	{
		foreach (var xform in path) {
			var start = this.gameObject.transform.position;
			var dest = xform.position;
			var time = 0f;

			while (time < travelTime) {

				time += Time.deltaTime;
				var newPos = Vector3.Lerp (start, dest, time / this.travelTime);
				this.gameObject.transform.position = newPos;
				yield return new WaitForEndOfFrame ();
			}
		}
		this.gameObject.transform.position = path[path.Length - 1].position;
	}

	void OnDrawGizmos ()
	{
		Gizmos.color = new Color (1, 0, 1, .5f);

		if (path.Length > 0) {
			var start = gameObject.transform.position;
			var end = path[0].transform.position;
			Gizmos.DrawLine (start, end);
		}

		for(int i = 1; i < path.Length; i++) {
			var start = path[i-1].transform.position;
			var end = path[i].transform.position;
			Gizmos.DrawLine (start, end);
		}
	}
}