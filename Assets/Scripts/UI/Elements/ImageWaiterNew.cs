using UnityEngine;

public class ImageWaiterNew : MonoBehaviour
{
	private float m_angle;

	[SerializeField]
	private Transform m_image;

	private void Update()
	{
		if (this.m_angle <= 10f)
		{
			this.m_angle += 360f;
		}
		if (this.m_angle < 90f)
		{
			this.m_angle -= Mathf.Min(0.05f, Time.deltaTime) * this.m_angle * 3f;
		}
		else
		{
			this.m_angle -= Mathf.Min(0.05f, Time.deltaTime) * 270f;
		}
		Quaternion rotation = this.m_image.rotation;
		rotation.eulerAngles = new Vector3(0f, 0f, this.m_angle);
		this.m_image.rotation = rotation;
	}
}


