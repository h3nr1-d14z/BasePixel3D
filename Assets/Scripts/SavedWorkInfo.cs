using System;

[Serializable]
public class SavedWorkInfo
{
	public string Id { get; set; }

	public DateTime DateTime { get; set; }

	public SavedWorkInfo(string id, DateTime dateTime)
	{
		this.Id = id;
		this.DateTime = dateTime;
	}
}


