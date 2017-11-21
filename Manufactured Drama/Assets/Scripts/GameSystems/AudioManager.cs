using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace GameSystems {

	public class AudioManager : MonoBehaviour {

		public AudioMixer masterMixer;

		public void SetSFXVolume(float sfxVolume) {
			masterMixer.SetFloat ("SFXVolume", sfxVolume);
		}

		public void SetVoiceVolume(float voiceVolume) {
			masterMixer.SetFloat ("VoiceVolume", voiceVolume);
		}

		public void SetMusicVolume(float musicVolume) {
			masterMixer.SetFloat ("MusicVolume", musicVolume);
		}

		public void SetMasterVolume(float masterVolume) {
			masterMixer.SetFloat ("MasterVolume", masterVolume);
		}
	}
}
