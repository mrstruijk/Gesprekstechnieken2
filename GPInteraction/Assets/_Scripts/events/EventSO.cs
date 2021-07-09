using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace GPInteraction._Scripts.mrstruijk
{
	/// <summary>
	///     Adapted from: https://github.com/roboryantron/Unite2017/blob/master/Assets/Code/Events/GameEvent.cs
	///     The UnityAction allows for the same GameWideEventSO to be set in a receiving script (e.g. via Inspector), and have
	///     a specific method be registered with the 'actionResponse' in code (using gameWideEventName.actionResponse += MethodName).
	///     Remember to deregister the UnityAction (using gameWideEventName.actionResponse -= MethodName).
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	[CreateAssetMenu(fileName = "EventSO", menuName = "mrstruijk/Event")]
	public class EventSO : ScriptableObject
	{
		private readonly List<GameEventUnityEventLinker> listeners = new List<GameEventUnityEventLinker>();
		public UnityAction actionResponse;


		/// <summary>
		///     Calls all UnityEvent listeners (SOEventListenerWithUnityEventResponse) to Invoke a UnityEvent
		///     Also calls local 'actionResponse' UnityAction, which allows this SO to function both as a sender and local receiver
		///     of calls.
		/// </summary>
		public void Raise()
		{
			if (listeners.Count != 0)
			{
				for (var i = listeners.Count - 1; i >= 0; i--)
				{
					listeners[i].OnEventRaised();
				}
			}

			actionResponse?.Invoke();
		}


		public void RegisterListener(GameEventUnityEventLinker listener)
		{
			if (!listeners.Contains(listener))
			{
				listeners.Add(listener);
			}
		}


		public void UnregisterListener(GameEventUnityEventLinker listener)
		{
			if (listeners.Contains(listener))
			{
				listeners.Remove(listener);
			}
		}
	}
}