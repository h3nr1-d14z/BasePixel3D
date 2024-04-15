using UnityEngine;
public static class GameHelper
{
	public static Texture2D Rotate(Texture2D originalTexture, bool clockwise)
	{
		Color32[] pixels = originalTexture.GetPixels32();
		Color32[] colors = new Color32[pixels.Length];
		int width = originalTexture.width;
		int height = originalTexture.height;
		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				int destIndex = (j + 1) * height - i - 1;
				int sourceIndex = (!clockwise) ? (i * width + j) : (pixels.Length - 1 - (i * width + j));
				colors[destIndex] = pixels[sourceIndex];
			}
		}
		Texture2D texture2D = new Texture2D(height, width);
		texture2D.SetPixels32(colors);
		texture2D.Apply();
		return texture2D;
	}

	public static void CamScaleTexture(Texture2D texture, int height, float ratio, float quality)
	{
		TextureScale.Point(texture, (int)((float)height * ratio * quality), (int)((float)height * quality));
	}
}