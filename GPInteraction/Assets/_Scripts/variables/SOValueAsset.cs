using UnityEngine;


namespace GPInteraction._Scripts
{
	/// <summary>
	///     This turns a value in a Project-wide asset, instead of a value localised on an instance of a class.
	///     Based on Ryan Hipple's 2017 talk: https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=0s
	///     Refined with Odin: https://www.youtube.com/watch?v=RZJWwn40T8E&t=11s
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	public abstract class SOValueAsset<T> : ScriptableObject
	{
		public T value;


		public void SetToValue(T newValue)
		{
			value = newValue;
		}
	}
}
