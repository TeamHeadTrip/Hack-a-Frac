using UnityEngine;
using System.Collections.Generic
;

public class LevelController : MonoBehaviour
{
	public List<ItemController> items;

	public Transform hoverPos;

	private ItemController currentItem;
	private ObjectCount count;

	void Start ()
	{
		StartLevel ();
	}

	void Update ()
	{
		if (CheckLevel ()) {
			StartLevel ();
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
		var levelCompleted = count.Count >= currentItem.numerator;

		if (levelCompleted) {
			currentItem.EndLevel();
			return true;
		}
		return false;
	}
}
