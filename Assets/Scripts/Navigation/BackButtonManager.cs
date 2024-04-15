
using System;

namespace Assets.Scripts.Navigation
{
	internal class BackButtonManager : UnitySingleton<BackButtonManager>
	{
		private bool _pause;

		public Action BackButtonAction;

		public event Action PopupBackButtonAction;

		private BackButtonManager()
		{
		}

		public void SetPause(bool value)
		{
			this._pause = value;
		}

		private void OnPopupBackButtonAction()
		{
			Action popupBackButtonAction = this.PopupBackButtonAction;
			if (popupBackButtonAction != null)
			{
				popupBackButtonAction();
			}
		}
	}
}


