// =======================================================================================
// UIPopup
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
	// UIPopup
	// ===================================================================================
	public abstract partial class UIPopup : UIBase
	{
		
		[Header("UI Popup")]
		[SerializeField] protected UIWindowBackground background;
		[SerializeField] protected Animator animator;
		[SerializeField] protected string showTriggerName = "show";
		[SerializeField] protected string closeTriggerName = "close";
		[SerializeField] protected Text description;
		
		// -------------------------------------------------------------------------------
		protected override void Awake()
		{
			SetPopupActive(false);
			base.Awake();
		}
		
		// -------------------------------------------------------------------------------
		public virtual void Show(string _text)
		{
			description.text = _text;
			Setup();

			base.Show();
		}
		
		// -------------------------------------------------------------------------------
		public virtual void onClickConfirm()
		{
			Close();
		}
		
		// -------------------------------------------------------------------------------
		public virtual void onClickCancel()
		{
			Close();
		}
		
		// -------------------------------------------------------------------------------
		protected void Setup()
		{
			SetPopupActive(true);
			
			animator.SetTrigger(showTriggerName);
			background.FadeIn();
		}
		
		// -------------------------------------------------------------------------------
		protected void Close()
		{
			animator.SetTrigger(closeTriggerName);
			background.FadeOut();
			StartCoroutine(Tools.GetMethodName(DeactivateWindow));
		}
		 
		// -------------------------------------------------------------------------------
		protected IEnumerator DeactivateWindow()
		{
			yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
			SetPopupActive(false);
		}
		
		// -------------------------------------------------------------------------------
		protected void SetPopupActive(bool active)
		{
			background.gameObject.SetActive(active);
			Hide();
		}
		
		// -------------------------------------------------------------------------------
		
	}

}