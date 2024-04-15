using Assets.Scripts.Navigation.Scenes.Map;
using System;
using UnityEngine;

namespace Assets.Scripts.Navigation.Scenes.Game
{
	internal class WorkbookScene : BaseScene
	{
		public override SceneType SceneType
		{
			get
			{
				return SceneType.Workbook;
			}
		}

		public override void Start()
		{
			NavigationService.SetCurrentScene(this);
			BackButtonManager instance = UnitySingleton<BackButtonManager>.Instance;
			instance.BackButtonAction = (Action)Delegate.Combine(instance.BackButtonAction, new Action(((BaseScene)this).BackButtonActions));
		}

		public override void OnNavigatedTo(NavigationArgs args)
		{
			WorkbookNavigationArgs workbookNavigationArgs = args as WorkbookNavigationArgs;
			if (workbookNavigationArgs.SavedWorkData == null)
			{
				MainMenu.LastPage = workbookNavigationArgs.Page;
				MainMenu.ImageId = workbookNavigationArgs.ImageInfo.Id;
				MainMenu.WorkId = null;
			}
			else
			{
				Resources.UnloadUnusedAssets();
				UnitySingleton<BackButtonManager>.Instance.SetPause(true);
			}
		}

		public override void OnNavigatedFrom()
		{
			NewWorkbookManager.Instance.SaveWork(false);
			BackButtonManager instance = UnitySingleton<BackButtonManager>.Instance;
			instance.BackButtonAction = (Action)Delegate.Remove(instance.BackButtonAction, new Action(((BaseScene)this).BackButtonActions));
		}

		public override void BackButtonActions()
		{
			NavigationService.Navigate(new MenuNavigationArgs(), true);
		}
	}
}


