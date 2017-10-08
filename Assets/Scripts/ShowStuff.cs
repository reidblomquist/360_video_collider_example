using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VRStandardAssets.Utils
{
	public class ShowStuff : MonoBehaviour
	{
		public Text uiPaneText;
		[SerializeField] private VRInteractiveItem m_InteractiveItem;       // Reference to the VRInteractiveItem to determine when to fill the bar.

		private void OnEnable()
		{
			m_InteractiveItem.OnOver += HandleOver;
			m_InteractiveItem.OnOut += HandleOut;
		}

		private void OnDisable()
		{
			m_InteractiveItem.OnOver -= HandleOver;
			m_InteractiveItem.OnOut -= HandleOut;
		}

		IEnumerator FadeTo(float aValue, float aTime)
		{
			float alpha = uiPaneText.color.a;
			for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
			{
				Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
				uiPaneText.color = newColor;
				yield return null;
			}
		}

		private void HandleOver ()
        {
			StartCoroutine(FadeTo(1.0f, 0.5f));
        }


        private void HandleOut ()
        {
			StartCoroutine(FadeTo(0.0f, 0.5f));
        }
    }
}