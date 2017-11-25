using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystems;
using Actor;
using UnityEngine.UI;

namespace UI {

	public class UIActorName : MonoBehaviour {

		public Text textArea; 

		// Use this for initialization
		void Start () {
			textArea = GetComponent<Text> ();
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		void OnEnable () {
			EventManager.NextDialogueActorName += SetActorName;
		}

		void OnDisable() {
			EventManager.NextDialogueActorName -= SetActorName;
		}

		void SetActorName (ActorName actorName) {
			textArea.text = actorName.ToString();
		}
	}
}