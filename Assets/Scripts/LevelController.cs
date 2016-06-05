using UnityEngine;
using System.Collections.Generic
;

public class LevelController : MonoBehaviour
{
	public List<ItemController> items;
	public ObjectCount pot;

	public Transform hoverPos;

	private ItemController currentItem;

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
		if (currentItem != null) {
			var levelCompleted = pot.Count >= currentItem.numerator;

			if (levelCompleted) {
				currentItem.EndLevel();
				return true;
			}
		}
		return false;
	}
}
