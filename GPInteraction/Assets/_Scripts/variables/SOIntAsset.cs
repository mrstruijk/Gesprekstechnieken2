using UnityEngine;


namespace GPInteraction._Scripts
{
	/// <summary>
	///     From: https://www.youtube.com/watch?v=RZJWwn40T8E&t=11s
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	[CreateAssetMenu(fileName = "IntAsset", menuName = "mrstruijk/Variables/IntAsset")]
	public class SOIntAsset : SOValueAsset<int>
	{
		public void IncreaseIntValue(int addValue)
		{
			value += addValue;
		}
	}
}