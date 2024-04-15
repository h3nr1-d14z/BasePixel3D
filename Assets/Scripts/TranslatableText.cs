

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TranslatableText : MonoBehaviour
{
	[SerializeField]
	private bool m_autoTranslate = true;

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
			string str = LocalizationManager.Instance.GetString(this.m_text.text);
			this.m_text.text = str;
		}
		if (this.m_bestFit != null)
		{
			this.m_bestFit.Refit();
		}
		this.m_text.enabled = true;
		ContentSizeFitter component = base.GetComponent<ContentSizeFitter>();
		if (component != null)
		{
			component.SetLayoutHorizontal();
		}
	}
}


