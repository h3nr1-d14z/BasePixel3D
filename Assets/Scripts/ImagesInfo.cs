using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[Serializable]
public class ImagesInfo
{
	private List<ImageInfo> m_images;

	public int Version { get; set; }
	public int Count { get; set; }

	public List<ImageInfo> Images
	{
		get
		{
			return this.m_images;
		}
	}

	public ImagesInfo()
	{
		this.Version = -1;
		this.m_images = new List<ImageInfo>();
	}

	public void Add(ImageInfo imageInfo)
	{
		this.m_images.Add(imageInfo);
		Count++;
	}
#if UNITY_EDITOR
	public void Arrange(string onlineDatasetLocation, ImagesInfo existingImages)
	{
		Debug.Log("Arrange");
        foreach (var lv in MainManager.Instance.levelData.levels)
        {
			ImageInfo info = new ImageInfo();
			info.Name = lv.Name;
			info.AccessStatus = lv.AccessStatus;
			info.Url = lv.Url;
			info.Is3D = lv.Is3D;
			info.Source = lv.Source;
			m_images.Add(info);
		}

		this.Count = this.m_images.Count;

		//if (existingImages != null && existingImages.Images != null)
		//{
		//	var dict = new Dictionary<string, ImageInfo>();
		//	foreach (var image in existingImages.Images)
		//	{
		//		dict[image.Id] = image; 
		//	}

		//	var list = new List<ImageInfo>();
		//	foreach(var image in this.m_images)
		//	{
		//		if (!dict.ContainsKey(image.Id))
		//		{
		//			list.Add(image);
		//		}
		//	}

		//	foreach (var image in existingImages.Images)
		//	{
		//		list.Add(image);
		//	}
		//	this.m_images.Clear();

		//	foreach(var image in list)
		//	{
		//		string fileName = Path.Combine(onlineDatasetLocation, image.Url);
		//		if (File.Exists(fileName) && (!image.Is3D || File.Exists(fileName + ".vox")))
		//		{
		//			this.m_images.Add(image);
		//		}
		//		else
		//		{
		//			Debug.Log(fileName + " does not exist");
		//		}
		//	}

		//	this.Count = this.m_images.Count;
		//}
	}
#endif
}


