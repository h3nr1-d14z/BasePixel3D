using UnityEngine;

public class ScreenFormatPos : MonoBehaviour
{
	[SerializeField]
	private Vector2 m_pos_4x3 = Vector2.zero;

	private void Awake()
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
			((RectTransform)base.transform).anchoredPosition = this.m_pos_4x3;
		}
	}
}


