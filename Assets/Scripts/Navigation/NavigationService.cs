

using Assets.Scripts.Navigation.Scenes;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Navigation
{
	internal static class NavigationService
	{
		private const float AsyncLoadingAccuracy = 0.9f;

		private static BaseScene _currentScene;

		private static NavigationArgs _navigationArgs;

		private static AsyncOperation _asyncOperation;

		public static Action AsyncLoadingComplete;

		public static SceneType CurrentSceneType
		{
			get
			{
				if (NavigationService._currentScene == null)
				{
					return SceneType.Undefined;
				}
				return NavigationService._currentScene.SceneType;
			}
		}

		public static void Navigate(NavigationArgs navigator, bool allowSceneActivation = true)
		{
			if (NavigationService._currentScene != null)
			{
				NavigationService._currentScene.OnNavigatedFrom();
			}
			NavigationService._navigationArgs = navigator;
			if (NavigationService._currentScene != null)
			{
				NavigationService.LoadLevelAsynchronously(navigator.SceneName, allowSceneActivation);
			}
			else
			{
				Application.LoadLevel(navigator.SceneName);
			}
		}

		public static void LoadLevelAsynchronously(string name, bool allowSceneActivation)
		{
			UnitySingleton<MonoHelper>.Instance.StartCoroutine(NavigationService.LoadLevelAsync(name, allowSceneActivation));
		}

		private static void OnAsyncLoadingComplete()
		{
			if (NavigationService.AsyncLoadingComplete != null)
			{
				NavigationService._currentScene.OnNavigatedTo(NavigationService._navigationArgs);
				NavigationService.AsyncLoadingComplete();
			}
		}

		private static IEnumerator LoadLevelAsync(string name, bool allowSceneActivation)
		{
			NavigationService._asyncOperation = SceneManager.LoadSceneAsync(name);
			NavigationService._asyncOperation.allowSceneActivation = allowSceneActivation;
			if (!NavigationService._asyncOperation.isDone)
			{
				if (NavigationService._asyncOperation.progress >= 0.9f)
				{
					NavigationService.OnAsyncLoadingComplete();
				}
				yield return null;
			}
			yield return NavigationService._asyncOperation;
		}

		public static void SetCurrentScene(BaseScene scene)
		{
			NavigationService._currentScene = scene;
			NavigationService._currentScene.OnNavigatedTo(NavigationService._navigationArgs);
		}
	}
}