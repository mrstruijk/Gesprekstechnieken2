using GPInteraction._Scripts;
using TMPro;
using UnityEngine;


/// <summary>
///     Make cards inactive, and reset them to starting position.
///     By Maarten R. Struijk Wilbrink
/// </summary>
public class ResetCardsCollectively : MonoBehaviour
{
	private Collider[] colliders;
	private MoveBase[] moveBases;
	private TextMeshProUGUI[] texts;


	private void Awake()
	{
		colliders = GetComponentsInChildren<Collider>();
		moveBases = GetComponentsInChildren<MoveBase>();
		texts = GetComponentsInChildren<TextMeshProUGUI>();
	}


	public void ResetCards()
	{
		DisableColliders();
		MoveAndRotateImmediatelyToStartingPoint();
		TurnOfText();
	}


	private void DisableColliders()
	{
		foreach (var col in colliders)
		{
			col.enabled = false;
		}
	}


	private void MoveAndRotateImmediatelyToStartingPoint()
	{
		foreach (var move in moveBases)
		{
			move.MoveAndRotate(0, 0);
		}
	}


	private void TurnOfText()
	{
		foreach (var text in texts)
		{
			text.enabled = false;
		}
	}
}