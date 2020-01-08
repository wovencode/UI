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
		
		protected bool _tooltipActive;
		
		// -------------------------------------------------------------------------------
		// SetupToolTip
		// -------------------------------------------------------------------------------
		void SetupToolTip()
		{
			UITooltip.singleton.Show(tooltipText);
			UITooltip.singleton.transform.SetParent(transform.root, true);
			UITooltip.singleton.transform.SetAsLastSibling();
			UITooltip.singleton.transform.position = Input.mousePosition;
			_tooltipActive = true;
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
			_tooltipActive = false;
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
			if (!_tooltipActive) return;
			UITooltip.singleton.UpdateTooltip(tooltipText);
			UITooltip.singleton.transform.position = Input.mousePosition;
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