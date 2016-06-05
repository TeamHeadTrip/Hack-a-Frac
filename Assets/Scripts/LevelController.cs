using UnityEngine;
using System.Collections.Generic
;

public class LevelController : MonoBehaviour
{
	public List<ItemController> items;

	public Transform hoverPos;

	private ItemController currentItem;

	void Start ()
	{
		StartLevel ();
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (CheckLevel ()) {
				StartLevel ();
			}
		}
	}

	void StartLevel ()
	{
		if (items.Count > 0) {
			currentItem = items[0];
			currentItem.StartLevel (hoverPos);

			items.RemoveAt(0);
		}
	}

	bool CheckLevel ()
	{
		// Check if completed, if so...
		if (currentItem != null) {
			currentItem.EndLevel();
			return true;
		}
		return false;
	}
}
