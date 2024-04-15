using System;

public class SpecBoostersModel
{
	public Action<SpecBoostersModel> OnStateChanged;

	public Action<SpecBoostersModel> OnLassoModeChanged;

	public Action<SpecBoostersModel> OnBombModeChanged;

	private bool m_lassoMode;

	private bool m_bombMode;

	public bool LassoMode
	{
		get
		{
			return this.m_lassoMode;
		}
		set
		{
			this.m_lassoMode = value;
			this.OnLassoModeChanged.SafeInvoke(this);
		}
	}

	public bool BombMode
	{
		get
		{
			return this.m_bombMode;
		}
		set
		{
			this.m_bombMode = value;
			this.OnBombModeChanged.SafeInvoke(this);
		}
	}

	public int LassoCount
	{
		get
		{
			return AppData.LassoCount;
		}
	}

	public int BombCount
	{
		get
		{
			return AppData.BombCount;
		}
	}

	public void AddLasso()
	{
		AppData.LassoCount++;
		this.OnStateChanged.SafeInvoke(this);
	}

	public void AddBomb()
	{
		AppData.BombCount++;
		this.OnStateChanged.SafeInvoke(this);
	}

	public void SpendLasso()
	{
		if (!IAPWrapper.Instance.NoAds)
		{
			AppData.LassoCount--;
		}
		if (AppData.LassoCount <= 0)
		{
			this.LassoMode = false;
		}
		this.OnStateChanged.SafeInvoke(this);
	}

	public void SpendBomb()
	{
		if (!IAPWrapper.Instance.NoAds)
		{
			AppData.BombCount--;
		}
		if (AppData.BombCount <= 0)
		{
			this.BombMode = false;
		}
		this.OnStateChanged.SafeInvoke(this);
	}

	public void ChangeLassoMode(bool forceEnable = false)
	{
		this.LassoMode = (forceEnable || !this.LassoMode);
		if (this.LassoMode)
		{
			this.BombMode = false;
		}
	}

	public void ChangeBombMode(bool forceEnable = false)
	{
		this.BombMode = (forceEnable || !this.BombMode);
		if (this.BombMode)
		{
			this.LassoMode = false;
		}
	}
}


