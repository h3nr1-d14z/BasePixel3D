using System;

[Serializable]
public class PhotoInfo
{
	public string Id { get; set; }

	public PhotoSource Source { get; set; }

	public PhotoInfo(string id, PhotoSource source)
	{
		this.Id = id;
		this.Source = source;
	}
}


