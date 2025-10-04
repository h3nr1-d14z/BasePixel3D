using UnityEngine;

public class CompositeImage : MonoBehaviour
{
	[SerializeField]
	private int m_width = 100;

	[SerializeField]
	private int m_height = 100;

	[SerializeField]
	private int m_pixelsPerUnit = 100;

	public int Width
	{
		get
		{
			return this.m_width;
		}
		set
		{
			this.m_width = value;
		}
	}

	public int Height
	{
		get
		{
			return this.m_height;
		}
		set
		{
			this.m_height = value;
		}
	}

	public int PixelsPerUnit
	{
		get
		{
			return this.m_pixelsPerUnit;
		}
		set
		{
			this.m_pixelsPerUnit = value;
		}
	}
}


