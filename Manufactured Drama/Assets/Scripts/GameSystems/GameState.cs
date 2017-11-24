using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Actor;

namespace GameSystems {
	
	[System.Serializable]
	public class GameState {

		/* the chapter number */
		public int chapter;

		/* the scene number */
		public int scene;

		/* The line indices for each character in the game */
		public int[] characterLineIndices; 

		public GameState () {

			characterLineIndices = new int[Enum.GetValues(typeof(ActorName)).Length];
			Debug.Log (Enum.GetValues (typeof(ActorName)).Length);
		}
	}
}
