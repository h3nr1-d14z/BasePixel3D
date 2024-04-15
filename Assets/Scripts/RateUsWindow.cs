using System;
using UnityEngine;

public class RateUsWindow : MonoBehaviour
{
	private Action m_closeHandler;

	public static bool NeedShow(RateUsReason reason)
	{
		return false;
	}

	public void Init(Action closeHandler)
	{
		this.m_closeHandler = closeHandler;
		base.gameObject.SetActive(true);
		AppData.AddNewRateUsView();
	}

	public void YesButtonClick()
	{
		RateUsTool.OpenRateUs();
		AppData.AppRated = true;
	}

	public void Close()
	{
		base.gameObject.SetActive(false);
		this.m_closeHandler.SafeInvoke();
		this.m_closeHandler = null;
	}
}


