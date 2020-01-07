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
		
		protected Action<long> confirmAction;
		protected Action cancelAction;
		
		[SerializeField] protected Slider 	slider;
		[SerializeField] protected Text 	sliderValueText;
		[SerializeField] protected Button 	confirmButton;
		[SerializeField] protected Button 	cancelButton;
		
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
		public void Setup(string _description, string _confirmText="", string _cancelText="", Action<long> _confirmAction=null, Action _cancelAction=null)
		{
			
			confirmAction 	= _confirmAction;
			cancelAction 	= _cancelAction;
			
			if (confirmButton)
				confirmButton.onClick.SetListener(() => { onClickConfirm(); });
				
			if (confirmButton && confirmButton.GetComponent<Text>() != null && !String.IsNullOrWhiteSpace(_confirmText))
				confirmButton.GetComponent<Text>().text = _confirmText;
				
			if (cancelButton)
				cancelButton.onClick.SetListener(() => { onClickCancel(); });
			
			if (cancelButton && cancelButton.GetComponent<Text>() != null && !String.IsNullOrWhiteSpace(_cancelText))
				cancelButton.GetComponent<Text>().text = _cancelText;
			
			onChange();
			
			Show(_description);
		
		}
		
		// -------------------------------------------------------------------------------
		public void onClickMinus()
		{
			slider.value--;
			onChange();
		}
		
		// -------------------------------------------------------------------------------
		public void onClickPlus()
		{
			slider.value++;
			onChange();
		}
		
		// -------------------------------------------------------------------------------
		public void onChange()
		{
			sliderValueText.text = slider.value.ToString() + "/" + slider.maxValue.ToString();
		}
		
		// -------------------------------------------------------------------------------
		// onClickConfirm
		// -------------------------------------------------------------------------------
		public override void onClickConfirm()
		{
			if (confirmAction != null)
				confirmAction(Convert.ToInt32(slider.value));

			Close();
		}
		
		// -------------------------------------------------------------------------------
		// onClickCancel
		// -------------------------------------------------------------------------------
		public override void onClickCancel()
		{
			if (cancelAction != null)
				cancelAction();

			Close();
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================