using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems {

	public class EventManager : MonoBehaviour {

		public delegate void PauseAction();
		public static event PauseAction OnPause;
		public static event PauseAction UnPause;

		public static void PauseGame(){
			OnPause ();
		}

		public static void UnPauseGame(){
			UnPause ();
		}
	}
}
