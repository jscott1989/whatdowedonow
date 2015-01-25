using UnityEngine;
using System.Collections;

public class PlayGlassBreakSound : MonoBehaviour {
	public AudioSource source;
	public AudioClip[] clips;

	public void play() {
		int r = Random.Range(0, clips.Length);
		source.PlayOneShot(clips[r]);
	}
}
