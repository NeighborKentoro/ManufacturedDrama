using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Actor;

namespace GameSystems {

	/* class used for saving the state of the entire game */
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
		}
	}
}
