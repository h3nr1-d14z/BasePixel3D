using UnityEngine;

public class ObjectDependsOnEnother : MonoBehaviour
{
	private bool prevValue = true;

	[SerializeField]
	private GameObject m_content;

	[SerializeField]
	private MonoBehaviour m_targetObject;

	private void Update()
	{
		bool isActiveAndEnabled = this.m_targetObject.isActiveAndEnabled;
		if (this.prevValue != isActiveAndEnabled)
		{
			this.prevValue = isActiveAndEnabled;
			this.m_content.SetActive(isActiveAndEnabled);
		}
	}
}


