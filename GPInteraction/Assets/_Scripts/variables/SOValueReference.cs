//using Sirenix.OdinInspector;
using UnityEngine;


namespace GPInteraction._Scripts
{
	/// <summary>
	///     Based on Ryan Hipple's 2017 talk: https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=0s
	///     Refined with Odin: https://www.youtube.com/watch?v=RZJWwn40T8E&t=11s
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	// [InlineProperty] [LabelWidth(75)]
	public abstract class SOValueReference<TValue, TAsset> where TAsset : SOValueAsset<TValue>
	{
		// [HorizontalGroup("Reference", MaxWidth = 100)] [ValueDropdown("valueList")] [HideLabel]
		[SerializeField] protected bool useValue = false;

		// [ShowIf("@useValue == true", Animate = true)] [HorizontalGroup("Reference")] [HideLabel]
		[SerializeField] protected TValue _value;

		// [ShowIf("@useValue == false", Animate = true)] [HorizontalGroup("Reference")] [OnValueChanged("UpdateAsset")] [HideLabel]
		[SerializeField] protected TAsset assetReference;

		// [ShowIf("@assetReference != null && useValue == false")] [LabelWidth(100)]
		[Tooltip("Directly edit the referenced Scriptable Object in Project folder")]
		[SerializeField] protected bool editSOAsset = false;

		// [ShowIf("@assetReference != null && useValue == false")] [ShowIf("editSOAsset")] [InlineEditor(InlineEditorObjectFieldModes.Hidden)]
		[SerializeField] protected TAsset _assetReference;


		/*
		private static ValueDropdownList<bool> valueList = new ValueDropdownList<bool>
		{
			{"Reference", false},
			{"Value", true},
		};
		*/


		public TValue Value
		{
			get
			{
				if (assetReference == null || useValue == true)
				{
					return _value;
				}

				return assetReference.value;
			}
		}


		protected void UpdateAsset()
		{
			_assetReference = assetReference;
		}
	}
}
