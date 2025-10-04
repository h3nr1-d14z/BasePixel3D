

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switcher : MonoBehaviour
{
	[SerializeField]
	private float m_switchDelta = 100f;

	[SerializeField]
	private RectTransform m_pointer;

	[SerializeField]
	private Image m_background;

	[SerializeField]
	private Color m_onColor = Color.green;

	[SerializeField]
	private Color m_offColor = Color.gray;

	public bool Value { get; private set; }

	public void UpdateState(bool value, bool fast)
	{
		if (this.Value == value && !fast)
		{
			return;
		}
		this.Value = value;
		base.StopAllCoroutines();
		if (fast)
		{
			this.m_pointer.anchoredPosition = new Vector2((!this.Value) ? (0f - this.m_switchDelta) : this.m_switchDelta, 0f);
			this.m_background.color = ((!this.Value) ? this.m_offColor : this.m_onColor);
		}
		else
		{
			base.StartCoroutine(this.UpdateStateCoroutine());
		}
	}
	private IEnumerator UpdateStateCoroutine()
	{
		var time = 0.1f;
		var speed = ((!Value) ? (0f - m_switchDelta) : m_switchDelta) * 2f / time; 
		var sign = (this.m_pointer.anchoredPosition.x > ((!this.Value) ? (0f - this.m_switchDelta) : this.m_switchDelta)); 
		var zeroSign = (this.m_pointer.anchoredPosition.x > 0f);
		yield return null;

		while (true)
		{
			var deltaTime = Mathf.Min(Time.deltaTime, 0.05f); 
			var newZeroSign = (this.m_pointer.anchoredPosition.x > 0f);
			if (zeroSign != newZeroSign)
			{
				this.m_background.color = ((!this.Value) ? this.m_offColor : this.m_onColor);
			} 
			var newSign = (this.m_pointer.anchoredPosition.x + speed * deltaTime > ((!this.Value) ? (0f - this.m_switchDelta) : this.m_switchDelta));
			if (newSign != sign)
			{
				this.m_pointer.anchoredPosition = new Vector2((!this.Value) ? (0f - this.m_switchDelta) : this.m_switchDelta, 0f);
				yield break;
			} 
			this.m_pointer.anchoredPosition += new Vector2(speed * deltaTime, 0f);
			yield return null;
		}
	}
}
