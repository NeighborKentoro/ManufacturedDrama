using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystems;
using UnityEngine.UI;

namespace UI {
	public class UIDialogue : MonoBehaviour {

		/* used for preventing the text from reading out when the game pauses */
		public bool dialoguePaused = false;

		/* the area the text will display in the UI */
		private Text textArea;

		/* the speed the text will read into the UI system */
		private float textSpeed;

		/* the current line of text being read into the UI system */
		private string text;

		/* the index into the dialogue line */
		private int charIndex = 0;

		// Use this for initialization
		void Start () {
			textArea = GetComponent<Text> ();
			textSpeed = GameSystemManager.instance.GameOptions ().textSpeed;
			StartCoroutine (PrintTextToUI());
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		void OnEnable () {
			EventManager.OnPause += PauseUIDialogue;
			EventManager.UnPause += UnPauseUIDialogue;
			EventManager.NextDialogueText += GetNextDialogue;
		}

		void OnDisable() {
			EventManager.OnPause -= PauseUIDialogue;
			EventManager.UnPause -= UnPauseUIDialogue;
			EventManager.NextDialogueText -= GetNextDialogue;
		}

		#region Event Functions
		void PauseUIDialogue() {
			dialoguePaused = true;
		}

		void UnPauseUIDialogue() {
			dialoguePaused = false;
		}

		/* gets the next line of dialogue text, stops the previous one 
		 * if it is running and starts reading out the new line */
		void GetNextDialogue (string text) {
			StopAllCoroutines ();
			this.text = text;
			StartReadingText ();
		}
		#endregion

		/* adds the text from the dialogue line to the text UI object */
		IEnumerator PrintTextToUI() {
			/* stopping conditions */
			if(text == null) {
				yield break;
			}
			else if(charIndex >= text.Length) {
				charIndex = 0;
				yield break;
			}

			/* pauses text reading if the game is paused */
			while(dialoguePaused) {
				yield return null;
			}

			/* add the text, increment the index into the line, and wait 
			 * for a little time before the next character is printed */
			textArea.text = textArea.text + text[charIndex];
			charIndex++;
			yield return new WaitForSeconds (textSpeed);
			StartCoroutine (PrintTextToUI ());
		}

		/* The function to begin reading in the text */
		public void StartReadingText() {
			charIndex = 0;
			textArea.text = "";
			StartCoroutine (PrintTextToUI ());
		}
	}
}
