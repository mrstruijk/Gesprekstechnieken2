using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace GPInteraction._Scripts
{
	/// <summary>
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	public class ManageCardAvailability : MonoBehaviour
	{
		public List<GameObject> cards;


		public void DisableCards()
		{
			foreach (var card in cards)
			{
				card.GetComponentInChildren<MeshRenderer>().enabled = false;
				card.GetComponentInChildren<Collider>().enabled = false;
				card.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
			}
		}


		public void DisableInteraction()
		{
			foreach (var card in cards)
			{
				card.GetComponentInChildren<Collider>().enabled = false;
			}
		}


		public void DisableText()
		{
			foreach (var card in cards)
			{
				card.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
			}
		}


		public void EnableMeshRenderers()
		{
			foreach (var card in cards)
			{
				card.GetComponentInChildren<MeshRenderer>().enabled = true;
			}
		}


		public void EnableCards()
		{
			foreach (var card in cards)
			{
				card.GetComponentInChildren<MeshRenderer>().enabled = true;
				card.GetComponentInChildren<Collider>().enabled = true;
				card.GetComponentInChildren<CardOptionHolder>().UpdateCardText();
				card.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
			}

			var audio = GetComponent<CardAudioManager>();
			audio.PlayClip(audio.defaultClip);
		}
	}
}