using System;
// using Sirenix.OdinInspector;
using UnityEngine;


namespace GPInteraction._Scripts
{
	[CreateAssetMenu(fileName = "Card Settings", menuName = "mrstruijk/CardSettings")]
	public class CardSettingsSO : ScriptableObject
	{
		// [ListDrawerSettings(Expanded = true, DraggableItems = true, ShowIndexLabels = true)]
		[SerializeField] private TransformPlusOffset[] transformsPlusOffset;


		public Vector3 Location(int index)
		{
			return transformsPlusOffset[index].trans.position + transformsPlusOffset[index].locationOffset;
		}


		public Vector3 Rotation(int index)
		{
			return transformsPlusOffset[index].trans.rotation.eulerAngles + transformsPlusOffset[index].rotionOffset;
		}


		[Range(0f, 3f)] [SerializeField] private float cardDelayTime = 1f;


		public float CardDelayTime
		{
			get => cardDelayTime;
		}
	}


	[Serializable] public class TransformPlusOffset
	{
		public Vector3 Location()
		{
			return trans.position + locationOffset;
		}


		public Vector3 Rotation()
		{
			return trans.rotation.eulerAngles + rotionOffset;
		}


		public Transform trans;
		public Vector3 locationOffset;
		public Vector3 rotionOffset;
	}
}
