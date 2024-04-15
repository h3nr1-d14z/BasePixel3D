namespace Assets.Scripts.Navigation.Scenes.Map
{
	internal class MenuNavigationArgs : NavigationArgs
	{
		private const string MapSceneName = "LibraryScene";

		public readonly MainMenuPage MainMenuPage;

		public MenuNavigationArgs()
			: base(SceneType.Menu, "LibraryScene")
		{
		}

		public MenuNavigationArgs(MainMenuPage mainMenuPage)
			: base(SceneType.Menu, "LibraryScene")
		{
			this.MainMenuPage = mainMenuPage;
		}
	}
}


