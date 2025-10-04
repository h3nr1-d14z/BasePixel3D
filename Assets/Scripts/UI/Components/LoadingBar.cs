

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
	[SerializeField]
	private List<Image> m_images;

	[SerializeField]
	private List<Color> m_colors;

	[SerializeField]
	private float m_deltaTime = 1f;

	private void Start()
	{
		this.StartBar();
		if (this.m_images.Count != this.m_colors.Count)
		{
			UnityEngine.Debug.LogError("LoadingBar: wrong parameters! Images.Count != Colors.Count");
		}
		else
		{
			for (int i = 0; i < this.m_images.Count; i++)
			{
				this.m_images[i].color = this.m_colors[i];
			}
		}
	}

	public void StartBar()
	{
		base.gameObject.SetActive(true);
		base.StartCoroutine(this.BarCoroutine());
	}

	private void Update()
	{
		float num = Mathf.Min(0.05f, Time.deltaTime);
		base.transform.Rotate(0f, 0f, num * 360f);
	}
	private IEnumerator BarCoroutine()
	{
		int step = 0;
		int index = 0;
		while (true)
		{
			step++;
			if (step > this.m_images.Count)
			{
				step -= this.m_images.Count;
			}
			for (int i = 0; i < this.m_images.Count; i++)
			{
				index = i - step;
				if (index < 0)
				{
					index += this.m_images.Count;
				}
				this.m_images[i].color = this.m_colors[index];
			}
			yield return new WaitForSeconds(this.m_deltaTime);
		}
	}
}
