using System.Collections;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
///
/// By Maarten R. Struijk Wilbrink
/// </summary>
namespace GPInteraction._Scripts.mrstruijk
{
	public class SecondDelayedEvent : GameEventUnityEventLinker
	{
		[Tooltip("This is relative to the previous delay time, so it happens x seconds after the last event")] [SerializeField]
		protected float secondRelativeDelayTime = 1f;

		public UnityEvent SecondDelayedResponse;


		public override void OnEventRaised()
		{
			base.OnEventRaised();
			StartCoroutine(RaiseSecondDelayedResponse());
		}


		private IEnumerator RaiseSecondDelayedResponse()
		{
			yield return new WaitForSeconds(delayTime + secondRelativeDelayTime);
			SecondDelayedResponse?.Invoke();
		}
	}
}