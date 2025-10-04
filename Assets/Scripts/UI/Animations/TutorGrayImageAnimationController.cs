using UnityEngine;

public class TutorGrayImageAnimationController : MonoBehaviour
{
	[SerializeField]
	private Material m_material;

	[SerializeField]
	private float m_alpha = 1f;

	private void Update()
	{
		this.m_material.SetFloat("_Alpha", this.m_alpha);
	}
}


