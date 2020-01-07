// =======================================================================================
// UIWindowBackground
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using UnityEngine;
using System.Collections;
using wovencode;

namespace wovencode
{
	
	// ===================================================================================
	// UIWindowBackground
	// ===================================================================================
	public class UIWindowBackground : MonoBehaviour 
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