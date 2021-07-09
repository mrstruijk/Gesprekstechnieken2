using UnityEngine;


public class rotatecamera : MonoBehaviour
{
	// Use this for initialization
	private void Start()
	{
	}


	// Update is called once per frame
	private void Update()
	{
		transform.Rotate(0, 20 * Time.deltaTime, 0);
	}
}