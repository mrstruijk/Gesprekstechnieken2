using UnityEngine;


namespace GPInteraction._Scripts
{
	/// <summary>
	///     Allows you to change the card text during runtime.
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	public class UpdateCardTextInChildrenCards : MonoBehaviour
	{
		private CardOptionHolder[] cardOptionHolders;


		private void OnEnable()
		{
			cardOptionHolders = GetComponentsInChildren<CardOptionHolder>();
		}


		public void UpdateCardsText()
		{
			foreach (var coh in cardOptionHolders)
			{
				coh.UpdateCardText();
			}
		}
	}
}