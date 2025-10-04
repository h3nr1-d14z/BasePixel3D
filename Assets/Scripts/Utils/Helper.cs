public static class Helper
{
	public static short[] ReverseX(this short[] array, int width, int height)
	{
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height / 2; j++)
			{
				short num = array[i + j * width];
				array[i + j * width] = array[i + (height - 1 - j) * width];
				array[i + (height - 1 - j) * width] = num;
			}
		}
		return array;
	}

	public static short[] Double(this short[] array, int width, int height)
	{
		short[] array2 = new short[array.Length * 4];
		int num = width * 2;
		int num2 = height * 2;
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				array2[i * 2 + j * 2 * num] = (array2[i * 2 + 1 + j * 2 * num] = (array2[i * 2 + (j * 2 + 1) * num] = (array2[i * 2 + 1 + (j * 2 + 1) * num] = array[i + j * width])));
			}
		}
		return array2;
	}

	public static short[] Around(this short[] array, int width, int height)
	{
		short[] array2 = new short[(width + 2) * (height + 2)];
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				array2[i + 1 + (j + 1) * (width + 2)] = array[i + j * width];
			}
		}
		return array2;
	}
}


