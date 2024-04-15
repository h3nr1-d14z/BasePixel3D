using UnityEngine;

public class FilterInfo
{
	public Texture2D Texture { get; set; }

	public int FilterIndex { get; set; }

	public FilterInfo(Texture2D tex, int index)
	{
		this.Texture = tex;
		this.FilterIndex = index;
	}
}


