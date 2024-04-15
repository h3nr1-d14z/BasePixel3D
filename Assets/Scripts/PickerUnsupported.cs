
using System;

public class PickerUnsupported : AbstractPickerController
{
	public override void GetAllGalleryImagePaths()
	{
		DebugLogger.LogWarning("Current platform not supported");
	}

	public override void Init(Action<bool> InitComplete)
	{
		DebugLogger.LogWarning("Current platform not supported");
	}

	public override void OpenGallery()
	{
		DebugLogger.LogWarning("Current platform not supported");
	}
}


