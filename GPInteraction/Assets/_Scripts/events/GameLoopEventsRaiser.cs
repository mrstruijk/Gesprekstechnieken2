using System.Collections;
using GPInteraction._Scripts.mrstruijk;
using UnityEngine;


/// <summary>
///     By Maarten R. Struijk Wilbrink
/// </summary>
public class GameLoopEventsRaiser : MonoBehaviour
{
	[SerializeField] private EventSO onAwakeEvent;
	[SerializeField] private EventSO onStartEvent;
	[SerializeField] private float afterStartDelay;
	[SerializeField] private EventSO afterStartEvent;
	[SerializeField] private EventSO onUpdateEvent;
	[SerializeField] private EventSO onDisableEvent;


	private void Awake()
	{
		onAwakeEvent.Raise();
	}


	private void Start()
	{
		onStartEvent.Raise();
		StartCoroutine(AfterStartEvent());
	}


	private IEnumerator AfterStartEvent()
	{
		yield return new WaitForSeconds(afterStartDelay);
		afterStartEvent.Raise();
	}


	private void Update()
	{
		onUpdateEvent.Raise();
	}


	private void OnDisable()
	{
		onDisableEvent.Raise();
		StopAllCoroutines();
	}
}