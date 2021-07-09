using UnityEngine;
using UnityEngine.Events;


namespace GPInteraction._Scripts.mrstruijk
{
    /// <summary>
    ///     Checks with the AudioSource on the same level of the GameObject to see if it is now playing,
    ///     and when it is done playing, it will fire a UnityEvent stating that we're done playing.
    /// </summary>
    public class AudioClipIsDonePlaying : MonoBehaviour
	{
		private AudioSource source;
		public UnityEvent DonePlaying;
		private bool hasStarted;


		private void Awake()
		{
			source = GetComponent<AudioSource>();
		}


		private void Update()
		{
			if (hasStarted == true && source.isPlaying == false)
			{
				DonePlaying.Invoke();
				source.clip = null;
				hasStarted = false;
			}
			else if (source.isPlaying == true)
			{
				hasStarted = true;
			}
		}
	}
}
