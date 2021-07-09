using System.Collections;
using CrazyMinnow.SALSA;
using GPInteraction._Scripts.mrstruijk;
using UnityEngine;


namespace GPInteraction._Scripts
{
	/// <summary>
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	public class BaseConversation : MonoBehaviour
	{
		public IntReference storyLine;
		private Coroutine responseCR;


		public static BaseConversation Instance
		{
			get;
			private set;
		}


		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				Destroy(this);
			}
		}


		public IEnumerator Conversation(SOCardOptions option, EventSO doneTalking)
		{
			foreach (var response in option.cardAndResponse[storyLine.Value].response)
			{
				if (response.settings.animator != null)
				{
					responseCR = StartCoroutine(Speaking(response.preDelay, response.postDelay, response.settings.animator, response.startTrigger, response.settings.emoter, response.emoteTrigger, response.range, response.emoteStopDelay, response.clip, response.settings.source, response.volume, response.stopTrigger));
				}
				else
				{
					responseCR = StartCoroutine(Speaking(response.preDelay, response.postDelay, response.clip, response.settings.source));
				}

				yield return responseCR;
			}

			doneTalking.Raise();
		}


		private static IEnumerator Speaking(float preDelay, float postDelay, Animator anim, string animTrigger, Emoter emoter, string emoteTrigger, Vector2 emoteRange, float emoteDelay, AudioClip audio, AudioSource source, float volume, string stopTrigger)
		{
			yield return new WaitForSeconds(preDelay);
			anim.SetTrigger(animTrigger);
			source.clip = audio;
			source.volume = volume;
			source.Play();

			if (emoteTrigger != "")
			{
				var rand = Random.Range(emoteRange.x, emoteRange.y);
				emoter.ManualEmote(emoteTrigger, ExpressionComponent.ExpressionHandler.RoundTrip, audio.length + postDelay + emoteDelay, true, rand);
			}

			yield return new WaitForSeconds(audio.length + postDelay);
			anim.SetTrigger(stopTrigger);
		}


		private static IEnumerator Speaking(float preDelay, float postDelay, AudioClip audio, AudioSource source)
		{
			yield return new WaitForSeconds(preDelay);
			source.clip = audio;
			source.Play();
			yield return new WaitForSeconds(audio.length + postDelay);
		}


		private void OnDisable()
		{
			StopAllCoroutines();
		}
	}
}