// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wovencode;

namespace Wovencode
{
	
	// ===================================================================================
	// UIButtonGroup
	// ===================================================================================
	public partial class UIButtonGroup : MonoBehaviour
	{
	
		protected List<UIButton> buttons = new List<UIButton>();
		
		// -------------------------------------------------------------------------------
		public void Clear()
		{
			buttons.Clear();
		}
		
		// -------------------------------------------------------------------------------	
		public void Add(UIButton button)
		{
			buttons.Add(button);
		}
		
		// -------------------------------------------------------------------------------
		public void OnPressed()
		{
			foreach (UIButton button in buttons)
				button.OnPressed();
		}
		
		// -------------------------------------------------------------------------------
		public void HideOthers(GameObject keepActive)
		{
		
		}
		
		// -------------------------------------------------------------------------------
	}

}

// =======================================================================================
