using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystems;

namespace Actor {

	public enum ActorName { Kinezumi };

	public class Actor : MonoBehaviour {

		/* The actor's dialogue data for the entire scene */
		public DialogueDataList dialogueData;

		/* The actor's audio source */
		private AudioSource audioSrc;

		/* The name of the actor, used for getting lines of dialogue */
		public ActorName actorName;

		// Use this for initialization
		void Start () {
			audioSrc = GetComponent<AudioSource> ();
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		void PlayNextLine() {
			if(audioSrc.isPlaying) {
				audioSrc.Stop ();
			}
			dialogueData.PlayLine (audioSrc, GameSystemManager.instance.GetCharacterLineIndex(actorName));
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
			audioSrc.Pause ();
		}

		void UnPauseActor() {
			Debug.Log ("Unpausing Actor");
			audioSrc.UnPause ();
		}
	}
}
