using UnityEngine;

public class SetRectAsTarget : MonoBehaviour
{
	[SerializeField]
	private RectTransform m_target;

	private void Start()
	{
		Rect rect = ((RectTransform)this.m_target.transform).rect;
		RectTransform rectTransform = (RectTransform)base.transform;
		rectTransform.sizeDelta = new Vector2(rect.width, rect.height);
		rectTransform.anchoredPosition = rect.center;
	}
}


