// =======================================================================================
// UIPopupInput
// by Weaver (Fhiz)
// MIT licensed
// 
// This popup provides your user with an input field for text or numeric values. It offers
// a way to Confirm or Cancel the process and each decision can result in a unique action.
// This class is universal and can be used anywhere you want your user to input a name,
// text or number.
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
	// UIPopupInput
	// ===================================================================================
	[DisallowMultipleComponent]
	public partial class UIPopupInput : UIPopup
	{

		public static UIPopupInput singleton;
		
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