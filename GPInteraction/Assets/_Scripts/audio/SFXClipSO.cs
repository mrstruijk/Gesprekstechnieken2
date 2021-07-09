//using Sirenix.OdinInspector;
using UnityEngine;


/// <summary>
///     From: https://www.youtube.com/watch?v=bJ3Bu9kpZAA&t=298s
///     By Maarten R. Struijk Wilbrink
/// </summary>
[CreateAssetMenu(menuName = "mrstruijk/SFX Clip", fileName = "SFXClip")]
public class SFXClipSO : ScriptableObject
{
	// [Space] [Title("Audio Clip")] [Required]
	public AudioClip clip;

	// [Title("Clip Settings")]
	[Range(0f, 1f)] public float volume = 1f;

	[Range(0f, 0.2f)] public float volumeVariation = 0.05f;
	[Range(0f, 2f)] public float pitch = 1f;
	[Range(0f, 0.2f)] public float pitchVariation = 0.05f;
}
