using System.Security.Cryptography;
using System.Text;

public class Md5Converter
{
	public static string CreateMD5(string input)
	{
		using (MD5 mD = MD5.Create())
		{
			byte[] bytes = Encoding.ASCII.GetBytes(input);
			byte[] array = mD.ComputeHash(bytes);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString("X2"));
			}
			return stringBuilder.ToString().ToLower();
		}
	}
}


