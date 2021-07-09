using System;
using System.Collections.Generic;
// using Sirenix.OdinInspector;
using UnityEngine;


namespace GPInteraction._Scripts
{
	/// <summary>
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	[Serializable] public class CardAndResponses
	{
		// [MultiLineProperty(7)]
		public string cardText;

		// [ListDrawerSettings(DraggableItems = true, ShowIndexLabels = false, Expanded = true, ShowItemCount = true)]
		public List<Response> response;
	}


	// [BoxGroup]
	[Serializable] public class Response
	{
		// [HorizontalGroup] [HideLabel] [ShowIf("changeHeader")]
		[SerializeField] private string header;

		// [HorizontalGroup(10)] [HideLabel]
		[SerializeField] private bool changeHeader;

		// [Title("$header", "", TitleAlignments.Centered, Bold = true, HorizontalLine = true)]
		public SpeakingSettingsSO settings;

		// [BoxGroup("Audio")] [SuffixLabel("sec", Overlay = false)]
		[Range(0f, 3f)] public float preDelay = 1f;

		// [BoxGroup("Audio")] [SuffixLabel("x100%", Overlay = false)]
		[Range(0f, 1f)] public float volume = 1f;

		// [BoxGroup("Audio")]
		public AudioClip clip;

		// [BoxGroup("Animation")] [SuffixLabel("sec", Overlay = false)]
		[Range(0f, 3f)] public float postDelay;

		// [BoxGroup("Animation")] [ValueDropdown("@settings.animTriggers")] [ShowIf("@settings.animator")]
		public string startTrigger;

		// [BoxGroup("Animation")] [ValueDropdown("@settings.animTriggers")] [ShowIf("@settings.animator")]
		public string stopTrigger = "stopSpeaking";

		// [BoxGroup("Emotes")] [ValueDropdown("@settings.emoteTriggers")] [ShowIf("@settings.animator")]
		public string emoteTrigger; // This is not the correct "showif", but the Emoter keeps disappearing...

		// [BoxGroup("Emotes")] [LabelWidth(50)] [ShowIf("emoteTrigger")] [SuffixLabel("x100%", Overlay = false)]
		public Vector2 range = new Vector2(0.75f, 1f);

		// [BoxGroup("Emotes")] [ShowIf("@settings.animator")] [SuffixLabel("sec", Overlay = false)]
		[Tooltip("Is used for emote, and is added onto the postdelay as well as the audio.clip.length")]
		[Range(0f, 7.5f)] public float emoteStopDelay = 3f;
	}
}
