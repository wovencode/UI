// =======================================================================================
// UIRoot
// by Weaver (Fhiz)
// MIT licensed
//
// based of Suriyun's UIBase class to provide a root class for all other UI elements.
// This class makes the Update function private and implements a ThrottledUpdate function 
// to be used instead. This way, all updates run at a throttled rate (that can be set
// via the inspector) instead of once per frame. The result is a major performance
// improvement, implemented right at the root of any UI element.
//
// =======================================================================================

using Wovencode;
using Wovencode.UI;
#if wNETWORK
using Wovencode.Network;
#endif
using UnityEngine;

namespace Wovencode.UI
{

	// ===================================================================================
	// UIRoot
	// ===================================================================================
	public abstract partial class UIRoot : UIBase
	{
	
		[Header("UI Throttle")]
		[Range(0.01f, 3f)]
		public float updateInterval = 0.25f;
		
		protected float fInterval = 0.01f;
		
#if wNETWORK
		protected Wovencode.Network.NetworkManager networkManager;
		protected Wovencode.Network.NetworkAuthenticator networkAuthenticator;
#endif
		
		// -------------------------------------------------------------------------------
		// Awake
		// 
		// -------------------------------------------------------------------------------
		protected override void Awake()
		{
#if wNETWORK
			networkManager = FindObjectOfType<Wovencode.Network.NetworkManager>();
			networkAuthenticator = FindObjectOfType<Wovencode.Network.NetworkAuthenticator>();
#endif
			base.Awake();
		}
		
		// -------------------------------------------------------------------------------
		// Update is called every frame
		// Private to prevent child classes from using it
		// -------------------------------------------------------------------------------
		void Update()
		{
			if (Time.time > fInterval)
			{
				ThrottledUpdate();
				fInterval = Time.time + updateInterval;
			}
		}
		
		// -------------------------------------------------------------------------------
		// ThrottledUpdated is called once per updateInterval
		// Protected to allow child classes to use it 
		// -------------------------------------------------------------------------------
		protected virtual void ThrottledUpdate() {}
        
        // -------------------------------------------------------------------------------
        
	}

}

// =======================================================================================