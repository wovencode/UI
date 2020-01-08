// (c) IndieMMORPG Kit

using UnityEngine;
using iMMO.Core;

namespace iMMO.Core
{

	public class UILink : MonoBehaviour
	{

        [Header("UI Links")]
        public GameObject[] uiLinks;

        private void OnEnable()
		{
			foreach (GameObject gameObject in uiLinks)
            {
                gameObject.SetActive(true);
            }
        }

        private void OnDisable()
        {
            foreach (GameObject gameObject in uiLinks)
            {
                gameObject.SetActive(false);
            }
        }

    }

}