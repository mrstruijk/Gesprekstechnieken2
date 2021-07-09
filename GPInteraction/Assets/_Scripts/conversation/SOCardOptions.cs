using System.Collections.Generic;
//using Sirenix.OdinInspector;
using UnityEngine;


namespace GPInteraction._Scripts
{
	/// <summary>
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	[CreateAssetMenu(fileName = "CardOptions", menuName = "mrstruijk/CardOptions")]
	public class SOCardOptions : ScriptableObject
	{
		// [ListDrawerSettings(ShowIndexLabels = false, DraggableItems = false, ShowPaging = true, NumberOfItemsPerPage = 1, Expanded = true)]
		public List<CardAndResponses> cardAndResponse;
	}
}
