using UnityEngine;
using UnityEngine.UI;

public class SetPrefferedHeightByChild : MonoBehaviour
{
	private float m_size;

	[SerializeField]
	private RectTransform m_childRectTransform;

	private void Update()
	{
		if (this.m_childRectTransform.rect.height != this.m_size)
		{
			this.m_size = this.m_childRectTransform.rect.height;
			base.GetComponent<LayoutElement>().preferredHeight = this.m_size;
		}
	}
}


