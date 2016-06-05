using UnityEngine;
using System.Collections;

public class ObjectPath : MonoBehaviour
{
	public float travelTime = 2.0f;
	public Transform[] path;

	public void GoTo(GameObject self = null) {
		StartCoroutine (Go(self ?? this.gameObject));
	}

	IEnumerator Go (GameObject self)
	{
		foreach (var xform in path) {
			var start = self.gameObject.transform.position;
			var dest = xform.position;
			var time = 0f;

			while (time < travelTime) {

				time += Time.deltaTime;
				var newPos = Vector3.Lerp (start, dest, time / this.travelTime);
				self.gameObject.transform.position = newPos;
				yield return new WaitForEndOfFrame ();
			}
		}
		self.gameObject.transform.position = path[path.Length - 1].position;
	}

	void OnDrawGizmos ()
	{
		if (path == null) {
			return;
		}

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