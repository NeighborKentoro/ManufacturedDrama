using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor {
	
	[System.Serializable]
	public class DialogueLine {

		/* The audio for the dialogue line */
		public AudioClip audio;

		/* the text of the dialogue line */
		[TextArea]
		public string text;

	}
}
