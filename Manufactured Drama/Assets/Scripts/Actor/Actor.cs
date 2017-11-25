using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystems;

namespace Actor {

	/* The entire list of characters as enums, for faster comparison than strings */
	public enum ActorName { Kinezumi, Yuimairu, Honban, Tanji, Usagi, Nemonogatari, Hiro, Seiji, Teacher, Fujiko, The_Nobody, Director };

	public class Actor : MonoBehaviour {

		/* The actor's dialogue data for the entire scene */
		public DialogueDataList dialogueData;

		/* The actor's audio source */
		private AudioSource audioSrc;

		/* The name of the actor, used for getting lines of dialogue */
		public ActorName actorName;

		/* the dialogue line index into the dialogue data list */
		private int characterLineIndex;

		// Use this for initialization
		void Start () {
			audioSrc = GetComponent<AudioSource> ();
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		/* Begins the next dialogue line
		 * WILLIAM CALL THIS FUNCTION ON THE ANIMATION EVENT */
		public void BeginDialogue () {
			PlayDialogueLine ();
			EventManager.SendNextDialogueActorName (actorName);
			EventManager.SendNextDialogueText(dialogueData.lines[characterLineIndex].text);
			NextDialogueLine();
		}

		public void PlayDialogueLine() {
			if(audioSrc.isPlaying) {
				audioSrc.Stop ();
			}
			dialogueData.PlayLine (audioSrc, characterLineIndex);
		}

		public string GetDialogueLineText() {
			return dialogueData.lines [characterLineIndex].text;
		}

		/* Increments the index to the next line */
		public void NextDialogueLine() {
			characterLineIndex++;
			if (characterLineIndex == dialogueData.lines.Count)
				characterLineIndex--;
		}

		void OnEnable () {
			EventManager.OnPause += PauseActor;
			EventManager.UnPause += UnPauseActor;
			EventManager.NextDialogue += BeginDialogue; //REMOVE THESE ONCE ANIMATION EVENTS CALL THIS FUNCTION
		}

		void OnDisable() {
			EventManager.OnPause -= PauseActor;
			EventManager.UnPause -= UnPauseActor;
			EventManager.NextDialogue -= BeginDialogue; //REMOVE THESE ONCE ANIMATION EVENTS CALL THIS FUNCTION
		}

		void PauseActor() {
			audioSrc.Pause ();
		}

		void UnPauseActor() {
			audioSrc.UnPause ();
		}
	}
}
