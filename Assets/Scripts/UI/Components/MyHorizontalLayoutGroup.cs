using System.Collections.Generic;
using UnityEngine;

public class MyHorizontalLayoutGroup : MonoBehaviour
{
	private float m_fullLength;

	private void Start()
	{
		this.Reinit();
	}

	private void Update()
	{
		if (this.m_fullLength != ((RectTransform)base.transform).rect.width)
		{
			this.Reinit();
		}
	}

	private void Reinit()
	{
		List<RectTransform> list = new List<RectTransform>();
		for (int i = 0; i < base.transform.childCount; i++)
		{
			RectTransform rectTransform = (RectTransform)base.transform.GetChild(i);
			if (rectTransform.gameObject.activeSelf)
			{
				list.Add(rectTransform);
			}
		}
		this.m_fullLength = ((RectTransform)base.transform).rect.width;
		float num = this.m_fullLength / (float)(list.Count + 1);
		for (int j = 0; j < list.Count; j++)
		{
			list[j].anchoredPosition = new Vector2(num * (float)(j + 1), 0f);
		}
	}
}


