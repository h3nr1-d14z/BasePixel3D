

using UnityEngine;
using UnityEngine.UI;

public class ColorPointer : MonoBehaviour
{
	private ColorImage m_colorImage;

	[SerializeField]
	private Image m_image;

	[SerializeField]
	private GameObject m_iphoneXAngle;

	public void UpdateColor(ColorImage colorImage, SpecialColorPosition pos)
	{
		if (this.m_colorImage != null)
		{
			this.m_colorImage.Unselect();
		}
		this.m_colorImage = colorImage;
		this.m_colorImage.Select();
		base.transform.SetParent(colorImage.transform);
		((RectTransform)base.transform).sizeDelta = Vector2.zero;
		((RectTransform)base.transform).anchoredPosition = Vector2.zero;
		this.m_iphoneXAngle.SetActive(false);
	}
}


