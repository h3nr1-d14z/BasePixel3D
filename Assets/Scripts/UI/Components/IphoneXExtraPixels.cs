

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IphoneXExtraPixels : MonoBehaviour
{
	private Vector2 m_sizeDelta = Vector2.zero;

	[SerializeField]
	private RectTransform m_canvas;

	private LayoutElement m_layoutElement;

	private float m_pixels;

	[SerializeField]
	private bool m_bottom;

	public float Height { get; private set; }

	private void Awake()
	{
		base.StartCoroutine(this.InitCoroutine());
		this.m_layoutElement = base.GetComponent<LayoutElement>();
	}

	private void UpdateVisibility()
	{
		if (this.m_pixels == 0f)
		{
			(base.transform as RectTransform).sizeDelta = Vector2.zero;
			if (this.m_layoutElement != null)
			{
				LayoutElement layoutElement = this.m_layoutElement;
				float num = 0f;
				this.m_layoutElement.preferredHeight = num;
				layoutElement.minHeight = num;
			}
		}
		else
		{
			(base.transform as RectTransform).sizeDelta = this.m_sizeDelta;
			if (this.m_layoutElement != null)
			{
				LayoutElement layoutElement2 = this.m_layoutElement;
				float num = 0f;
				this.m_layoutElement.preferredHeight = num;
				layoutElement2.minHeight = num;
			}
			if (this.m_layoutElement != null)
			{
				LayoutElement layoutElement3 = this.m_layoutElement;
				float num = this.m_sizeDelta.y;
				this.m_layoutElement.preferredHeight = num;
				layoutElement3.minHeight = num;
			}
		}
	}

	private IEnumerator InitCoroutine()
	{
		yield return null;
		 
		this.m_pixels = ((!this.m_bottom) ? ScreenToolWrapper.IphoneXExtraPixels : ScreenToolWrapper.IphoneXExtraBottomPixels);
		this.Height = this.m_pixels / (float)Screen.height * this.m_canvas.rect.height * ScreenToolWrapper.Density;
		this.m_sizeDelta = new Vector2(0f, this.Height);
		this.UpdateVisibility();
	}
}
