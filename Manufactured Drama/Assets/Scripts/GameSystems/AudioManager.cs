using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace GameSystems {

	public class AudioManager : MonoBehaviour {

		/* The master audio mixer reference */
		public AudioMixer masterMixer;

		/* Sets the sound effects volume */
		public void SetSFXVolume(float sfxVolume) {
			masterMixer.SetFloat ("SFXVolume", sfxVolume);
		}

		/* Sets the voice volume */
		public void SetVoiceVolume(float voiceVolume) {
			masterMixer.SetFloat ("VoiceVolume", voiceVolume);
		}

		/* Sets the music volume */
		public void SetMusicVolume(float musicVolume) {
			masterMixer.SetFloat ("MusicVolume", musicVolume);
		}

		/* Sets the master volume */
		public void SetMasterVolume(float masterVolume) {
			masterMixer.SetFloat ("MasterVolume", masterVolume);
		}
	}
}
