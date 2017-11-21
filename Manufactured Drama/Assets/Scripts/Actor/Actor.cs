using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystems;

namespace Actor {

	public class Actor : MonoBehaviour {

		/* The actor's dialogue data for the entire scene */
		public DialogueDataList dialogueData;

		/* The actor's audio source */
		private AudioSource audioSrc;

		// Use this for initialization
		void Start () {
			audioSrc = GetComponent<AudioSource> ();
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		void PlayNextLine() {
			dialogueData.PlayLine (audioSrc);
		}

		void OnEnable () {
			EventManager.OnPause += PauseActor;
			EventManager.UnPause += UnPauseActor;
		}

		void OnDisable() {
			EventManager.OnPause -= PauseActor;
			EventManager.UnPause -= UnPauseActor;
		}

		void PauseActor() {
			Debug.Log ("Pausing Actor");
		}

		void UnPauseActor() {
			Debug.Log ("Unpausing Actor");
		}
	}
}
