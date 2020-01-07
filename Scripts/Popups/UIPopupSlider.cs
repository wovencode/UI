// =======================================================================================
// UIPopupSlider
// by Weaver (Fhiz)
// MIT licensed
//
// This popup provides a slider that is used to input a numeric value. The process can
// be confirmed and cancelled. Confirmation passes the sliders input value. This class
// is universal and can be used everywhere you want to prompt the user for numeric input.
//
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
		// Awake
		// -------------------------------------------------------------------------------
		protected override void Awake()
		{
			if (singleton == null) singleton = this;
			base.Awake();
		}
		
		// -------------------------------------------------------------------------------
		// Setup
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
		// onClickConfirm
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