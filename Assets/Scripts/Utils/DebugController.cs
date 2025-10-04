using System;
using UnityEngine;

public class DebugController : MonoBehaviour
{
	public Action<bool> OnEnableDebugTexts;

	private Action externalGui;

	[SerializeField]
	private float m_updateInterval = 0.5f;

	private float m_fps;

	private float m_accum;

	private int m_frames;

	private float m_timeleft;

	public static DebugController Instance { get; private set; }

	public bool EnableDebugTexts { get; private set; }

	private void Awake()
	{
		DebugController.Instance = this;
	}

	private void OnGUI()
	{
		if (this.externalGui != null)
		{
			this.externalGui.SafeInvoke();
		}
		else if (this.EnableDebugTexts && GUILayout.Button("fps: " + this.m_fps.ToString()))
		{
			int targetFrameRate = Application.targetFrameRate;
			UnityEngine.Debug.Log(": " + targetFrameRate);
			if (targetFrameRate < 0)
			{
				Application.targetFrameRate = 30;
			}
			else if (targetFrameRate == 30)
			{
				Application.targetFrameRate = 20;
			}
			else
			{
				Application.targetFrameRate = -1;
			}
		}
	}

	private void Update()
	{
		this.CalculateFps();
	}

	public void ShowExternalGui(Action _externalGui)
	{
		this.externalGui = _externalGui;
	}

	public void StopShowExternalGui()
	{
		this.externalGui = null;
	}

	public void ClickDebugTexts()
	{
		this.EnableDebugTexts = !this.EnableDebugTexts;
		this.OnEnableDebugTexts.SafeInvoke(this.EnableDebugTexts);
	}

	private void CalculateFps()
	{
		this.m_timeleft -= Time.deltaTime;
		this.m_accum += Time.timeScale / Time.deltaTime;
		this.m_frames++;
		if ((double)this.m_timeleft <= 0.0)
		{
			this.m_fps = this.m_accum / (float)this.m_frames;
			this.m_timeleft = this.m_updateInterval;
			this.m_accum = 0f;
			this.m_frames = 0;
		}
	}
}


