using CrazyMinnow.SALSA;
using UnityEngine;


public class LookAtComponent : MonoBehaviour
{
	[SerializeField] private Eyes salsaEyeController;

	[Tooltip("The camera representing the participant HMD")] [SerializeField]
	private Transform camera;

	private float standardAffinity;

	[Tooltip("Can be empty, if character is not required to break focus from HMD participant ('camera')")] [SerializeField]
	private Transform otherObject;


	private void Awake()
	{
		GetComponents();
	}


	private void GetComponents()
	{
		if (salsaEyeController == null)
		{
			salsaEyeController = GetComponent<Eyes>();
		}

		if (camera == null)
		{
			camera = Camera.main.transform;
		}
	}


	private void Start()
	{
		salsaEyeController.lookTarget = camera;
		standardAffinity = salsaEyeController.affinityPercentage;
	}


	/// <summary>
	///     Is run from animation event (currently only used by Sofie)
	/// </summary>
	public virtual void LookAtOtherObject()
	{
		salsaEyeController.lookTarget = otherObject;
		salsaEyeController.affinityPercentage = 100f;
	}


	/// <summary>
	///     Is run from animation event (currently only used by Sofie)
	/// </summary>
	public virtual void StandardLooking()
	{
		salsaEyeController.lookTarget = camera;
		salsaEyeController.affinityPercentage = standardAffinity;
	}
}
