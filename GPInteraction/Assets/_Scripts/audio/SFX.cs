using System;
using System.Collections.Generic;
//using Sirenix.OdinInspector;
using UnityEngine;


/// <summary>
///     From: https://www.youtube.com/watch?v=bJ3Bu9kpZAA&t=298s
/// </summary>
[Serializable] public class SFX
{
	// [LabelText("SFX Type")] [LabelWidth(100)] [OnValueChanged("SFXChange")] [InlineButton("PlaySFX")]
	public SFXManager.SFXType sfxType = SFXManager.SFXType.UI;

	// [LabelText("$sfxLabel")] [LabelWidth(100)] [ValueDropdown("SFXType")] [OnValueChanged("SFXChange")] [InlineButton("SelectSFX")]
	public SFXClipSO sfxToPlay;

	private string sfxLabel = "SFX";

	[SerializeField] private bool showSettings;

	// [ShowIf("showSettings")] [SerializeField]
	private bool editSettings;

	// [InlineEditor(InlineEditorObjectFieldModes.Hidden)] [ShowIf("showSettings")] [EnableIf("editSettings")]
	[SerializeField]
	private SFXClipSO _sfxBase;

	// [Title("Audio Source")] [ShowIf("showSettings")] [EnableIf("editSettings")]
	[SerializeField]
	private bool waitToPlay = true;

	// [ShowIf("showSettings")] [EnableIf("editSettings")]
	[SerializeField]
	private bool useDefault = true;

	// [DisableIf("useDefault")] [ShowIf("showSettings")] [EnableIf("editSettings")]
	[SerializeField]
	private AudioSource audiosource;


	public void PlaySFX()
	{
		if (useDefault || audiosource == null)
		{
			SFXManager.PlaySFX(sfxToPlay, waitToPlay);
		}
		else
		{
			SFXManager.PlaySFX(sfxToPlay, waitToPlay, audiosource);
		}
	}


	private void SFXChange()
	{
		sfxLabel = sfxType + " SFX"; //keep the label up to date

		_sfxBase = sfxToPlay; //keep the displayed "SFX clip" up to date
	}


	private void SelectSFX()
	{
		// UnityEditor.Selection.activeObject = sfxToPlay; // This gave errors
	}


	private List<SFXClipSO> SFXType() //Get's list of SFX from manager, used in the inspector
	{
		List<SFXClipSO> sfxList;

		switch (sfxType)
		{
			case SFXManager.SFXType.UI:
				sfxList = SFXManager.instance.uiSFX;
				break;

			case SFXManager.SFXType.Ambient:
				sfxList = SFXManager.instance.ambientSFX;
				break;

			case SFXManager.SFXType.Cards:
				sfxList = SFXManager.instance.cardSFX;
				break;

			default:
				sfxList = SFXManager.instance.uiSFX;
				break;
		}

		return sfxList;
	}
}
