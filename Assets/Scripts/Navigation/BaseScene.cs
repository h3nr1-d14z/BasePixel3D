
using System;
using UnityEngine;

namespace Assets.Scripts.Navigation.Scenes
{
	internal abstract class BaseScene : MonoBehaviour
	{
		public abstract SceneType SceneType
		{
			get;
		}

		public abstract void BackButtonActions();

		public virtual void Start()
		{
			NavigationService.SetCurrentScene(this);
			UnitySingleton<BackButtonManager>.Instance.SetPause(false);
			BackButtonManager instance = UnitySingleton<BackButtonManager>.Instance;
			instance.BackButtonAction = (Action)Delegate.Combine(instance.BackButtonAction, new Action(this.BackButtonActions));
		}

		public abstract void OnNavigatedTo(NavigationArgs args);

		public abstract void OnNavigatedFrom();
	}
}


