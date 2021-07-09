using System.Collections;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof (Collider))] public class CardChooser : MonoBehaviour
{
	public GameObject cardChooserBox;
	public UnityEvent eventUponChoosingCard;
	[SerializeField] private float chooseDelayTime = 2f;


	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject != cardChooserBox)
		{
			return;
		}

		StartCoroutine(ChooseCardAfterDelay(chooseDelayTime, other));
	}


	private IEnumerator ChooseCardAfterDelay(float delay, Collider other)
	{
		eventUponChoosingCard?.Invoke();
		other.enabled = false;
		yield return new WaitForSeconds(delay);
		other.enabled = true;
	}
}