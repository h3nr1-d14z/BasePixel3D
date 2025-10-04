using UnityEngine;

public class ScreenFormatScale : MonoBehaviour
{
	[SerializeField]
	private float m_9x16Scale = 1f;

	[SerializeField]
	private float m_3x4Scale = 1f;

	private void Start()
	{
		float num = (float)Screen.height / (float)Screen.width;
		float num2 = Mathf.Lerp(this.m_3x4Scale, this.m_9x16Scale, (num - 1.33f) / 0.449999928f);
		base.transform.localScale = new Vector3(num2, num2, 1f);
	}
}


