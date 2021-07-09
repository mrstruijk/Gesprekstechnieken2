using UnityEngine;


namespace GPInteraction._Scripts
{
	/// <summary>
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	public abstract class MoveBase : MonoBehaviour
	{
		public abstract void MoveAndRotateAndEvent(int moveIndex, float duration);
		public abstract void MoveAndRotate(int moveIndex, float duration);
	}
}