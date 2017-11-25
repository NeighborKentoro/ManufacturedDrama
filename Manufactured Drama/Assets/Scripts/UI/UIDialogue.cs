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
			text = "Hi William, I hope everything is going smoothly with the project. I haven't finished everything yet, but I'm getting there. I will need to read the lines from the dialogue data, but for now this is hardcoded.";
			StartCoroutine (PrintTextToUI());
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		void OnEnable () {
			EventManager.OnPause += PauseUIDialogue;
			EventManager.UnPause += UnPauseUIDialogue;
		}

		void OnDisable() {
			EventManager.OnPause -= PauseUIDialogue;
			EventManager.UnPause -= UnPauseUIDialogue;
		}

		#region Event Functions
		void PauseUIDialogue() {
			dialoguePaused = true;
		}

		void UnPauseUIDialogue() {
			dialoguePaused = false;
		}


		#endregion

		/* adds the text from the dialogue line to the text UI object */
		IEnumerator PrintTextToUI() {
			/* stopping condition */
			if(charIndex == text.Length) {
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
			textArea.text = "";
			StartCoroutine (PrintTextToUI ());
		}
	}
}
