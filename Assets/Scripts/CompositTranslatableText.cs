

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CompositTranslatableText : MonoBehaviour
{
	[SerializeField]
	private bool m_autoTranslate = true;

	[SerializeField]
	private List<string> m_list;

	[SerializeField]
	private string m_format;

	[SerializeField]
	private bool forceUpper;

	private Text m_text;

	private BestFit m_bestFit;

	private void Start()
	{
		if (this.m_autoTranslate)
		{
			this.Translate();
		}
	}

	public void Translate()
	{
		this.m_text = base.GetComponent<Text>();
		this.m_bestFit = base.GetComponent<BestFit>();
		this.m_text.enabled = false;
		if (this.m_text.text != string.Empty)
		{
			string[] args = (from a in this.m_list
							 select LocalizationManager.Instance.GetString(a)).ToArray();
			string text = string.Format(this.m_format, args);
			this.m_text.text = ((!this.forceUpper) ? text : text.ToUpper());
		}
		if (this.m_bestFit != null)
		{
			this.m_bestFit.Refit();
		}
		this.m_text.enabled = true;
	}
}


