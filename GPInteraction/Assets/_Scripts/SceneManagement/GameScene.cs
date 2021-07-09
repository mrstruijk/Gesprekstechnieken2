using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


namespace GPInteraction._Scripts
{
	/// <summary>
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	public abstract class GameScene : ScriptableObject
	{
		[Header("Information")] public string sceneName;
		[TextArea] public string shortDescription;

		[Header("Sounds")] public AudioClip music;
		[Range(0.0f, 1.0f)] public float musicVolume;

		[Header("Visuals")] public PostProcessProfile postProcessing;
	}
}
