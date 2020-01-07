// =======================================================================================
// UITooltipHandler
// by Weaver (Fhiz)
// MIT licensed
//
// 
//
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using wovencode;

namespace wovencode
{

	// ===================================================================================
	// UITooltipHandler
	// ===================================================================================
	public class UITooltipHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{

		[TextArea(1, 40)]
		public string tooltipText = "";
		
		// -------------------------------------------------------------------------------
		// SetupToolTip
		// -------------------------------------------------------------------------------
		void SetupToolTip()
		{
			UITooltip.singleton.Show(tooltipText);
			UITooltip.singleton.transform.SetParent(transform.root, true);
			UITooltip.singleton.transform.SetAsLastSibling();
		}
		
		// -------------------------------------------------------------------------------
		// ShowToolTip
		// -------------------------------------------------------------------------------
		void ShowToolTip(float delay)
		{
			Invoke(nameof(SetupToolTip), delay);
		}
		
		// -------------------------------------------------------------------------------
		// HideTooltip
		// -------------------------------------------------------------------------------
		void HideTooltip()
		{
			CancelInvoke(nameof(ShowToolTip));
			UITooltip.singleton.Hide();
		}
		
		// -------------------------------------------------------------------------------
		// OnPointerEnter
		// -------------------------------------------------------------------------------
		public void OnPointerEnter(PointerEventData d)
		{
			ShowToolTip(0.3f);
		}
		
		// -------------------------------------------------------------------------------
		// HideTooltip
		// -------------------------------------------------------------------------------
		public void OnPointerExit(PointerEventData d)
		{
			HideTooltip();
		}
		
		// -------------------------------------------------------------------------------
		// Update
		// constantly update the tooltip text (as long as its visible) because values might
		// change
		// -------------------------------------------------------------------------------
		void Update()
		{
			UITooltip.singleton.UpdateTooltip(tooltipText);
		}
		
		// -------------------------------------------------------------------------------
		// OnDisable
		// -------------------------------------------------------------------------------
		void OnDisable()
		{
			HideTooltip();
		}
		
		// -------------------------------------------------------------------------------
		// OnDestroy
		// -------------------------------------------------------------------------------
		void OnDestroy()
		{
			HideTooltip();
		}
		
	}
	
	// -----------------------------------------------------------------------------------
	
}

// =======================================================================================