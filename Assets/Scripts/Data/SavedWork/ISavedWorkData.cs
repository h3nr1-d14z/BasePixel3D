using System;
using System.Collections.Generic;
using UnityEngine;

public interface ISavedWorkData
{
	string Id
	{
		get;
	}

	ImageInfo ImageInfo
	{
		get;
	}

	string FileName
	{
		get;
	}

	byte[] Preview
	{
		get;
	}

	bool Completed
	{
		get;
	}

	int FilterId { get; set; }

	Rect UvRect1
	{
		get;
	}

	SerializableRect UvRect { get; set; }

	[Obsolete("History saves in enother file now. Use History2")]
	List<HistoryStep> History
	{
		get;
	}

	History History2
	{
		get;
	}

	string FullFileName
	{
		get;
	}

	void Init(ImageInfo imageInfo, byte[] preview, bool completed, List<HistoryStep> history);

	void SetFile(string file);

	void Apply(NumberColoring nc);

	void InitHistory();
}


