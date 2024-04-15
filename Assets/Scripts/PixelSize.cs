

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelSize : MonoBehaviour
{
	[SerializeField]
	private RectTransform m_canvas;

	[SerializeField]
	private float m_pixels;

	private void Awake()
	{
		base.StartCoroutine(this.InitCoroutine());
	}
	private IEnumerator InitCoroutine()
	{
		yield return null;
		 
		var size = this.m_pixels * ScreenToolWrapper.Density * 1.777778f / (this.m_canvas.rect.height / this.m_canvas.rect.width);
		var sizeDelta = new Vector2(size, size);
		(this.transform as RectTransform).sizeDelta = sizeDelta;
	}
}
