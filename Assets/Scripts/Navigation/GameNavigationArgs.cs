using Assets.Scripts.Navigation.Scenes;

public class GameNavigationArgs : NavigationArgs
{
	private const string MapSceneName = "3DScene";

	public CashImage3D Data { get; private set; }

	public ImageInfo ImageInfo { get; private set; }

	public SavedWorkData3D SavedWorkData { get; private set; }

	public ImageOpenType ImageOpenType { get; private set; }

	public GameNavigationArgs()
		: base(SceneType.Game, "3DScene")
	{
	}

	public GameNavigationArgs(ImageInfo imageinfo, CashImage3D data, SavedWorkData3D savedWorkData, ImageOpenType imageOpenType)
		: base(SceneType.Game, "3DScene")
	{
		this.Data = data;
		this.ImageInfo = imageinfo;
		this.SavedWorkData = savedWorkData;
		this.ImageOpenType = imageOpenType;
	}
}


