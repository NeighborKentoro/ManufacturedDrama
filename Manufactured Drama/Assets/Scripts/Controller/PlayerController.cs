using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystems;

namespace Controller {
	
	public class PlayerController : MonoBehaviour {

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			if(Input.GetMouseButtonDown (0) && !GameSystemManager.instance.IsGamePaused()) {
				//this is where the code move the animation forward would go. I am not sure how the animation controller triggers things, so I will have to wait
				EventManager.StartNextDialogue(); //use this in the meantime for testing
			}
			if(Input.GetMouseButtonDown(1) && !GameSystemManager.instance.IsGamePaused()) {
				EventManager.PauseGame ();
			}
			else if(Input.GetMouseButtonDown(1)) {
				EventManager.UnPauseGame ();
			}
		}
	}
}