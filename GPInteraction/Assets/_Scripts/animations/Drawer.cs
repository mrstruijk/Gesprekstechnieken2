using UnityEngine;


/// <summary>
///     This inelegant script allows for the pad and pencil to be attached to Olivia's hand in the 'Olivia Drawing' animation.
///     The pad is being placed back onto the starting location once the 'stopAnimation' trigger is hit.
///     By Maarten R. Struijk Wilbrink
/// </summary>
public class Drawer : MonoBehaviour
{
	[Tooltip("The (empty) GameObject which represents Olivia's hand for her to hold the pencil correctly")]
	[SerializeField] private GameObject pencilGrab;

	[Tooltip("The (empty) GameObject which represents Olivia's hand for her to hold the pad correctly")]
	[SerializeField] private GameObject padPlacer;

	[Tooltip("The pad in question")] [SerializeField]
	private GameObject pad;

	private Vector3 padStartPos;
	private Quaternion padStartRot;

	[Tooltip("The pencil")] [SerializeField]
	private GameObject pencil;

	private Vector3 pencilStartPos;
	private Quaternion pencilStartRot;


	private void Start()
	{
		SaveStartLocation();
	}


	private void SaveStartLocation()
	{
		padStartPos = pad.transform.position;
		padStartRot = pad.transform.rotation;

		pencilStartPos = pencil.transform.position;
		pencilStartRot = pencil.transform.rotation;
	}


	/// <summary>
	///     Is run as an animation Event from the 'Olivia Drawing' animation state
	/// </summary>
	public void StartDrawing()
	{
		pad.transform.SetParent(padPlacer.transform);
		pad.transform.localPosition = new Vector3(0, 0, 0);
		pad.transform.localRotation = new Quaternion(0, 0, 0, 0);

		pencil.transform.SetParent(pencilGrab.transform);
		pencil.transform.localPosition = new Vector3(0, 0, 0);
		pencil.transform.localRotation = new Quaternion(0, 0, 0, 0);
	}


	/// <summary>
	///     Is run as an animation Event from the 'StopDrawing' animation state
	/// </summary>
	public void StopDrawing()
	{
		pad.transform.SetParent(null);
		pencil.transform.SetParent(null);
		ReturnToStartLocation();
	}


	private void ReturnToStartLocation()
	{
		pad.transform.position = padStartPos;
		pad.transform.rotation = padStartRot;

		pencil.transform.position = pencilStartPos;
		pencil.transform.rotation = pencilStartRot;
	}
}
