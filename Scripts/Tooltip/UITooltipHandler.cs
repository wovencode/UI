// =======================================================================================
// Wovencore
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
	public partial class UITooltipHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{

		[TextArea(1, 40)]
		public string tooltipText = "";
		
		protected bool _tooltipActive;
		
		// -------------------------------------------------------------------------------
		// Init
		// -------------------------------------------------------------------------------
		protected void Init()
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
		protected void ShowToolTip(float delay)
		{
			HideTooltip();
			Invoke(nameof(Init), delay);
		}
		
		// -------------------------------------------------------------------------------
		// HideTooltip
		// -------------------------------------------------------------------------------
		protected void HideTooltip()
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
			ShowToolTip(0.1f);
		}
		
		// -------------------------------------------------------------------------------
		// HideTooltip
		// -------------------------------------------------------------------------------
		public void OnPointerExit(PointerEventData d)
		{
			if (_tooltipActive)
				HideTooltip();
		}
		
		// -------------------------------------------------------------------------------
		// Update
		// constantly update the tooltip text (as long as its visible) because values might
		// change
		// -------------------------------------------------------------------------------
		protected void Update()
		{
			if (!_tooltipActive) return;
			UITooltip.singleton.UpdateTooltip(tooltipText);
			UITooltip.singleton.transform.position = Input.mousePosition;
		}
		
		// -------------------------------------------------------------------------------
		// OnDisable
		// -------------------------------------------------------------------------------
		protected void OnDisable()
		{
			if (_tooltipActive)
				HideTooltip();
		}
		
		// -------------------------------------------------------------------------------
		// OnDestroy
		// -------------------------------------------------------------------------------
		protected void OnDestroy()
		{
			if (_tooltipActive)
				HideTooltip();
		}
		
	}
	
	// -----------------------------------------------------------------------------------
	
}

// =======================================================================================