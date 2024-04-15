using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScreenFontSize : MonoBehaviour
{
	[SerializeField]
	private int m_fontSize_3x4 = 100;

	private void Awake()
	{
		bool flag = false;
		if (Screen.width > Screen.height)
		{
			if ((float)Screen.width / (float)Screen.height < 1.45f)
			{
				flag = true;
			}
		}
		else if ((float)Screen.height / (float)Screen.width < 1.45f)
		{
			flag = true;
		}
		if (flag)
		{
			base.GetComponent<Text>().fontSize = this.m_fontSize_3x4;
		}
	}
}


