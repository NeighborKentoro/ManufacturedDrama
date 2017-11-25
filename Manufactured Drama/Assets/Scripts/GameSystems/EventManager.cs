using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Actor;

namespace GameSystems {

	public class EventManager : MonoBehaviour {

		public delegate void PauseAction();
		public static event PauseAction OnPause;
		public static event PauseAction UnPause;

		public delegate void DialogueAction();
		public static event DialogueAction NextDialogue;

		public delegate void DialogueTextAction (string text);
		public static event DialogueTextAction NextDialogueText;

		public delegate void ActorNameAction (ActorName actorName);
		public static event ActorNameAction NextDialogueActorName;

		public static void PauseGame(){
			OnPause ();
		}

		public static void UnPauseGame(){
			UnPause ();
		}

		public static void SendNextDialogueText(string text) {
			NextDialogueText (text);
		}

		public static void SendNextDialogueActorName (ActorName actorName) {
			NextDialogueActorName (actorName);
		}

		public static void StartNextDialogue() {
			NextDialogue ();
		}
	}
}
