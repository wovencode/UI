// =======================================================================================
// UIPopupConfirm
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
	// UIPopupConfirm
	// ===================================================================================
	public partial class UIPopupConfirm : UIPopup
	{

		public static UIPopupConfirm singleton;
		
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