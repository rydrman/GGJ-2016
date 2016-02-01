using UnityEngine;
using System.Collections;

public class SoundSampler : MonoBehaviour {

	public AudioClip[] sounds;

	public void PlaySound() {
		GetComponent<AudioSource>()
		.PlayOneShot(sounds[Random.Range(0, sounds.Length)],
			   		 0.7f);
	}

}
