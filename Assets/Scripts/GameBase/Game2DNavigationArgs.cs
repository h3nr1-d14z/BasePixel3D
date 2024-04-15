namespace Assets.Scripts.Navigation.Scenes.Game
{
	internal class WorkbookNavigationArgs : NavigationArgs
	{
		private const string GameSceneName = "2DScene";

		public ImageInfo ImageInfo;

		public MainMenuPage Page;

		public SavedWorkData SavedWorkData;

		public int Part
		{
			get;
			set;
		}

		public WorkbookNavigationArgs(ImageInfo imageInfo, MainMenuPage page)
			: base(SceneType.Workbook, "2DScene")
		{
			this.ImageInfo = imageInfo;
			this.Page = page;
		}

		public WorkbookNavigationArgs(SavedWorkData savedWorkData = null)
			: base(SceneType.Workbook, "2DScene")
		{
			this.SavedWorkData = savedWorkData;
		}

		public WorkbookNavigationArgs(ImageInfo imageInfo, int part, SavedWorkData savedWorkData = null)
			: base(SceneType.Workbook, "2DScene")
		{
			this.ImageInfo = imageInfo;
			this.SavedWorkData = savedWorkData;
			this.Part = part;
		}
	}
}


