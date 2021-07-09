using UnityEngine;


namespace GPInteraction._Scripts
{
	/// <summary>
	///     This needs to live on the same gameobject as the Canvas. It finds the main camera to set as worldCamera.
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	public class SetCanvasCameraOnEnable : MonoBehaviour
	{
		private void OnEnable()
		{
			GetComponent<Canvas>().worldCamera = Camera.main;
		}
	}
}