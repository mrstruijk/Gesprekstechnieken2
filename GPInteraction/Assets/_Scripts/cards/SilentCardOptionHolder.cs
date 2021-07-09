using TMPro;
using UnityEngine;


namespace GPInteraction._Scripts
{
	/// <summary>
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	public class SilentCardOptionHolder : CardOptionHolder
	{
		[TextArea] public string cardText;


		public override void UpdateCardText()
		{
			GetComponentInChildren<TextMeshProUGUI>().text = cardText;
		}


		public void UpdateCardTextWithString(string text)
		{
			cardText = text;
			GetComponentInChildren<TextMeshProUGUI>().text = cardText;
		}
	}
}