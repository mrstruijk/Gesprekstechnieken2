using DG.Tweening;
using GPInteraction._Scripts;
using UnityEngine;
using UnityEngine.Events;


public class MoveUsingDOTweenWithTransforms : MoveBase
{
	[SerializeField] private TransformPlusOffset[] transformPlusOffset;

	public UnityEvent TweenComplete;


	public override void MoveAndRotate(int moveIndex, float duration)
	{
		transform.DOMove(transformPlusOffset[moveIndex].Location(), duration);
		transform.DOLocalRotate(transformPlusOffset[moveIndex].Rotation(), duration);
	}


	public override void MoveAndRotateAndEvent(int moveIndex, float duration)
	{
		transform.DOMove(transformPlusOffset[moveIndex].Location(), duration).onComplete += InvokeEvent;
		transform.DOLocalRotate(transformPlusOffset[moveIndex].Rotation(), duration);
	}


	private void InvokeEvent()
	{
		TweenComplete?.Invoke();
	}
}