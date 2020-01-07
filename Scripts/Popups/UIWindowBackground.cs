// =======================================================================================
// UIWindowBackground
// by Weaver (Fhiz)
// MIT licensed
//
// Attached to a UI element that stretches across the entire screen in order to hide
// all other UI elements underneath it. This is used as a background for all kinds of
// popup windows. It blocks ray-casting, so the user may only interact with the popup
// instead of clicking on other UI elements.
//
// =======================================================================================

using UnityEngine;
using System.Collections;
using wovencode;

namespace wovencode
{
	
	// ===================================================================================
	// UIWindowBackground
	// ===================================================================================
	public partial class UIWindowBackground : MonoBehaviour 
	{

		[SerializeField] protected Animator animator;
		[SerializeField] protected string fadeInTriggerName = "fadeIn";
		[SerializeField] protected string fadeOutTriggerName = "fadeOut";
		
		// -------------------------------------------------------------------------------
		// FadeIn
		// -------------------------------------------------------------------------------
		public void FadeIn()
		{
			animator.SetTrigger(fadeInTriggerName);
		}
		
		// -------------------------------------------------------------------------------
		// FadeOut
		// -------------------------------------------------------------------------------
		public void FadeOut()
		{
			animator.SetTrigger(fadeOutTriggerName);
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================