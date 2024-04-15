using System;

public class TutorialModel
{
	public Action OnToolsTutorialShow;

	public Action OnToolsTutorialClose;

	public Action OnPalettesTutorialShow;

	public Action OnPalettesTutorialClose;

	private int m_imageClickCounter;

	public void ImageClick()
	{
		this.m_imageClickCounter++;
		if (this.m_imageClickCounter != 4)
		{ 
		} 
	}

	public void ToolsButtonClick()
	{
	}

	public void PalettesWindowOpened()
	{
	}
}


