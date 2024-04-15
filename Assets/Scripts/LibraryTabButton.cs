using UnityEngine;
using UnityEngine.UI;

public class LibraryTabButton : MonoBehaviour
{
	[SerializeField]
	private Image m_image;

	[SerializeField]
	private Sprite m_activeSprite;

	[SerializeField]
	private Sprite m_nonactiveSprite;

	[SerializeField]
	private Text m_text;

	[SerializeField]
	private Color m_activeColor = Color.white;

	[SerializeField]
	private Color m_nonactiveColor = Color.white;

	public void SetHighlighted(bool value)
	{
		this.m_image.sprite = ((!value) ? this.m_nonactiveSprite : this.m_activeSprite);
		this.m_text.color = ((!value) ? this.m_nonactiveColor : this.m_activeColor);
	}
}


