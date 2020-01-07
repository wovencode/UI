﻿// =======================================================================================
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
	[DisallowMultipleComponent]
	public partial class UIPopupConfirm : UIPopup
	{

		public static UIPopupConfirm singleton;
		
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
		public void Setup(string _description, string _confirmText="", Action _confirmAction=null)
		{
			
			confirmAction = _confirmAction;
			
			if (confirmButton && confirmButton.GetComponent<Text>() != null)
			{
				confirmButton.onClick.SetListener(() => { onClickConfirm(); });
				
				if (!String.IsNullOrWhiteSpace(_confirmText))
					confirmButton.GetComponent<Text>().text = _confirmText;
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