using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class LongTapReceiver : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
{
	private DateTime m_downTime = DateTime.MaxValue;

	[SerializeField]
	private float m_duration = 1f;

	public void OnPointerDown(PointerEventData eventData)
	{
		this.m_downTime = DateTime.Now;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if ((DateTime.Now - this.m_downTime).TotalSeconds > (double)this.m_duration)
		{
			DebugController.Instance.ClickDebugTexts();
		}
	}
}


