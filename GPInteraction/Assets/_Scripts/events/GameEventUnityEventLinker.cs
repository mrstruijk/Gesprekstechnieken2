using System.Collections;
using UnityEngine;
using UnityEngine.Events;


namespace GPInteraction._Scripts.mrstruijk
{
	/// <summary>
	///     Based on: https://github.com/roboryantron/Unite2017/blob/master/Assets/Code/Events/GameEventListener.cs
	///     Edited by Maarten R. Struijk Wilbrink
	/// </summary>
	public class GameEventUnityEventLinker : MonoBehaviour
	{
		public EventSO Event;
		public UnityEvent Response;
		[SerializeField] protected float delayTime = 1f;
		public UnityEvent DelayedResponse;


		private void OnEnable()
		{
			Event.RegisterListener(this);
		}


		public virtual void OnEventRaised()
		{
			Response?.Invoke();
			StartCoroutine(RaiseDelayedResponse());
		}


		private IEnumerator RaiseDelayedResponse()
		{
			yield return new WaitForSeconds(delayTime);
			DelayedResponse?.Invoke();
		}


		private void OnDisable()
		{
			Event.UnregisterListener(this);
			StopAllCoroutines();
		}
	}
}