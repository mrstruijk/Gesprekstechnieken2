using System.Collections;
using GPInteraction._Scripts.mrstruijk;
//using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
///     Basic fade in/out operations
/// </summary>
public class ChangeAlpha : MonoBehaviour
{
	[SerializeField] private Image image;
	[SerializeField] private EventSO alphaToZeroComplete;
	[SerializeField] private EventSO alphaToOneComplete;


	private void Awake()
	{
		if (image == null)
		{
			image = GetComponent<Image>();
		}
	}


	// [Button]
	public void SetAlphaToZero()
	{
		StartCoroutine(ChangeAlphaToZero());
	}


	private IEnumerator ChangeAlphaToZero()
	{
		var startAlpha = image.color.a;
		var alpha = startAlpha;

		while (alpha > 0)
		{
			alpha -= 0.05f;
			image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
			yield return new WaitForSeconds(0.05f);
		}

		alphaToZeroComplete.Raise();
	}


	// [Button]
	public void SetAlphaToOne()
	{
		StartCoroutine(ChangeAlphaToOne());
	}


	private IEnumerator ChangeAlphaToOne()
	{
		var startAlpha = image.color.a;
		var alpha = startAlpha;

		while (alpha < 1)
		{
			alpha += 0.05f;
			image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
			yield return new WaitForSeconds(0.05f);
		}

		alphaToOneComplete.Raise();
	}


	private void OnDisable()
	{
		StopAllCoroutines();
	}
}
