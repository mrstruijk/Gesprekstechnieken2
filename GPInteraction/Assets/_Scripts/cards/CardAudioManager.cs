using UnityEngine;


namespace GPInteraction._Scripts
{
	public class CardAudioManager : MonoBehaviour
	{
		public AudioClip defaultClip;

		[Range(0f, 2f)] [SerializeField] private float pitch = 1f;
		[Range(0f, 0.2f)] [SerializeField] private float pitchVariation = 0.1f;
		[Range(0f, 1f)] [SerializeField] private float volume = 1f;
		[Range(0f, 0.2f)] [SerializeField] private float volumeVariation = 0.1f;

		private AudioSource source;


		private void Awake()
		{
			source = GetComponent<AudioSource>();
		}


		public void PlayClip(AudioClip clip)
		{
			source.pitch = pitch + Random.Range(-pitchVariation, pitchVariation);
			source.volume = volume + Random.Range(-volumeVariation, volumeVariation);
			source.clip = clip;
			source.Play();
		}
	}
}