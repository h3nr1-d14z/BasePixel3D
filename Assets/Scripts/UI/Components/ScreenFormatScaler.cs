using UnityEngine;

internal class ScreenFormatScaler : MonoBehaviour
{
	[SerializeField]
	private float m_forceScaleX = 1f;

	[SerializeField]
	private float m_forceScaleY = 1f;

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
			base.transform.localScale = new Vector3(this.m_forceScaleX, this.m_forceScaleY, 1f);
		}
	}
}


