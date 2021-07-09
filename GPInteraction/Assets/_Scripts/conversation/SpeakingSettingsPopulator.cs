using CrazyMinnow.SALSA;
using UnityEngine;


namespace GPInteraction._Scripts
{
	/// <summary>
	///     This finds the various components needed in the SpeakingSettings on the CharacterModel.
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	public class SpeakingSettingsPopulator : MonoBehaviour
	{
		public SpeakingSettingsSO speakingSettings;


		public void Awake()
		{
			SpeakingSettings();
		}


		private void SpeakingSettings()
		{
			if (speakingSettings.source == null)
			{
				speakingSettings.source = GetComponentInChildren<AudioSource>();
			}

			if (speakingSettings.animator == null)
			{
				speakingSettings.animator = GetComponentInChildren<Animator>();
			}

			if (speakingSettings.emoter == null)
			{
				speakingSettings.emoter = GetComponentInChildren<Emoter>();
			}
		}
	}
}