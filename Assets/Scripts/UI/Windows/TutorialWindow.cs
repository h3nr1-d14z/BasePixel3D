using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialWindow : BaseWindow
{
	private int m_currentIndex;

	private string m_placement = string.Empty;

	private string m_type = string.Empty;

	[SerializeField]
	private PositScrollRect m_positScrollRect;

	[SerializeField]
	private List<TutorialPage> m_pages;

	[SerializeField]
	private List<Image> m_points;

	protected override string WindowName
	{
		get
		{
			return "tutorialWindow";
		}
	}

	private void Awake()
	{
		PositScrollRect positScrollRect = this.m_positScrollRect;
		positScrollRect.OnSelectIndex = (Action<int>)Delegate.Combine(positScrollRect.OnSelectIndex, new Action<int>(this.OnSelectIndexHandler));
	}

	public void Init(string placement, string type)
	{
		this.m_currentIndex = 0;
		this.m_placement = placement;
		this.m_type = type;
		foreach (TutorialPage page in this.m_pages)
		{
			((RectTransform)page.transform).sizeDelta = new Vector2(((RectTransform)base.transform).rect.width, ((RectTransform)base.transform).rect.height);
		}
		this.m_positScrollRect.Reinit(0f, false);
		// AnalyticsManager.Instance.TutorOpened(placement, type);
		this.UpdatePoint();
		 
		AppData.TutorialCompleted = true; 
	}

	private void OnSelectIndexHandler(int index)
	{
		if (this.m_currentIndex != index)
		{
			if (this.m_currentIndex < this.m_pages.Count && this.m_currentIndex >= 0)
			{
				this.m_pages[this.m_currentIndex].Stop();
			}
			this.m_currentIndex = index;
			if (this.m_currentIndex < this.m_pages.Count && this.m_currentIndex >= 0)
			{
				this.m_pages[this.m_currentIndex].Play();
			}
			this.UpdatePoint();
		}
	}

	private void UpdatePoint()
	{
		if (this.m_currentIndex < this.m_pages.Count && this.m_currentIndex >= 0)
		{
			for (int i = 0; i < this.m_pages.Count; i++)
			{
				if (i == this.m_currentIndex)
				{
					this.m_points[i].SetAlpha(1f);
				}
				else
				{
					this.m_points[i].SetAlpha(0.3f);
				}
			}
		}
	}

	public void CloseButtonClick()
	{
		// AnalyticsManager.Instance.TutorClosed(this.m_placement, this.m_type, this.m_currentIndex + 1);
		WindowManager.Instance.CloseMe(this);
		AudioManager.Instance.PlayClick();
	}

	public void StartButtonClick()
	{
		// AnalyticsManager.Instance.TutorClosed(this.m_placement, this.m_type, this.m_currentIndex + 1);
		WindowManager.Instance.CloseMe(this);
		AudioManager.Instance.PlayClick();
	}

	private void OnDestroy()
	{
		PositScrollRect positScrollRect = this.m_positScrollRect;
		positScrollRect.OnSelectIndex = (Action<int>)Delegate.Remove(positScrollRect.OnSelectIndex, new Action<int>(this.OnSelectIndexHandler));
	}
}


