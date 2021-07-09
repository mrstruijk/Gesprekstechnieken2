using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


namespace GPInteraction._Scripts
{
	/// <summary>
	///     Have this on the same gameobject as the XRGrabInteractable: it fills the XRInteractionManager automatically
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	public class InteractionManagerFinder : MonoBehaviour
	{
		private void OnEnable()
		{
			GetComponent<XRGrabInteractable>().interactionManager = FindObjectOfType<XRInteractionManager>();
		}
	}
}