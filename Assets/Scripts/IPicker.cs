using System;

public interface IPicker
{
	void Init(Action<bool> InitComplete);

	void GetAllGalleryImagePaths();

	void OpenGallery();
}


