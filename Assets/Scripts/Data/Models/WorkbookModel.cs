public class WorkbookModel
{
	public static WorkbookModel Instance { get; private set; }

	public ColorizationModeModel ColorizationModeModel { get; private set; }

	public CurrentColorModel CurrentColorModel { get; private set; }

	public TutorialModel TutorialModel { get; private set; }

	public SpecBoostersModel SpecBoostersModel { get; private set; }

	public WorkbookModel()
	{
		this.ColorizationModeModel = new ColorizationModeModel();
		this.CurrentColorModel = new CurrentColorModel();
		this.TutorialModel = new TutorialModel();
		this.SpecBoostersModel = new SpecBoostersModel();
	}

	public static void Init()
	{
		WorkbookModel.Instance = new WorkbookModel();
	}
}


