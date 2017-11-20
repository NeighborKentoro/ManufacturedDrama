using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueDataList : ScriptableObject {

	public int lineIndex;

	public List<DialogueLine> lines;

	public void PlayLine(AudioSource audioSrc) {
		audioSrc.clip = lines [lineIndex].audio;
		audioSrc.Play ();
	}

	public string GetLineText() {
		return lines [lineIndex].text;
	}
}
