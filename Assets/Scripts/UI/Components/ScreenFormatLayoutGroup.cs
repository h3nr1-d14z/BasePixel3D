using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HorizontalOrVerticalLayoutGroup))]
internal class ScreenFormatLayoutGroup : MonoBehaviour
{
	[SerializeField]
	private float m_spacing4_3;

	private void Awake()
	{
		bool flag = false;
		if (Screen.width > Screen.height)
		{
			if ((float)Screen.width / (float)Screen.height < 1.55f)
			{
				flag = true;
			}
		}
		else if ((float)Screen.height / (float)Screen.width < 1.55f)
		{
			flag = true;
		}
		if (flag)
		{
			base.GetComponent<HorizontalOrVerticalLayoutGroup>().spacing = this.m_spacing4_3;
		}
	}
}


