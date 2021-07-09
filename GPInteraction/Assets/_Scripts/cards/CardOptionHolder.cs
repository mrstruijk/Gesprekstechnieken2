//using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


namespace GPInteraction._Scripts
{
	/// <summary>
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	public abstract class CardOptionHolder : MonoBehaviour
	{
		public IntReference storyLine;


		private void OnEnable()
		{
			UpdateCardText();
		}


		public abstract void UpdateCardText();


		#region Debug

		// [Button]
		public void TriggerSelectExit()
		{
			GetComponent<XRGrabInteractable>().selectExited.Invoke(null);
		}


		// [Button]
		private void TriggerActivate()
		{
			GetComponent<XRGrabInteractable>().activated.Invoke(null);
		}

		#endregion
	}
}
