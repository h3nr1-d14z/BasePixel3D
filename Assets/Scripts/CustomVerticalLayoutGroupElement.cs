using UnityEngine;

public class CustomVerticalLayoutGroupElement : MonoBehaviour
{
	[SerializeField]
	private int m_siblingIndex;

	public int SiblingIndex
	{
		get
		{
			return this.m_siblingIndex;
		}
	}

	private void Awake()
	{
		base.transform.SetAsLastSibling();
	}
}


