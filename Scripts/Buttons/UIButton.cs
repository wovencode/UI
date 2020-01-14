// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;
using wovencode;

namespace wovencode
{

	// ===================================================================================
	// UIButton
	// ===================================================================================
	public partial class UIButton : MonoBehaviour
	{
		
		public Button button;
		[Range(0,9)] public float delayDuration = 1;
		
		protected UIButtonGroup buttonGroup;
		protected bool _interactable;
		
		// -------------------------------------------------------------------------------
		public virtual void Init(UIButtonGroup _buttonGroup = null)
		{
			
			button.onClick.RemoveAllListeners();
			
			if (delayDuration <= 0 && _buttonGroup == null)
				return;
			
			buttonGroup = _buttonGroup;
			_interactable = button.interactable;
			
			if (buttonGroup)
				buttonGroup.Add(this);
			
			button.onClick.AddListener(() =>
			{
				if (buttonGroup)
					buttonGroup.OnPressed();
				else
					OnPressed();
			});
		
		}
		
		// -------------------------------------------------------------------------------
		public virtual void OnPressed()
		{
			button.interactable = false;
			Invoke(nameof(EnableAgain), delayDuration);
		}
		
		// -------------------------------------------------------------------------------
		public void EnableAgain()
		{
			button.interactable = _interactable;
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================