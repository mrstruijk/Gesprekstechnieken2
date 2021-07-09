using GPInteraction._Scripts.mrstruijk;
using UnityEngine;


namespace GPInteraction._Scripts
{
	/// <summary>
	///     Hacky way of making sure that manu card is being reset in colour, and that other Events are being called
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	public class CheckForEnd : MonoBehaviour
	{
		public IntReference storyLine;
		public SOCardOptions conversation;
		public EventSO continueConveration;
		public EventSO resetCardColour;
		public EventSO priorToEndOfConversation;
		public EventSO endOfConversation;


		public void CheckForEndOfConversation()
		{
			if (storyLine.Value >= conversation.cardAndResponse.Count - 1)
			{
				endOfConversation.Raise();
			}
			else
			{
				continueConveration.Raise();
			}
		}


		public void CheckForMenuCard()
		{
			if (storyLine.Value < conversation.cardAndResponse.Count - 1) // was '>=' instead of '<'... error?
			{
				priorToEndOfConversation.Raise();
			}
			else
			{
				resetCardColour.Raise();
			}
		}
	}
}