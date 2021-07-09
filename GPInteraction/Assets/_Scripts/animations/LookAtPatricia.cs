using System.Collections;
using UnityEngine;


/// <summary>
///     Not pretty but it works. Allows for temporarily focus on other gameObject.
///     Is used when teen (Sofie) is temporarily distracted by woman walking past window.
/// </summary>
public class LookAtPatricia : LookAtComponent
{
	[SerializeField] private GameObject patricia;


	public override void LookAtOtherObject()
	{
		patricia.SetActive(true);
		base.LookAtOtherObject();
	}


	public override void StandardLooking()
	{
		base.StandardLooking();
		StartCoroutine(TurnPatriciaOffInAWhile());
	}


	private IEnumerator TurnPatriciaOffInAWhile()
	{
		yield return new WaitForSeconds(10f);
		patricia.SetActive(false);
	}


	private void OnDisable()
	{
		StopAllCoroutines();
	}
}