using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
[DisallowMultipleComponent]
public class FontSwitcher : MonoBehaviour
{
	private Text m_text;

	private void Awake()
	{
		this.m_text = base.GetComponent<Text>();
		switch (LocalizationManager.Instance.CurrentLanguage)
		{
			case SystemLanguage.Japanese:
			case SystemLanguage.Korean:
			case SystemLanguage.Thai:
			case SystemLanguage.Vietnamese:
			case SystemLanguage.ChineseSimplified:
			case SystemLanguage.ChineseTraditional:
				this.m_text.font = (Resources.Load("MyriadPro-Regular-dynamic") as Font);
				break;
			case SystemLanguage.Arabic:
				this.m_text.font = (Resources.Load("MyriadPro-Regular-dynamic") as Font);
				break;
		}
	}

	[ContextMenu("ChangeFont")]
	private void ChangeFont()
	{
		this.m_text = base.GetComponent<Text>();
		if (!this.m_text.font.name.Contains("helvetica") && !this.m_text.font.name.Contains("HELVETICA"))
		{
			return;
		}
		this.m_text.font = (Resources.Load("RobotoCondensed-Regular") as Font);
	}
}


