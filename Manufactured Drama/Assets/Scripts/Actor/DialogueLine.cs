using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor {
	
	[System.Serializable]
	public class DialogueLine {

		public AudioClip audio;

		[TextArea]
		public string text;

	}
}
