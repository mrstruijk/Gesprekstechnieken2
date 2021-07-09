using System.Collections;
using UnityEngine;


namespace GPInteraction._Scripts.mrstruijk
{
    /// <summary>
    ///     This only uses MoveTowards position.
    ///     Rotation is not taken into account.
    ///     Uses real world position (as opposed to localPosition)
    ///     Can be set to slower, by using higher moveIntervalSec
    /// </summary>
    public class MoveToWorldPositionScript : MonoBehaviour
	{
		[SerializeField] private GameObject target;

		[Tooltip("Speed to move towards target")]
		public float moveVelocity = 5f;

		[Range(0.5f, 30f)] public float moveIntervalSec = 1f;


		private void Start()
		{
			if (target != null)
			{
				StartCoroutine(MoveToWorldPosition(moveIntervalSec));
			}
		}


		private IEnumerator MoveToWorldPosition(float waitTime)
		{
			if (target.activeInHierarchy != true)
			{
				yield break;
			}

			for (;;)
			{
				var step = moveVelocity * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

				yield return new WaitForSeconds(waitTime);
			}
		}
	}
}