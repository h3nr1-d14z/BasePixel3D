


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : UnitySingleton<ProgressManager>
{
	private ImageInfo _info;

	private float TimeDelayForSave = 30f;

	private CamShot camShot;

	private bool isStartSaveWork;

	private SavedWorkData3D m_savedWorkData;

	private Action<SavedWorkData3D> saveWaiter;

	private bool completed;

	public void Init(ImageInfo info, GameObject saveCamera, SavedWorkData3D savedWorkData)
	{
		if (info == null)
		{
			this._info = new ImageInfo("test");
		}
		else
		{
			this._info = info;
		}
		if (saveCamera != null)
		{
			this.camShot = saveCamera.GetComponent<CamShot>();
		}
		else
		{
			UnityEngine.Debug.LogError("Save Camera not found!!!");
		}
		if (this.camShot == null)
		{
			UnityEngine.Debug.LogError("CamShot not found!!!");
		}
		this.m_savedWorkData = savedWorkData;
		if (this.m_savedWorkData != null)
		{
			this.completed = this.m_savedWorkData.Completed;
		}
		this.camShot.ColorPalleteComplete += new Action<byte[]>(this.CamShot_ColorPalleteComplete);
	}

	public void StartSaveProcess()
	{
		base.StartCoroutine(this.Process());
	}

	public void StopSaveProcess()
	{
		base.StopCoroutine(this.Process());
	}

	public SavedWorkData3D LoadProgressTest()
	{
		return this.m_savedWorkData;
	}

	private void CamShot_ColorPalleteComplete(byte[] obj)
	{
		List<bool> voxCubeProgress = UnitySingleton<GameController>.instance.VoxCubeProgress;
		if (voxCubeProgress != null)
		{
			this.m_savedWorkData = MainManager.Instance.SavedWorksList.Save3D(this._info, obj, this.m_savedWorkData, this.completed, null, voxCubeProgress);
			this.isStartSaveWork = false;
		}
	}

	public void SetComplete()
	{
		this.completed = true;
	}

	public void SaveWork(Action<SavedWorkData3D> handler)
	{
		this.saveWaiter = handler;
		List<bool> voxCubeProgress = UnitySingleton<GameController>.instance.VoxCubeProgress;
		if (voxCubeProgress != null)
		{
			this.camShot.ColorPalleteComplete += new Action<byte[]>(this.WaitForScreenshot);
			this.camShot.TakeHiResShot();
		}
		handler.SafeInvoke(this.m_savedWorkData);
	}

	private void WaitForScreenshot(byte[] bytes)
	{
		this.camShot.ColorPalleteComplete -= new Action<byte[]>(this.WaitForScreenshot);
		List<bool> voxCubeProgress = UnitySingleton<GameController>.instance.VoxCubeProgress;
		if (voxCubeProgress != null)
		{
			this.m_savedWorkData = MainManager.Instance.SavedWorksList.Save3D(this._info, bytes, this.m_savedWorkData, this.completed, null, voxCubeProgress);
			this.isStartSaveWork = false;
		}
	}
	private IEnumerator Process()
	{
		while (true)
		{
			yield return new WaitForSeconds(this.TimeDelayForSave);
			if (!this.isStartSaveWork)
			{
				this.isStartSaveWork = true;
				//this.camShot.TakeHiResShot();
			}
			else
			{
				this.isStartSaveWork = false;
			}
		}
	}
}
