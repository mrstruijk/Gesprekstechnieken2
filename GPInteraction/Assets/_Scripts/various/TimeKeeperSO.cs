using System;
using UnityEngine;


namespace GPInteraction._Scripts.mrstruijk
{
	/// <summary>
	///     By Maarten R. Struijk Wilbrink
	/// </summary>
	[CreateAssetMenu(fileName = "TimeKeeper", menuName = "mrstruijk/TimeKeeper")]
	public class TimeKeeperSO : ScriptableObject
	{
		public long CurrentEpochMS()
		{
			var t = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
			var msNow = (long) t.TotalMilliseconds;
			return msNow;
		}


		public string CurrentTime()
		{
			var t = DateTimeOffset.FromUnixTimeMilliseconds(CurrentEpochMS()).DateTime.ToString("HH:mm:ss");
			return t;
		}
	}
}
