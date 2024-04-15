using System;
using UnityEngine;

public class CamShot : MonoBehaviour
{
	public int resWidth = 1000;

	public int resHeight = 1000;

	public Camera cam;

	private bool takeHiResShot;

	private Texture2D m_Texture;

	public event Action<byte[]> ColorPalleteComplete;

	public GameObject lights;

	private void Start()
	{
		this.m_Texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
	}

	public static string ScreenShotName(int width, int height)
	{
		return string.Format("{0}/Captures/Capture_{1}x{2}_{3}.png", Application.dataPath, width, height, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
	}

	public void TakeHiResShot()
	{
		//lights.SetActive(true);
		this.takeHiResShot = true;
		byte[] shot = FreeImageSaver.MakePngFromOurVirtualThingy(400, 400, 400, 0, this.cam, true);
		this.OnColorPalleteComplete(shot);
		//lights.SetActive(false);
	}

	private void OnColorPalleteComplete(byte[] shot)
	{
		Action<byte[]> colorPalleteComplete = this.ColorPalleteComplete;
		if (colorPalleteComplete != null)
		{
			colorPalleteComplete(shot);
		}
	}
}


