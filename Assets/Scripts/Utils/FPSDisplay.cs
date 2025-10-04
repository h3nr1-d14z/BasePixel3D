using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
	private float deltaTime;

	private void Update()
	{
		if (VoxConstants.isTest)
		{
			this.deltaTime += (Time.unscaledDeltaTime - this.deltaTime) * 0.1f;
		}
	}

	private void OnGUI()
	{
		if (VoxConstants.isTest)
		{
			int width = Screen.width;
			int height = Screen.height;
			GUIStyle gUIStyle = new GUIStyle();
			Rect position = new Rect(0f, 0f, (float)width, (float)(height * 2 / 100));
			gUIStyle.alignment = TextAnchor.UpperLeft;
			gUIStyle.fontSize = height * 2 / 100;
			gUIStyle.normal.textColor = new Color(0f, 0f, 0.5f, 1f);
			float num = this.deltaTime * 1000f;
			float num2 = 1f / this.deltaTime;
			string text = string.Format("{0:0.0} ms ({1:0.} fps)", num, num2);
			GUI.Label(position, text, gUIStyle);
		}
	}
}


