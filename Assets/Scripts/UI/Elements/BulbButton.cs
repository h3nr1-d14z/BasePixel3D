using UnityEngine;
using UnityEngine.UI;

public class BulbButton : MonoBehaviour
{
	[SerializeField]
	private GameObject m_highlightedGrid;

	[SerializeField]
	private Image m_image;

	[SerializeField]
	private Sprite m_enableSprite;

	[SerializeField]
	private Sprite m_disableSprite;

	private void Start()
	{
		this.UpdateState();
	}

	public void Click()
	{
		AppData.BulbMode = !AppData.BulbMode;
		this.UpdateState();
	}

	private void UpdateState()
	{
		this.m_image.sprite = ((!AppData.BulbMode) ? this.m_disableSprite : this.m_enableSprite);
		this.m_highlightedGrid.SetActive(AppData.BulbMode);
	}
}


