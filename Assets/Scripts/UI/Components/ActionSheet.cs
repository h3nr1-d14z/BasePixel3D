

using System;
using UnityEngine;

public class ActionSheetWrapper : MonoBehaviour
{
	public static ActionSheetUI actionSheet;

	public static void ShowSavedWorkActionSheet(Action<ActionSheetResult> callback)
	{
		actionSheet.ShowButtons(new string[] {
			LocalizationManager.Instance.GetString("continue"),
			LocalizationManager.Instance.GetString("new"),
			LocalizationManager.Instance.GetString("delete"),
			LocalizationManager.Instance.GetString("cancel")
		}, (buttonIndex) =>
		{
			if (buttonIndex == 0)
				callback(ActionSheetResult.Continue);
			else if (buttonIndex == 1)
				callback(ActionSheetResult.New);
			else if (buttonIndex == 2)
				callback(ActionSheetResult.Delete);
			else if (buttonIndex == 3)
				callback(ActionSheetResult.Cancel);
		});
	}

	public static void ShowEmptyPhotoActionSheet(Action<ActionSheetResult> callback)
	{
        actionSheet.ShowButtons(new string[] {
           // LocalizationManager.Instance.GetString("continue"),
			LocalizationManager.Instance.GetString("new"),
			LocalizationManager.Instance.GetString("delete"),
			LocalizationManager.Instance.GetString("cancel")
		}, (buttonIndex) =>
		{
			//if (buttonIndex == 0)
			//	callback(ActionSheetResult.Continue);
			if (buttonIndex == 0)
				callback(ActionSheetResult.New);
			else if (buttonIndex == 1)
				callback(ActionSheetResult.Delete);
			else if (buttonIndex == 2)
				callback(ActionSheetResult.Cancel);
		});
	}

	public static void ShowImagePreviewActionSheet(Action<ActionSheetResult> callback)
	{
		actionSheet.ShowButtons(new string[] {
			LocalizationManager.Instance.GetString("continue"),
			LocalizationManager.Instance.GetString("new"),
			LocalizationManager.Instance.GetString("cancel")
		}, (buttonIndex) =>
		{
			if (buttonIndex == 0)
				callback(ActionSheetResult.Continue);
			else if (buttonIndex == 1)
				callback(ActionSheetResult.New);
			else if (buttonIndex == 2)
				callback(ActionSheetResult.Cancel);
		});
	}
}


