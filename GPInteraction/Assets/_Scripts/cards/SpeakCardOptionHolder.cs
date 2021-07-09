using GPInteraction._Scripts.mrstruijk;
// using Sirenix.OdinInspector;
using TMPro;


namespace GPInteraction._Scripts
{
	/// <summary>
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	public class SpeakCardOptionHolder : CardOptionHolder
	{
		// [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
		public SOCardOptions cardOptions;

		public EventSO doneTalking;


		public override void UpdateCardText()
		{
			GetComponentInChildren<TextMeshProUGUI>().text = cardOptions.cardAndResponse[storyLine.Value].cardText;
		}


		public void Speak()
		{
			StartCoroutine(BaseConversation.Instance.Conversation(cardOptions, doneTalking));
		}
	}
}
