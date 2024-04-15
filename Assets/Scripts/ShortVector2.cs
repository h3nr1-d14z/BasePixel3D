using System;

[Serializable]
public class ShortVector2
{
	public short X { get; private set; }

	public short Y { get; private set; }

	public ShortVector2(short x, short y)
	{
		this.X = x;
		this.Y = y;
	}

	public ShortVector2(int x, int y)
	{
		this.X = (short)x;
		this.Y = (short)y;
	}

	public override string ToString()
	{
		return string.Format("{0}:{1}", this.X, this.Y);
	}
}


