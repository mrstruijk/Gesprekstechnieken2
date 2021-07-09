using UnityEngine;


namespace GPInteraction._Scripts.mrstruijk
{
    /// <summary>
    ///     Attach to gameobject, and enable bool dontDestroy, to make sure it stays loaded between scenes
    /// </summary>
    public class DontDestroyOnLoad : MonoBehaviour
	{
		[SerializeField] private bool dontDestroy = true;


		private void Awake()
		{
			if (dontDestroy)
			{
				DontDestroyOnLoad(gameObject); // Make sure it's persistent over multiple scenes
			}
		}
	}
}
