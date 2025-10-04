using UnityEngine;
using UnityEngine.UI;

public class BackgroundTileController : MonoBehaviour
{
	private RectTransform m_rectTransform;

	private Rect m_rect = default(Rect);

	private Image m_image;

	[SerializeField]
	private float m_elementSize = 512f;

	private void Awake()
	{
		this.m_rectTransform = (RectTransform)base.transform;
		this.m_image = base.GetComponent<Image>();
		this.m_image.material = new Material(Shader.Find("Custom/TilingShader"));
	}

	private void Update()
	{
		Rect rect = this.m_rectTransform.rect;
		if (rect != this.m_rect)
		{
			this.m_rect = rect;
			this.m_image.material.mainTextureScale = new Vector2(rect.width / this.m_elementSize, rect.height / this.m_elementSize);
		}
	}
}


