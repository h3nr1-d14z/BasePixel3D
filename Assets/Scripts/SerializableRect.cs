using System;
using UnityEngine;

[Serializable]
public class SerializableRect
{
	public float X { get; set; }

	public float Y { get; set; }

	public float Width { get; set; }

	public float Height { get; set; }

	public SerializableRect(Rect rect)
	{
		this.X = rect.x;
		this.Y = rect.y;
		this.Width = rect.width;
		this.Height = rect.height;
	}

	public Rect ToRect()
	{
		return new Rect(this.X, this.Y, this.Width, this.Height);
	}
}


