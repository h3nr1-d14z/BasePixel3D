using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorImage : MonoBehaviour
{
	public Action<ColorImage> OnClick;

	[SerializeField]
	private Image m_image;

	[SerializeField]
	private Text m_title;

	[SerializeField]
	private Image m_mark;

	public Color Color { get; private set; }

	public int ColorIndex { get; private set; }

	public void Init(Color color, int number)
	{
		this.Color = color;
		this.m_image.color = color;
		this.ColorIndex = number;
		this.m_title.text = number.ToString();
		this.m_title.color = ((!color.IsDark()) ? Color.black : Color.white);
		this.m_mark.color = ((!color.IsDark()) ? Color.black : Color.white);
	}

	public void Select()
	{
		this.m_title.transform.localScale = new Vector2(1.5f, 1.5f);
	}

	public void Unselect()
	{
		this.m_title.transform.localScale = new Vector2(1f, 1f);
	}

	public void Click()
	{
		this.OnClick.SafeInvoke(this);
		AudioManager.Instance.PlayClick();
	}

	public void Disable()
	{
		this.m_image.SetAlpha(0.5f);
		this.m_title.gameObject.SetActive(false);
		this.m_mark.gameObject.SetActive(true);
		((Component)this.m_image).GetComponent<Button>().enabled = false;
	}
}


