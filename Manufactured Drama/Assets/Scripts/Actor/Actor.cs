using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
