using System.Collections.Generic;
using CrazyMinnow.SALSA;
// using Sirenix.OdinInspector;
using UnityEngine;


namespace GPInteraction._Scripts
{
	[CreateAssetMenu(fileName = "SpeakingSettings", menuName = "mrstruijk/SpeakingSettings")]
	public class SpeakingSettingsSO : ScriptableObject
	{
		// [ReadOnly]
		[Header("Audio and Animation settings")]
		public AudioSource source;

		// [ReadOnly] [ShowIf("animator")]
		public Animator animator;
		[HideInInspector] public List<string> animTriggers = new List<string>();
		// [ReadOnly] [ShowIf("emoter")]
		public Emoter emoter;
		[HideInInspector] public List<string> emoteTriggers = new List<string>();


		private void OnEnable()
		{
			PopulateTriggers();
		}


        /// <summary>
        ///     This is also run from the Eventer (on Start), since it didn't autopopulate new triggers...
        /// </summary>
        public void PopulateTriggers()
		{
			PopulateAnimTriggers();
			PopulateEmoteTriggers();
		}


		private void PopulateAnimTriggers()
		{
			if (animator == null)
			{
				return;
			}

			animTriggers.Clear();

			foreach (var trig in animator.parameters)
			{
				animTriggers.Add(trig.name);
			}
		}


		private void PopulateEmoteTriggers()
		{
			if (emoter == null)
			{
				return;
			}

			emoteTriggers.Clear();

			emoteTriggers.Add(""); // Add a blank one

			foreach (var emote in emoter.emotes)
			{
				emoteTriggers.Add(emote.expData.name);
			}
		}
	}
}
