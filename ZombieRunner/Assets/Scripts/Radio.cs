using UnityEngine;
using System.Collections;

public class Radio : MonoBehaviour {

	public AudioClip[] radioMessages;
	public AudioClip whatHappened;
	public AudioClip areaLibera;

	private AudioSource radioSource;
	private AudioSource innerThought;

	// Use this for initialization
	void Start () {

		AudioSource[] audioSources = GetComponents<AudioSource>();
		

		foreach (AudioSource audioSource in audioSources) {
			if (audioSource.priority == 128) {
				radioSource = audioSource;
			} else if (audioSource.priority == 1) {
				innerThought = audioSource;
			}
		}


	}

	public void callHeli () {
		radioSource.clip = radioMessages[0];
		radioSource.Play();

	}

	public void areaClear () {
		innerThought.clip = areaLibera;
		innerThought.Play();

	}

	public void wHappened () {
		innerThought.clip = whatHappened;
		innerThought.Play();
	}


}
