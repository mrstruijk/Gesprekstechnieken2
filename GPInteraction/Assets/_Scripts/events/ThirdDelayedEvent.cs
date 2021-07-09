using System.Collections;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
///
/// By Maarten R. Struijk Wilbrink
/// </summary>
namespace GPInteraction._Scripts.mrstruijk
{
	public class ThirdDelayedEvent : SecondDelayedEvent
	{
		[Tooltip("This is relative to the previous two delay times, so it happens x seconds after the last event")] [SerializeField]
		private float thirdRelativeDelayTime = 1f;

		public UnityEvent ThirdDelayedResponse;


		public override void OnEventRaised()
		{
			base.OnEventRaised(); // This calls OnEventRaised of it's direct parent class

			StartCoroutine(RaiseThirdDelayedResponse());
		}


		private IEnumerator RaiseThirdDelayedResponse()
		{
			yield return new WaitForSeconds(delayTime + secondRelativeDelayTime + thirdRelativeDelayTime);
			ThirdDelayedResponse?.Invoke();
		}
	}
}