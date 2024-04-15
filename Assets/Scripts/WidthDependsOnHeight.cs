

using UnityEngine;
using UnityEngine.UI;

public class WidthDependsOnHeight : MonoBehaviour
{
	[SerializeField]
	private string m_expression;

	private RectTransform m_rectTransform;

	private float m_height = -1f;

	private void Start()
	{
		this.m_rectTransform = (RectTransform)base.transform;
		this.UpdateWidth();
	}

	private void Update()
	{
		if (this.m_rectTransform.rect.height != this.m_height)
		{
			this.UpdateWidth();
			base.enabled = false;
		}
	}

	private void UpdateWidth()
	{
		this.m_height = this.m_rectTransform.rect.height;
		float height = this.m_height;
		Vector2 sizeDelta = this.m_rectTransform.sizeDelta;
		sizeDelta.x = height;
		this.m_rectTransform.sizeDelta = sizeDelta;
		LayoutElement component = base.GetComponent<LayoutElement>();
		if (component != null)
		{
			LayoutElement layoutElement = component;
			component.preferredWidth = height; float num3 = layoutElement.minWidth = (component.preferredWidth);
		}
	}
}


