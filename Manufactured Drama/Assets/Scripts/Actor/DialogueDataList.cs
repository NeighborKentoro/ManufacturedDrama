using System.Collections.Generic;
using UnityEngine;

namespace Actor {

	[CreateAssetMenu]
	public class DialogueDataList : ScriptableObject {

		public List<DialogueLine> lines;

		public void PlayLine(AudioSource audioSrc, int lineIndex) {
			audioSrc.clip = lines [lineIndex].audio;
			audioSrc.Play ();
		}

		public string GetLineText(int lineIndex) {
			return lines [lineIndex].text;
		}
	}
}
