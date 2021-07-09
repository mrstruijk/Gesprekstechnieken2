using System.Collections;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
///     Class that Invokes UnityEvents at predefined times
/// </summary>
public class Eventer : MonoBehaviour
{
	public UnityEvent OnAwakeEvent;

	public UnityEvent OnStartEvent;
	[SerializeField] private float afterStartDelay;
	public UnityEvent AfterStartEvent;

	public UnityEvent OnDisableEvent;


	private void Awake()
	{
		OnAwakeEvent?.Invoke();
	}


	private void Start()
	{
		OnStartEvent?.Invoke();
		StartCoroutine(AfterStartRoutine(afterStartDelay));
	}


	private IEnumerator AfterStartRoutine(float delay)
	{
		yield return new WaitForSeconds(delay);
		AfterStartEvent?.Invoke();
	}


	private void OnDisable()
	{
		OnDisableEvent?.Invoke();
		StopAllCoroutines();
	}
}
