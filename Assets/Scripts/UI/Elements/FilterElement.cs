using System;
using UnityEngine;
using UnityEngine.UI;

public class FilterElement : MonoBehaviour
{
	public Action<FilterElement> OnClick;

	[SerializeField]
	private LayoutElement m_layoutElement;

	[SerializeField]
	private RawImage m_image;

	[SerializeField]
	private RawImage m_dark;

	public int FilterIndex { get; private set; }

	public void Init(FilterInfo info)
	{
		this.m_image.texture = info.Texture;
		this.FilterIndex = info.FilterIndex;
	}

	public void InitEmpty(Texture2D tex)
	{
		this.m_image.texture = tex;
		this.m_image.material = null;
		this.FilterIndex = 0;
	}

	public void Click()
	{
		this.OnClick.SafeInvoke(this);
	}

	public void Scale(float scale, float maxScale)
	{
		float a = scale / maxScale;
		a = Mathf.Min(a, 1f);
		this.m_layoutElement.preferredWidth = 150f * a;
		this.m_layoutElement.minWidth = 150f * a;
		((RectTransform)base.transform).sizeDelta = 150f * new Vector2(a, a);
		this.m_dark.SetAlpha(1f - a);
	}
}


