

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersBlock : MonoBehaviour
{
	[SerializeField]
	private GameObject m_numberPrefab;

	[SerializeField]
	private GameObject m_content;

	public bool Inited { get; private set; }

	public void Init(int width, int height, Vector2 delta, Color[] values, int fullWidth, int startX, int startY, List<Color> colors)
	{
		this.Inited = true;
		Transform transform = this.m_content.transform;
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				float x = delta.x * ((float)i + 0.55f);
				float y = delta.y * ((float)j + 0.5f);
				GameObject gameObject = Object.Instantiate(this.m_numberPrefab);
				Transform transform2 = gameObject.transform;
				transform2.SetParent(transform);
				transform2.localScale = Vector3.one;
				transform2.localPosition = new Vector2(x, y);
				TextMesh component = gameObject.GetComponent<TextMesh>();
				component.text = colors.IndexOf(values[startX + i + (startY + j) * fullWidth]).ToString();
				component.characterSize = 0.125f * Mathf.Max(delta.x, delta.y);
			}
		}
	}

	private void OnBecameInvisible()
	{
		this.m_content.SetActive(false);
	}
	private IEnumerator OnBecameVisible()
	{
		yield return null;
		this.m_content.SetActive(true);
		yield return null;
	}
}

