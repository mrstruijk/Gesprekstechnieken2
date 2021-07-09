using System.Collections.Generic;
// using Sirenix.OdinInspector;
using UnityEngine;


/// <summary>
///     From: https://www.youtube.com/watch?v=bJ3Bu9kpZAA&t=298s
/// </summary>
public class SFXManager : MonoBehaviour
{
	private static SFXManager _instance;

	public static SFXManager instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<SFXManager>();
			}

			return _instance;
		}
	}

	// [HorizontalGroup("AudioSource")]
	[SerializeField] private AudioSource defaultAudioSource;

	// [TabGroup("UI")] [AssetList(Path = "/_Audio/UI SFX", AutoPopulate = true)]
	public List<SFXClipSO> uiSFX;

	// [TabGroup("Ambient")] [AssetList(Path = "/_Audio/Ambient SFX", AutoPopulate = true)]
	public List<SFXClipSO> ambientSFX;

	// [TabGroup("Card")] [AssetList(Path = "/_Audio/Card SFX", AutoPopulate = true)]
	public List<SFXClipSO> cardSFX;


	public static void PlaySFX(SFXClipSO sfx, bool waitToFinish = true, AudioSource audioSource = null)
	{
		if (audioSource == null)
		{
			audioSource = instance.defaultAudioSource;
		}

		if (audioSource == null)
		{
			Debug.LogError("You forgot to add a default audio source!");
			return;
		}

		if (!audioSource.isPlaying || !waitToFinish)
		{
			audioSource.clip = sfx.clip;
			audioSource.volume = sfx.volume + Random.Range(-sfx.volumeVariation, sfx.volumeVariation);
			audioSource.pitch = sfx.pitch + Random.Range(-sfx.pitchVariation, sfx.pitchVariation);
			audioSource.Play();
		}
	}


	// [HorizontalGroup("AudioSource")] [ShowIf("@defaultAudioSource == null")] [GUIColor(1f, 0.5f, 0.5f)] [Button]
	private void AddAudioSource()
	{
		defaultAudioSource = gameObject.GetComponent<AudioSource>();

		if (defaultAudioSource == null)
		{
			defaultAudioSource = gameObject.AddComponent<AudioSource>();
		}
	}


	public enum SFXType
	{
		UI,
		Ambient,
		Cards
	}
}
