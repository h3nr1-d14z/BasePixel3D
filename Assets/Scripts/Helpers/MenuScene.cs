
using System;
using UnityEngine;

namespace Assets.Scripts.Navigation.Scenes.Map
{
	internal class MenuScene : BaseScene
	{
		public override SceneType SceneType
		{
			get
			{
				return SceneType.Menu;
			}
		}

		public override void OnNavigatedTo(NavigationArgs args)
		{
			MenuNavigationArgs menuNavigationArgs = args as MenuNavigationArgs;
			this.SubscribeToPopupClose();
		}

		public override void OnNavigatedFrom()
		{
			BackButtonManager instance = UnitySingleton<BackButtonManager>.Instance;
			instance.BackButtonAction = (Action)Delegate.Remove(instance.BackButtonAction, new Action(((BaseScene)this).BackButtonActions));
			this.UnsubscribeFromPopupClose();
		}

		public override void BackButtonActions()
		{
			Application.Quit();
		}

		private void SubscribeToPopupClose()
		{
		}

		private void UnsubscribeFromPopupClose()
		{
		}
	}
}


