using GPInteraction._Scripts;
using UnityEngine;


public class MoveCollectively : MonoBehaviour
{
	private MoveBase[] moveBases;
	[SerializeField] private float tweenDuration = 1f;


	private void Awake()
	{
		moveBases = GetComponentsInChildren<MoveBase>();
	}


	public void GoToIndex(int index)
	{
		foreach (var item in moveBases)
		{
			item.MoveAndRotate(index, tweenDuration);
		}
	}


	public void FlipToIndexImmediately(int index)
	{
		foreach (var item in moveBases)
		{
			item.MoveAndRotate(index, 0);
		}
	}


	public void GoToIndexWithEvent(int index)
	{
		foreach (var item in moveBases)
		{
			item.MoveAndRotateAndEvent(index, tweenDuration);
		}
	}
}