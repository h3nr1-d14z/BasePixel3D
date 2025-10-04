using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AspectRatioFitter))]
public class ScreenFormatAspectRatioFitter : MonoBehaviour
{
	[SerializeField]
	private float m_aspectRation4_3 = 100f;

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
			base.GetComponent<AspectRatioFitter>().aspectRatio = this.m_aspectRation4_3;
		}
	}
}


