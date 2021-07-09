using UnityEngine;


namespace GPInteraction._Scripts
{
	/// <summary>
	///     From: https://www.youtube.com/watch?v=RZJWwn40T8E&t=11s
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	[CreateAssetMenu(fileName = "FloatAsset", menuName = "mrstruijk/Variables/FloatAsset")]
	public class SOFloatAsset : SOValueAsset<float>
	{
		public void IncreaseFloatValue(float addValue)
		{
			value += addValue;
		}
	}
}