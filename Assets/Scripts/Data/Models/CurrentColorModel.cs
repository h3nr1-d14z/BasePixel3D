using System;
using UnityEngine;

public class CurrentColorModel
{
	public Action<CurrentColorModel, bool> OnStateChanged;

	public Color Color { get; private set; }

	public void UpdateColor(Color color)
	{
		this.Color = color;
		this.OnStateChanged.SafeInvoke(this, true);
	}
}


