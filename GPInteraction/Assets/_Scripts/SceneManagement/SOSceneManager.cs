using System.Collections.Generic;
// using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace GPInteraction._Scripts
{
	/// <summary>
	///     Adapted from https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadSceneAsync.html
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	[CreateAssetMenu(fileName = "SceneManger", menuName = "mrstruijk/SceneManagement/SceneManager")]
	public class SOSceneManager : ScriptableObject
	{
		// [ListDrawerSettings(Expanded = true, DraggableItems = false, ShowIndexLabels = true)]
		public List<SOLevel> levels = new List<SOLevel>();

		// [ListDrawerSettings(Expanded = true, DraggableItems = false, ShowIndexLabels = true)]
		public List<SOMenu> menus = new List<SOMenu>();

		private int currentLevelIndex = 1;


		//Load a scene with a given index
		public void LoadLevelWithIndex(int index)
		{
			if (index <= levels.Count)
			{
				SceneManager.LoadSceneAsync(levels[index].name);
			}
			//reset the index if we have no more levels
			else
			{
				currentLevelIndex = 1;
			}
		}


		//Start next level
		public void NextLevel()
		{
			currentLevelIndex++;
			LoadLevelWithIndex(currentLevelIndex);
		}


		//Restart current level
		public void RestartLevel()
		{
			LoadLevelWithIndex(currentLevelIndex);
		}


		//Load main Menu
		public void LoadMainMenu()
		{
			SceneManager.LoadSceneAsync(menus[(int) MenuType.MainMenu].sceneName);
		}


		//Load Pause Menu
		public void LoadPauseMenu()
		{
			SceneManager.LoadSceneAsync(menus[(int) MenuType.PauseMenu].sceneName);
		}
	}
}
