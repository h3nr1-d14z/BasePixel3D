using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyArtWindow : BaseWindow
{
	protected override string WindowName
	{
		get
		{
			return "daily_art";
		}
	} 

	public void CloseWindow()
	{
		AudioManager.Instance.PlayClick();
		base.Close();
	}
}
