// =======================================================================================
// UIPopupSlider
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using wovencode;
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


namespace wovencode
{

	// ===================================================================================
	// UIPopupSlider
	// ===================================================================================
	[DisallowMultipleComponent]
	public partial class UIPopupSlider : UIPopup
	{

		public static UIPopupSlider singleton;
		
		protected Action confirmAction;
		
		[SerializeField] protected Button confirmButton;
		
		// -------------------------------------------------------------------------------
		//
		// -------------------------------------------------------------------------------
		protected override void Awake()
		{
			if (singleton == null) singleton = this;
			base.Awake();
		}
		
		// -------------------------------------------------------------------------------
		//
		// -------------------------------------------------------------------------------
		public void Setup(string _description, string confirmText="", Action confirm=null)
		{
			
			if (confirm != null)
				confirmAction 			= confirm;
			
			if (confirmButton && confirmButton.GetComponent<Text>() != null)
			{
				confirmButton.onClick.SetListener(() => { onClickConfirm(); });
				
				if (!String.IsNullOrWhiteSpace(confirmText))
					confirmButton.GetComponent<Text>().text = confirmText;
			}	
				
			Show(_description);
		
		}
		
		// -------------------------------------------------------------------------------
		//
		// -------------------------------------------------------------------------------
		public override void onClickConfirm()
		{
			if (confirmAction != null)
				confirmAction();

			Close();
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================