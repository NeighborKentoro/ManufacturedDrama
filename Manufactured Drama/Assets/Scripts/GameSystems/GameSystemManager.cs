using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Actor;

namespace GameSystems {
	
	public class GameSystemManager : MonoBehaviour {

		/* The options set for the game */
		private GameOptions gameOptions;

		/* The current state of the game */
		private GameState gameState;

		/* The instance of the GameSystemManager */
		public static GameSystemManager instance = null;

		/* the entire list of actors for the scene */
		private GameObject[] actors;

		/* is the game paused? */
		private bool isGamePaused = false;

		//Awake is always called before any Start functions
		void Awake()
		{
			//Check if instance already exists
			if (instance == null)
				//if not, set instance to this
				instance = this;
			//If instance already exists and it's not this:
			else if (instance != this)
				//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
				Destroy (gameObject);    
			//Sets this to not be destroyed when reloading scene
			DontDestroyOnLoad (gameObject);

			gameOptions = new GameOptions();
			gameState = new GameState();
		}

		void Start () {
			
		}

		void OnEnable () {
			EventManager.OnPause += PauseGame;
			EventManager.UnPause += UnPauseGame;
		}

		void OnDisable () {
			EventManager.OnPause -= PauseGame;
			EventManager.UnPause -= UnPauseGame;
		}

		#region Event Functions
		void PauseGame () {
			isGamePaused = true;
		}

		void UnPauseGame () {
			isGamePaused = false;
		}
		#endregion

		public bool IsGamePaused () {
			return isGamePaused;
		}

		#region GameOptions Functions
		/* returns the gameOptions */
		public GameOptions GameOptions () {
			return gameOptions;
		}

		public float TextSpeed () {
			return gameOptions.textSpeed;
		}
		#endregion

		#region GameState Functions
		/* returns the gameState */
		public GameState GameState () {
			return gameState;
		}
		#endregion

		private void GetAllActors() {
			actors = GameObject.FindGameObjectsWithTag ("Actor");
		}
	}
}
