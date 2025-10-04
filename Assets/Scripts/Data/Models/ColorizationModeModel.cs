using System;

public class ColorizationModeModel
{
	public enum BrushType
	{
		Singular,
		Plural
	}

	public Action<ColorizationModeModel> OnSpaceTypeChanged;

	private BrushType m_spaceType;

	public BrushType CurrentSpaceType
	{
		get
		{
			return this.m_spaceType;
		}
		set
		{
			this.m_spaceType = value;
			this.OnSpaceTypeChanged.SafeInvoke(this);
		}
	}

	public void ChangeBrushType()
	{
		switch (this.m_spaceType)
		{
			case BrushType.Singular:
				this.CurrentSpaceType = BrushType.Plural;
				break;
			case BrushType.Plural:
				this.CurrentSpaceType = BrushType.Singular;
				break;
		}
	}
}


