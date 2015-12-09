using UnityEngine;
using System.Collections;

public class BackGroundAudio : MonoBehaviour {

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		if (GameSystem.soundEnabled == false) {
			audioSource = audioSource.GetComponent<AudioSource>();
			audioSource.mute = true;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
