
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

[Serializable]
public class NewLockitInfo
{
	private Dictionary<string, Dictionary<string, string>> m_dict;

	public string this[string key]
	{
		get
		{
			if (this.m_dict.ContainsKey(key))
			{
				string locale = LocalizationManager.Instance.CurrentLocale;
				locale = locale.Replace("_", "-");
				if (this.m_dict[key].ContainsKey(locale))
				{
					string text = this.m_dict[key][locale];
					if (!string.IsNullOrEmpty(text))
					{
						if (locale == "ar")
						{
							text = text.Replace("[[[", string.Empty);
							text = text.Replace("]]]", string.Empty);
							//text = ArabicFixer.Fix(text, false, false);
							text = text.Replace(">/b<", "<b>");
							text = text.Replace(">b<", "</b>");
							text = text.Replace("//:https", "https://");
						}
						return text;
					}
				}
				while (locale.Length > 3)
				{
					if (!locale.Contains("-"))
					{
						locale = locale.Substring(0, 2);
					}
					else
					{
						locale = locale.Substring(0, locale.LastIndexOf("-"));
					}
					string text2 = this.m_dict[key].Keys.FirstOrDefault((string a) => a.StartsWith(locale));
					if (text2 == null)
					{
						continue;
					}
					string text3 = this.m_dict[key][text2];
					if (string.IsNullOrEmpty(text3))
					{
						continue;
					}
					if (!(locale == "ar"))
					{
						return text3;
					}
					text3 = text3.Replace("[[[", string.Empty);
					text3 = text3.Replace("]]]", string.Empty);
					//text3 = ArabicFixer.Fix(text3, false, false);
					text3 = text3.Replace(">/b<", "<b>");
					text3 = text3.Replace(">b<", "</b>");
					text3 = text3.Replace("//:https", "https://");
					break;
				}
				locale = LocalizationManager.Instance.DefaultLocale;
				if (this.m_dict[key].ContainsKey(locale))
				{
					string text4 = this.m_dict[key][locale];
					if (!string.IsNullOrEmpty(text4))
					{
						return text4;
					}
				}
			}
			return key;
		}
	}

	//public NewLockitInfo(Dictionary<string, Dictionary<string, string>> dict)
	//{
	//    this.m_dict = dict;
	//}

	public NewLockitInfo(string text)
	{
		m_dict = new Dictionary<string, Dictionary<string, string>>();

		using (StringReader sw = new StringReader(text))
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(text);

			var pairs = doc.GetElementsByTagName("TextPair");
			foreach (XmlElement pair in pairs)
			{
				var key = (pair.GetElementsByTagName("Key")[0] as XmlElement).InnerText;
				var values = pair.GetElementsByTagName("Value")[0] as XmlElement;

				var t = new Dictionary<string, string>();
				foreach (XmlElement n in values.GetElementsByTagName("Text"))
				{
					var textKey = (n.GetElementsByTagName("Key")[0] as XmlElement).InnerText;
					var textValue = (n.GetElementsByTagName("Value")[0] as XmlElement).InnerText;

					t[textKey] = textValue;
				}

				m_dict[key] = t;
			}
		}
	}
}


