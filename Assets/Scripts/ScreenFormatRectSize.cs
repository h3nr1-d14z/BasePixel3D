

using UnityEngine;
using UnityEngine.UI;

internal class ScreenFormatRectSize : MonoBehaviour
{
	private int taktsCounter;

	[SerializeField]
	private float m_forceWidth4_3 = 100f;

	[SerializeField]
	private float m_forceHeight4_3 = 100f;

	[SerializeField]
	private int m_takts;

	private void Awake()
	{
	}

	private void Update()
	{
		if (this.taktsCounter < this.m_takts)
		{
			this.taktsCounter++;
		}
		else
		{
			bool flag = false;
			if (Screen.width > Screen.height)
			{
				if ((float)Screen.width / (float)Screen.height < 1.51f)
				{
					flag = true;
				}
			}
			else if ((float)Screen.height / (float)Screen.width < 1.51f)
			{
				flag = true;
			}
			if (flag)
			{
				RectTransform rectTransform = base.transform as RectTransform;
				Vector2 anchorMin = rectTransform.anchorMin;
				Vector2 anchorMax = rectTransform.anchorMax;
				RectTransform rectTransform2 = rectTransform;
				Vector2 vector3 = rectTransform2.anchorMax = (rectTransform.anchorMin = new Vector2(0.5f, 0.5f));
				rectTransform.sizeDelta = new Vector2(this.m_forceWidth4_3, this.m_forceHeight4_3);
				rectTransform.anchorMin = anchorMin;
				rectTransform.anchorMax = anchorMax;
				LayoutElement component = base.GetComponent<LayoutElement>();
				if (component != null)
				{
					component.preferredWidth = this.m_forceWidth4_3;
					component.minWidth = this.m_forceWidth4_3;
					component.preferredHeight = this.m_forceHeight4_3;
					component.minHeight = this.m_forceHeight4_3;
				}
			}
			base.enabled = false;
		}
	}
}


