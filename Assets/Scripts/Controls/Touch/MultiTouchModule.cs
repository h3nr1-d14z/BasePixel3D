using System.Collections.Generic;
using UnityEngine;

internal class MultiTouchModule : MonoBehaviour
{
	private void Update()
	{
		List<Touch> list = new List<Touch>();
		for (int i = 0; i < Input.touchCount; i++)
		{
			Touch touch = Input.GetTouch(i);
			list.Add(touch);
		}
		List<Touch> list2 = new List<Touch>();
		foreach (Touch item in list)
		{
			if (item.fingerId < 2)
			{
				list2.Add(item);
			}
		}
		list2.Sort((Touch a, Touch b) => a.fingerId.CompareTo(b.fingerId));
		if (list2.Count != 0 && list2.Count > 1)
		{
			Vector2 vector = list2[0].position - list2[0].deltaPosition - (list2[1].position - list2[1].deltaPosition);
			float num = Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y);
			Vector2 vector2 = list2[0].position - list2[1].position;
			float num2 = Mathf.Sqrt(vector2.x * vector2.x + vector2.y * vector2.y);
		}
	}
}


