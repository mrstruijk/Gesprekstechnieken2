//using Sirenix.OdinInspector;
using UnityEngine;


namespace GPInteraction._Scripts
{
	/// <summary>
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	[CreateAssetMenu(fileName = "Menu", menuName = "mrstruijk/SceneManagement/Menu")]
	public class SOMenu : GameScene
	{
		[Header("Menu specific")]
		// [EnumToggleButtons]
		public MenuType menuType;
	}


	public enum MenuType
	{
		MainMenu,
		PauseMenu
	}
}
